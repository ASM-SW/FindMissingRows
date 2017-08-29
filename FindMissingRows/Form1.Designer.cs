namespace FindMissingRows
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectMemberList = new System.Windows.Forms.Button();
            this.MemberListFileName = new System.Windows.Forms.TextBox();
            this.CompareListFileName = new System.Windows.Forms.TextBox();
            this.SelectListToCompare = new System.Windows.Forms.Button();
            this.dataSet = new System.Data.DataSet();
            this.columnToCompare = new System.Windows.Forms.Label();
            this.memberColumnNames = new System.Windows.Forms.ComboBox();
            this.compareColumnNames = new System.Windows.Forms.ComboBox();
            this.findMissingItems = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.resultSummary = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.buttonSwap = new System.Windows.Forms.Button();
            this.textBoxConfigName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectMemberList
            // 
            this.SelectMemberList.Location = new System.Drawing.Point(34, 21);
            this.SelectMemberList.Name = "SelectMemberList";
            this.SelectMemberList.Size = new System.Drawing.Size(129, 23);
            this.SelectMemberList.TabIndex = 0;
            this.SelectMemberList.Text = "Member List File";
            this.SelectMemberList.UseVisualStyleBackColor = true;
            this.SelectMemberList.Click += new System.EventHandler(this.SelectMemberList_Click);
            // 
            // MemberListFileName
            // 
            this.MemberListFileName.Location = new System.Drawing.Point(179, 23);
            this.MemberListFileName.Name = "MemberListFileName";
            this.MemberListFileName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.MemberListFileName.Size = new System.Drawing.Size(673, 20);
            this.MemberListFileName.TabIndex = 1;
            this.MemberListFileName.WordWrap = false;
            // 
            // CompareListFileName
            // 
            this.CompareListFileName.Location = new System.Drawing.Point(179, 88);
            this.CompareListFileName.Name = "CompareListFileName";
            this.CompareListFileName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.CompareListFileName.Size = new System.Drawing.Size(673, 20);
            this.CompareListFileName.TabIndex = 3;
            this.CompareListFileName.WordWrap = false;
            // 
            // SelectListToCompare
            // 
            this.SelectListToCompare.Location = new System.Drawing.Point(34, 86);
            this.SelectListToCompare.Name = "SelectListToCompare";
            this.SelectListToCompare.Size = new System.Drawing.Size(129, 23);
            this.SelectListToCompare.TabIndex = 2;
            this.SelectListToCompare.Text = "File To Compare";
            this.SelectListToCompare.UseVisualStyleBackColor = true;
            this.SelectListToCompare.Click += new System.EventHandler(this.SelectListToCompare_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "Data";
            // 
            // columnToCompare
            // 
            this.columnToCompare.AutoSize = true;
            this.columnToCompare.Location = new System.Drawing.Point(882, 3);
            this.columnToCompare.Name = "columnToCompare";
            this.columnToCompare.Size = new System.Drawing.Size(103, 13);
            this.columnToCompare.TabIndex = 5;
            this.columnToCompare.Text = "Column To Compare";
            // 
            // memberColumnNames
            // 
            this.memberColumnNames.FormattingEnabled = true;
            this.memberColumnNames.Location = new System.Drawing.Point(874, 21);
            this.memberColumnNames.Name = "memberColumnNames";
            this.memberColumnNames.Size = new System.Drawing.Size(121, 21);
            this.memberColumnNames.TabIndex = 4;
            // 
            // compareColumnNames
            // 
            this.compareColumnNames.FormattingEnabled = true;
            this.compareColumnNames.Location = new System.Drawing.Point(874, 88);
            this.compareColumnNames.Name = "compareColumnNames";
            this.compareColumnNames.Size = new System.Drawing.Size(121, 21);
            this.compareColumnNames.TabIndex = 6;
            // 
            // findMissingItems
            // 
            this.findMissingItems.Location = new System.Drawing.Point(34, 135);
            this.findMissingItems.Name = "findMissingItems";
            this.findMissingItems.Size = new System.Drawing.Size(129, 23);
            this.findMissingItems.TabIndex = 7;
            this.findMissingItems.Text = "Find Missing Items";
            this.findMissingItems.UseVisualStyleBackColor = true;
            this.findMissingItems.Click += new System.EventHandler(this.findMissingItems_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ContextMenuStrip = this.contextMenuGridView;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 212);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1101, 351);
            this.dataGridView1.TabIndex = 8;
            // 
            // contextMenuGridView
            // 
            this.contextMenuGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuGridView.Name = "contextMenuGridView";
            this.contextMenuGridView.Size = new System.Drawing.Size(103, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save.Location = new System.Drawing.Point(34, 166);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(42, 23);
            this.save.TabIndex = 9;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(962, 166);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 10;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // resultSummary
            // 
            this.resultSummary.Location = new System.Drawing.Point(179, 166);
            this.resultSummary.Name = "resultSummary";
            this.resultSummary.Size = new System.Drawing.Size(449, 20);
            this.resultSummary.TabIndex = 11;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(206, 135);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 12;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Enabled = false;
            this.filterTextBox.Location = new System.Drawing.Point(298, 135);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(288, 20);
            this.filterTextBox.TabIndex = 13;
            // 
            // buttonSwap
            // 
            this.buttonSwap.Location = new System.Drawing.Point(388, 56);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(98, 23);
            this.buttonSwap.TabIndex = 14;
            this.buttonSwap.Text = "Λ V Swap Files ";
            this.buttonSwap.UseVisualStyleBackColor = true;
            this.buttonSwap.Click += new System.EventHandler(this.buttonSwap_Click);
            // 
            // textBoxConfigName
            // 
            this.textBoxConfigName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfigName.Location = new System.Drawing.Point(179, 192);
            this.textBoxConfigName.Name = "textBoxConfigName";
            this.textBoxConfigName.ReadOnly = true;
            this.textBoxConfigName.Size = new System.Drawing.Size(858, 18);
            this.textBoxConfigName.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 563);
            this.Controls.Add(this.textBoxConfigName);
            this.Controls.Add(this.buttonSwap);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.resultSummary);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.save);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.findMissingItems);
            this.Controls.Add(this.compareColumnNames);
            this.Controls.Add(this.columnToCompare);
            this.Controls.Add(this.memberColumnNames);
            this.Controls.Add(this.CompareListFileName);
            this.Controls.Add(this.SelectListToCompare);
            this.Controls.Add(this.MemberListFileName);
            this.Controls.Add(this.SelectMemberList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Find Missing Rows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuGridView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SelectMemberList;
        private System.Windows.Forms.TextBox MemberListFileName;
        private System.Windows.Forms.TextBox CompareListFileName;
        private System.Windows.Forms.Button SelectListToCompare;
        private System.Data.DataSet dataSet;
        private System.Windows.Forms.Label columnToCompare;
        private System.Windows.Forms.ComboBox memberColumnNames;
        private System.Windows.Forms.ComboBox compareColumnNames;
        private System.Windows.Forms.Button findMissingItems;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.TextBox resultSummary;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.ContextMenuStrip contextMenuGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox textBoxConfigName;
    }
}

