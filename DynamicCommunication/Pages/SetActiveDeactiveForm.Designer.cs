namespace DynamicCommunication.Pages
{
    partial class SetActiveDeactiveForm
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
            this._closeButton = new System.Windows.Forms.Button();
            this._setButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(203, 734);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(174, 72);
            this._closeButton.TabIndex = 1;
            this._closeButton.Text = "Close";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // _setButton
            // 
            this._setButton.Location = new System.Drawing.Point(23, 734);
            this._setButton.Name = "_setButton";
            this._setButton.Size = new System.Drawing.Size(174, 72);
            this._setButton.TabIndex = 2;
            this._setButton.Text = "Kaydet";
            this._setButton.UseVisualStyleBackColor = true;
            this._setButton.Click += new System.EventHandler(this._setButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1309, 715);
            this.dataGridView1.TabIndex = 3;
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(1351, 13);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(174, 72);
            this._deleteButton.TabIndex = 5;
            this._deleteButton.Text = "Sil";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // SetActiveDeactiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 884);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._setButton);
            this.Controls.Add(this._closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetActiveDeactiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetActiveDeactiveForm";
            this.Load += new System.EventHandler(this.SetActiveDeactiveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _setButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button _deleteButton;
    }
}