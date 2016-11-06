namespace FindMissingRows
{
    partial class FilterDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.filterColumn = new System.Windows.Forms.ComboBox();
            this.columnNameBox = new System.Windows.Forms.TextBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterExpressionBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.filterTypeCb = new System.Windows.Forms.ComboBox();
            this.filterContents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(13, 226);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 0;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(197, 226);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Close";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // filterColumn
            // 
            this.filterColumn.FormattingEnabled = true;
            this.filterColumn.Location = new System.Drawing.Point(22, 29);
            this.filterColumn.Name = "filterColumn";
            this.filterColumn.Size = new System.Drawing.Size(121, 21);
            this.filterColumn.TabIndex = 2;
            this.filterColumn.Text = "Select Column";
            this.filterColumn.SelectedIndexChanged += new System.EventHandler(this.filterColumn_SelectedIndexChanged);
            // 
            // columnNameBox
            // 
            this.columnNameBox.Enabled = false;
            this.columnNameBox.Location = new System.Drawing.Point(164, 31);
            this.columnNameBox.Name = "columnNameBox";
            this.columnNameBox.Size = new System.Drawing.Size(108, 20);
            this.columnNameBox.TabIndex = 3;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(22, 97);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(250, 20);
            this.filterTextBox.TabIndex = 4;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterText_TextChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(22, 78);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(77, 13);
            this.filterLabel.TabIndex = 5;
            this.filterLabel.Text = "Enter your filter";
            // 
            // filterExpressionBox
            // 
            this.filterExpressionBox.Enabled = false;
            this.filterExpressionBox.Location = new System.Drawing.Point(22, 191);
            this.filterExpressionBox.Name = "filterExpressionBox";
            this.filterExpressionBox.Size = new System.Drawing.Size(250, 20);
            this.filterExpressionBox.TabIndex = 6;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(105, 226);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // filterTypeCb
            // 
            this.filterTypeCb.FormattingEnabled = true;
            this.filterTypeCb.Location = new System.Drawing.Point(25, 135);
            this.filterTypeCb.Name = "filterTypeCb";
            this.filterTypeCb.Size = new System.Drawing.Size(121, 21);
            this.filterTypeCb.TabIndex = 8;
            this.filterTypeCb.SelectedIndexChanged += new System.EventHandler(this.filterTypeCb_SelectedIndexChanged);
            // 
            // filterContents
            // 
            this.filterContents.AutoSize = true;
            this.filterContents.Location = new System.Drawing.Point(22, 175);
            this.filterContents.Name = "filterContents";
            this.filterContents.Size = new System.Drawing.Size(82, 13);
            this.filterContents.TabIndex = 9;
            this.filterContents.Text = "Generated Filter";
            // 
            // FilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.filterContents);
            this.Controls.Add(this.filterTypeCb);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.filterExpressionBox);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.columnNameBox);
            this.Controls.Add(this.filterColumn);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Name = "FilterDialog";
            this.Text = "FilterDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox filterColumn;
        private System.Windows.Forms.TextBox columnNameBox;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterExpressionBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox filterTypeCb;
        private System.Windows.Forms.Label filterContents;
    }
}