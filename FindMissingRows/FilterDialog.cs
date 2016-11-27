using System;
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

            // List of filter types to support
            filterTypeCb.Items.AddRange(new string [] {"Equals", "Begins", "Ends" });

            // setup default filter type
            filterTypeCb.SelectedIndex = filterTypeCb.Items.IndexOf("Equals");
        }

        /// <summary>
        /// Apply the filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apply_Click(object sender, EventArgs e)
        {
            MainForm.Filter(FilterString);
        }

        // close the filter form
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handle changes in the selected filter type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterColumn.SelectedItem != null)
                columnNameBox.Text = filterColumn.SelectedItem.ToString();
            else
                columnNameBox.Text = string.Empty;
            UpdateFilter();
        }

        /// <summary>
        /// Create the filter and apply it.
        /// </summary>
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

        /// <summary>
        /// handle manual changes to the filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterText_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        /// <summary>
        /// Handle the Clear button by setting no filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            filterColumn.SelectedItem = null;
            filterTextBox.Text = string.Empty;
            UpdateFilter();
            MainForm.Filter(FilterString);
        }

        /// <summary>
        /// Handle a selection change of the filter type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }
    }
}
