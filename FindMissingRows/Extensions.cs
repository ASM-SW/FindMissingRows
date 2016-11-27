using System.Data;
using System.Text;
using System.Windows.Forms;

public static class Extensions
{
    /// <summary>
    /// Extension to the DataTable to add a "ToCSV" method.
    /// </summary>
    /// <param name="table"></param>
    /// <returns>the table as a CSV string</returns>
    public static string ToCSV(this DataTable table)
    {
        // reference: adapted from  http://stackoverflow.com/questions/888181/convert-datatable-to-csv-stream
        var result = new StringBuilder();
        for (int i = 0; i < table.Columns.Count; i++)
        {
            result.AppendFormat("\"{0}\"",table.Columns[i].ColumnName);
            result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
        }

        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.AppendFormat("\"{0}\"", row[i].ToString());
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Extension to the DataGrivView to add a "ToCSV" method.
    /// </summary>
    /// <param name="table"></param>
    /// <returns>the table as a CSV string</returns>
    public static string ToCSV(this DataGridView table)
    {
        // reference: adapted from  http://stackoverflow.com/questions/888181/convert-datatable-to-csv-stream
        var result = new StringBuilder();
        for (int i = 0; i < table.Columns.Count; i++)
        {
            result.AppendFormat("\"{0}\"", table.Columns[i].Name);
            result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
        }

        foreach (DataGridViewRow row in table.Rows)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                result.AppendFormat("\"{0}\"", row.Cells[i].FormattedValue);
                result.Append(i == row.Cells.Count - 1 ? "\n" : ",");
            }
        }

        return result.ToString();
    }
}
