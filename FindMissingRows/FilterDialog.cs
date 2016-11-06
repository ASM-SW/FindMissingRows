using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMissingRows
{
    public partial class FilterDialog : Form
    {
        public string FilterString { get; set; }
        public Form1 MainForm { private get; set; }

        public FilterDialog(object [] columnNames)
        {
            InitializeComponent();

            filterColumn.Items.AddRange(columnNames);

            filterTypeCb.Items.AddRange(new string [] {"Equals", "Begins", "Ends" });
            filterTypeCb.SelectedIndex = filterTypeCb.Items.IndexOf("Equals");
        }

        private void apply_Click(object sender, EventArgs e)
        {
            MainForm.Filter(FilterString);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void filterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterColumn.SelectedItem != null)
                columnNameBox.Text = filterColumn.SelectedItem.ToString();
            else
                columnNameBox.Text = string.Empty;
            UpdateFilter();
        }

        private void UpdateFilter()
        {
            if (string.IsNullOrWhiteSpace(columnNameBox.Text) && string.IsNullOrWhiteSpace(filterTextBox.Text))
            {
                FilterString = string.Empty;
            }
            else
            {
                switch (filterTypeCb.Text)
                {
                    case "Equals":
                        FilterString = string.Format("[{0}] = '{1}'", columnNameBox.Text, filterTextBox.Text);
                        break;
                    case "Begins":
                        FilterString = string.Format("[{0}] LIKE '{1}*'", columnNameBox.Text, filterTextBox.Text);
                        break;
                    case "Ends":
                        FilterString = string.Format("[{0}] LIKE '*{1}'", columnNameBox.Text, filterTextBox.Text);
                        break;
                    default:
                        return;
                } // end switch
            } // end else

            // No column name in the filter creates an exception so clear the filter string
            if (string.IsNullOrEmpty(columnNameBox.Text))
                FilterString = string.Empty;
            filterExpressionBox.Text = FilterString;
        }

        private void filterText_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filterColumn.SelectedItem = null;
            filterTextBox.Text = string.Empty;
            UpdateFilter();
            MainForm.Filter(FilterString);
        }

        private void filterTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }
    }
}
