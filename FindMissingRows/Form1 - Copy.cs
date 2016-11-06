using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace FindMissingRows
{
    public partial class Form1 : Form
    {
        static readonly string defaultColumnName = "Select a column";
        bool m_memberListInit;
        bool m_compareListInit;
        DataTable m_missingTable;
        BindingSource m_bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            dataSet.Tables.Add(new DataTable("MemberList"));
            dataSet.Tables.Add(new DataTable("CompareList"));

            memberColumnNames.Enabled = false;
            compareColumnNames.Enabled = false;
            save.Enabled = false;
            filterButton.Enabled = false;
        }

        private void SelectMemberList_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;

            MemberListFileName.Text = openFileDialog1.FileName;
            DataTable dt = dataSet.Tables["MemberList"];
            GetDataTabletFromCSVFile(MemberListFileName.Text, ref dt, ref memberColumnNames);
            m_memberListInit = true;
        }

        private void SelectListToCompare_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;

            CompareListFileName.Text = openFileDialog1.FileName;
            DataTable dt = dataSet.Tables["CompareList"];
            GetDataTabletFromCSVFile(CompareListFileName.Text, ref dt, ref compareColumnNames);
            m_compareListInit = true;
        }


        private static void GetDataTabletFromCSVFile(string csv_file_path, ref DataTable csvData, ref ComboBox comboBox)
        {
            // clean up any previous data
            if (csvData.Columns.Count > 0)
                csvData = new DataTable();

            comboBox.Items.Clear();

            using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            comboBox.Items.Add(defaultColumnName);
            foreach (DataColumn column in csvData.Columns)
            {
                comboBox.Items.Add(column.ColumnName);
            }
            comboBox.SelectedIndex = 0;
            comboBox.Enabled = true;

            return;
        }

        private void findMissingItems_Click(object sender, EventArgs e)
        {
            if (!m_compareListInit)
            {
                MessageBox.Show("Compare list file has not been selected");
                return;
            }
            if (!m_memberListInit)
            {
                MessageBox.Show("Member list file has not been selected");
                return;
            }
            string memberColName = memberColumnNames.SelectedItem.ToString();
            if (memberColName == defaultColumnName)
            {
                MessageBox.Show("Select a member list column");
                return;
            }
            string compareColName = compareColumnNames.SelectedItem.ToString();
            if (compareColName == defaultColumnName)
            {
                MessageBox.Show("Select a compare list column");
                return;
            }

            // create references to the tables
            DataTable dtMembers = dataSet.Tables["MemberList"];
            DataTable dtCompare = dataSet.Tables["CompareList"];

            // check and see if the MissingList table exists, if it does replace it with a new one in case the schema is different
            if (dataSet.Tables.Contains("MissingList"))
            {
                m_missingTable = dataSet.Tables["MissingList"];
                dataSet.Tables.Remove(m_missingTable);
            }
            // create the table for the missing rows
            m_missingTable = dtMembers.Clone();       // creates an empty clone with the same schema
            m_missingTable.TableName = "MissingList";
            dataSet.Tables.Add(m_missingTable);

            // in case the selected compare column has a blank in it, fill it with an unique number
            int count = 0;
            foreach (DataRow row in dtCompare.Rows)
            {
                if (string.IsNullOrWhiteSpace(row[compareColName].ToString()))
                    row[compareColName] = "---" + count++;
            }

            // add index to compare list table
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtCompare.Columns[compareColName];
            dtCompare.PrimaryKey = keys;

            // find missing items in compare
            foreach (DataRow row in dtMembers.Rows)
            {
                string searchString = row[memberColName].ToString();
                DataRow foundRow = dtCompare.Rows.Find(searchString);
                if (foundRow == null)
                {
                    m_missingTable.ImportRow(row);
                }
            }

            resultSummary.Text = string.Format("{0} members missing out of {1}", m_missingTable.Rows.Count, dtMembers.Rows.Count);

            // fill up the dataview
            dataGridView1.SelectAll();
            dataGridView1.ClearSelection();

            m_bindingSource.RemoveFilter();
            filterTextBox.Text = string.Empty;
            m_bindingSource.DataSource = m_missingTable;
            dataGridView1.DataSource = m_bindingSource;
            dataGridView1.Refresh();
            filterButton.Enabled = true;
            Refresh();

            save.Enabled = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "CSV files (*.csv)|*.csv";
            DialogResult res = saveDlg.ShowDialog();
            if (res != DialogResult.OK)
                return;

            StringBuilder output = new StringBuilder();

            DataTable m_missingTable = dataSet.Tables["MissingList"];
            // column headers
            int cnt = 1;
            foreach (DataColumn col in m_missingTable.Columns)
            {
                output.AppendFormat("\"{0}\"", col.ColumnName);
                if (cnt++ < m_missingTable.Columns.Count)
                    output.AppendFormat(",");
            }
            output.AppendLine();

            cnt = 1;
            foreach (DataRow row in m_missingTable.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    output.AppendFormat("\"{0}\"", row.ItemArray[i].ToString());
                    if (i < row.ItemArray.Length - 1)
                        output.AppendFormat(",");
                }
                output.AppendLine();
            }
            System.IO.File.WriteAllText(saveDlg.FileName, output.ToString());
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            DataColumnCollection columns = dataSet.Tables["MissingList"].Columns;
            string[] names = new string[columns.Count];
            for (int i = 0; i < columns.Count; i++)
            {
                names[i] = columns[i].ColumnName;
            }
            
            FilterDialog  filterDialog = new FilterDialog(names);
            filterDialog.MainForm = this;
            filterDialog.StartPosition = FormStartPosition.CenterParent;
            filterDialog.ShowDialog();
        }

        public void Filter(string filter)
        {
            // fill up the dataview
            dataGridView1.SelectAll();
            dataGridView1.ClearSelection();


            try
            {
                m_bindingSource.DataSource = m_missingTable;
                dataGridView1.DataSource = m_bindingSource;
                m_bindingSource.RemoveFilter();
                m_bindingSource.Filter = filter;
                dataGridView1.Refresh();
                filterButton.Enabled = true;
                filterTextBox.Text = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bad filter: " + ex.ToString());
            }
            resultSummary.Text = string.Format("{0} members missing out of {1}, {2} rows visible with filter", 
                m_missingTable.Rows.Count, 
                dataSet.Tables["MemberList"].Rows.Count,
                dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible));
            Refresh();
        }


    }

}

