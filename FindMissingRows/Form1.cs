using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace FindMissingRows
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// List of tables contained in dataSet
        /// </summary>
        private enum TableNames
        {
            MemberList,
            CompareList,
            MissingList
        }

        static readonly string defaultColumnName = "Select a column";
        bool m_memberListInit;
        bool m_compareListInit;
        DataTable m_missingTable;
        BindingSource m_bindingSource = new BindingSource();

        Configuration m_settings = new Configuration();

        public static bool Serialize<T>(T value, string fileName/*, ref string serializeXml*/)
        {
            if (value == null)
                return false;

            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (StreamWriter stringWriter = new StreamWriter(fileName))
            {
                XmlWriter writer = XmlWriter.Create(stringWriter);
                xmlserializer.Serialize(writer, value);
                //serializeXml = stringWriter.ToString();
            }
            return true;
        }

        public bool DeSerialize<T>(ref T value, string fileName)
        {
            if (!File.Exists(fileName))
                return false;

            using (TextReader reader = new StreamReader(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                value = (T)serializer.Deserialize(reader);
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();

            memberColumnNames.Enabled = false;
            compareColumnNames.Enabled = false;
            save.Enabled = false;
            filterButton.Enabled = false;

            DeSerialize(ref m_settings, Configuration.FileName);

            textBoxConfigName.Text = string.Format("Configuration file: {0}", Configuration.FileName);
            InitFileControls(ref MemberListFileName, m_settings.MemberListFileName, ref m_memberListInit,
                TableNames.MemberList.ToString(), ref memberColumnNames, m_settings.MemberListColumnName);
            InitFileControls(ref CompareListFileName, m_settings.CompareListFileName, ref m_compareListInit,
                TableNames.CompareList.ToString(), ref compareColumnNames, m_settings.CompareListColumnName);

            Refresh();
        }

        private void InitFileControls(ref TextBox fileNameCtl, string fileName, ref bool bInit, string tableName, ref ComboBox columnNames, string columNameToSelect)
        {
            if (!System.IO.File.Exists(m_settings.MemberListFileName))
                return;

            fileNameCtl.Text = fileName;
            FillDataTableFromCSVFile(fileNameCtl.Text, tableName, ref columnNames);
            bInit = true;

            if (string.IsNullOrEmpty(columNameToSelect))
                return;

            int index = columnNames.Items.IndexOf(columNameToSelect);
            if (index < 0)
                return;

            columnNames.SelectedIndex = index;
        }

        /// <summary>
        /// Select the file to use for the member list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectMemberList_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;

            MemberListFileName.Text = openFileDialog1.FileName;
            FillDataTableFromCSVFile(MemberListFileName.Text, TableNames.MemberList.ToString(), ref memberColumnNames);
            m_memberListInit = true;
        }

        /// <summary>
        /// Select the file to use for the compare list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectListToCompare_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;

            CompareListFileName.Text = openFileDialog1.FileName;
            FillDataTableFromCSVFile(CompareListFileName.Text, TableNames.CompareList.ToString(), ref compareColumnNames);
            m_compareListInit = true;
        }

        // swap files between MemberFileList and CompareListFile
        private void buttonSwap_Click(object sender, EventArgs e)
        {
            // temporary remember settings for CompareList
            string previousCompareListFileName = CompareListFileName.Text;
            int previousCompareColumnNamesSelectedIndex = compareColumnNames.SelectedIndex;
            bool previousCompareListInit = m_compareListInit;
            bool compareListReFilled = false;

            // if MemberList was initialized, then set CompareList to MemberList
            if (m_memberListInit)
            {
                CompareListFileName.Text = MemberListFileName.Text;
                FillDataTableFromCSVFile(CompareListFileName.Text, TableNames.CompareList.ToString(), ref compareColumnNames);
                compareColumnNames.SelectedIndex = memberColumnNames.SelectedIndex;
                m_compareListInit = true;
                MemberListFileName.Text = string.Empty;
                memberColumnNames.Items.Clear();
                memberColumnNames.Text = string.Empty;
                m_memberListInit = false;
                compareListReFilled = true;
            }

            // if CompareList was initialized before entering funciton, then set MemberList to CompareList
            if (previousCompareListInit)
            {
                MemberListFileName.Text = previousCompareListFileName;
                FillDataTableFromCSVFile(MemberListFileName.Text, TableNames.MemberList.ToString(), ref memberColumnNames);
                memberColumnNames.SelectedIndex = previousCompareColumnNamesSelectedIndex;
                m_memberListInit = true;
                if (!compareListReFilled)
                {
                    CompareListFileName.Clear();
                    compareColumnNames.Items.Clear();
                    compareColumnNames.Text = string.Empty;
                    m_compareListInit = false;
                }

                if (dataSet.Tables.Contains(TableNames.MissingList.ToString()))
                    dataSet.Tables[TableNames.MissingList.ToString()].Reset();
            }
            if (m_compareListInit && m_memberListInit)
                FindMissingItems();
        }


        /// <summary>
        /// Read in a CSV file into data table and load combo box with column names from the new file
        /// </summary>
        /// <param name="csv_file_path">name of file to read in</param>
        /// <param name="tableName">Title to give table</param>
        /// <param name="comboBox">comboBox that will be reloaded with column names from file</param>
        private void FillDataTableFromCSVFile(string csv_file_path, string tableName, ref ComboBox comboBox)
        {
            // always start with a new table so that know the schema is correct
            if (dataSet.Tables.Contains(tableName))
                dataSet.Tables.Remove(tableName);

            DataTable csvData = new DataTable();
            csvData.TableName = tableName;
            dataSet.Tables.Add(csvData);

            comboBox.Items.Clear();

            using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datacolumn = new DataColumn(column);
                    datacolumn.AllowDBNull = true;
                    csvData.Columns.Add(datacolumn);
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

        /// <summary>
        /// Compare the two files and show the missing rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findMissingItems_Click(object sender, EventArgs e)
        {
            FindMissingItems();
        }

        private void FindMissingItems()
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
            DataTable dtMembers = dataSet.Tables[TableNames.MemberList.ToString()];
            DataTable dtCompare = dataSet.Tables[TableNames.CompareList.ToString()];

            // check and see if the MissingList table exists, if it does replace it with a new one in case the schema is different
            if (dataSet.Tables.Contains(TableNames.MissingList.ToString()))
                dataSet.Tables.Remove(m_missingTable);

            // create the table for the missing rows
            m_missingTable = dtMembers.Clone();       // creates an empty clone with the same schema
            m_missingTable.TableName = TableNames.MissingList.ToString();
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
            try
            {
                dtCompare.PrimaryKey = keys;

            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("The file: {0}\n\tColumn: '{1}', must have unique values.\n\n", CompareListFileName.Text, compareColName);
                builder.AppendFormat("Error: {0}", ex.Message);
                MessageBox.Show(builder.ToString());
                return;
            }
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

        /// <summary>
        /// Save missing rows to a CSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "CSV files (*.csv)|*.csv";
            DialogResult res = saveDlg.ShowDialog();
            if (res != DialogResult.OK)
                return;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveDlg.FileName))
            {
                file.Write(dataGridView1.ToCSV());
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            DataColumnCollection columns = dataSet.Tables[TableNames.MissingList.ToString()].Columns;
            string[] names = new string[columns.Count];
            for (int i = 0; i < columns.Count; i++)
            {
                names[i] = columns[i].ColumnName;
            }

            FilterDialog filterDialog = new FilterDialog(names);
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
                MessageBox.Show("Bad filter: " + ex.Message);
            }
            resultSummary.Text = string.Format("{0} members missing out of {1}, {2} rows visible with filter",
                m_missingTable.Rows.Count,
                dataSet.Tables[TableNames.MemberList.ToString()].Rows.Count,
                dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible));
            Refresh();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^c");
        }

        private string GetSelectedItemText(ComboBox list)
        {
            if (list.SelectedIndex < 0)
                return null;

            if (list.SelectedItem.ToString() == defaultColumnName)
                return null;

            return list.SelectedItem.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_settings.MemberListFileName = MemberListFileName.Text;
            m_settings.MemberListColumnName = GetSelectedItemText(memberColumnNames);

            m_settings.CompareListFileName = CompareListFileName.Text;
            m_settings.CompareListColumnName = GetSelectedItemText(compareColumnNames);
            Serialize(m_settings, Configuration.FileName);

        }
    }

}

