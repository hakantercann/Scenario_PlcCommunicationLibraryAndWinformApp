namespace Scenario1_PcToTwoPlcViaModbus.UserControls
{
    partial class UC_setActiveDeactive
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plc2_panel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.plc2_ipAddress = new System.Windows.Forms.TextBox();
            this.plc2_portNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.plc1_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.plc1_ipAddress = new System.Windows.Forms.TextBox();
            this.plc1_portNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.plc1_unitId = new System.Windows.Forms.TextBox();
            this.plc2_unitId = new System.Windows.Forms.TextBox();
            this.sql_panel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.sql_connectionType = new System.Windows.Forms.ComboBox();
            this.sql_portNumber = new System.Windows.Forms.TextBox();
            this.sql_ipAddress = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plc2_panel.SuspendLayout();
            this.plc1_panel.SuspendLayout();
            this.sql_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // plc2_panel
            // 
            this.plc2_panel.Controls.Add(this.plc2_unitId);
            this.plc2_panel.Controls.Add(this.label12);
            this.plc2_panel.Controls.Add(this.label10);
            this.plc2_panel.Controls.Add(this.plc2_ipAddress);
            this.plc2_panel.Controls.Add(this.plc2_portNumber);
            this.plc2_panel.Controls.Add(this.label8);
            this.plc2_panel.Location = new System.Drawing.Point(268, 136);
            this.plc2_panel.Name = "plc2_panel";
            this.plc2_panel.Size = new System.Drawing.Size(949, 80);
            this.plc2_panel.TabIndex = 70;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(18, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 25);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ip Address:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(310, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 25);
            this.label10.TabIndex = 36;
            this.label10.Text = "Port Number:";
            // 
            // plc2_ipAddress
            // 
            this.plc2_ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc2_ipAddress.Location = new System.Drawing.Point(136, 19);
            this.plc2_ipAddress.Name = "plc2_ipAddress";
            this.plc2_ipAddress.Size = new System.Drawing.Size(100, 30);
            this.plc2_ipAddress.TabIndex = 37;
            // 
            // plc2_portNumber
            // 
            this.plc2_portNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc2_portNumber.Location = new System.Drawing.Point(443, 22);
            this.plc2_portNumber.Name = "plc2_portNumber";
            this.plc2_portNumber.Size = new System.Drawing.Size(100, 30);
            this.plc2_portNumber.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(597, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 25);
            this.label8.TabIndex = 39;
            this.label8.Text = "Unit ID:";
            // 
            // plc1_panel
            // 
            this.plc1_panel.Controls.Add(this.plc1_unitId);
            this.plc1_panel.Controls.Add(this.label1);
            this.plc1_panel.Controls.Add(this.label4);
            this.plc1_panel.Controls.Add(this.plc1_ipAddress);
            this.plc1_panel.Controls.Add(this.plc1_portNumber);
            this.plc1_panel.Controls.Add(this.label6);
            this.plc1_panel.Location = new System.Drawing.Point(268, 28);
            this.plc1_panel.Name = "plc1_panel";
            this.plc1_panel.Size = new System.Drawing.Size(949, 78);
            this.plc1_panel.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Ip Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(310, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Port Number:";
            // 
            // plc1_ipAddress
            // 
            this.plc1_ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc1_ipAddress.Location = new System.Drawing.Point(136, 18);
            this.plc1_ipAddress.Name = "plc1_ipAddress";
            this.plc1_ipAddress.Size = new System.Drawing.Size(100, 30);
            this.plc1_ipAddress.TabIndex = 31;
            // 
            // plc1_portNumber
            // 
            this.plc1_portNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc1_portNumber.Location = new System.Drawing.Point(443, 16);
            this.plc1_portNumber.Name = "plc1_portNumber";
            this.plc1_portNumber.Size = new System.Drawing.Size(100, 30);
            this.plc1_portNumber.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(597, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "Unit ID:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(134, 161);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 68;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(134, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 67;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(22, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 66;
            this.label3.Text = "PLC2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(22, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 65;
            this.label2.Text = "PLC1";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.closeButton.Location = new System.Drawing.Point(161, 416);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(152, 62);
            this.closeButton.TabIndex = 72;
            this.closeButton.Text = "Kapat";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // setButton
            // 
            this.setButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.setButton.Location = new System.Drawing.Point(3, 416);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(152, 62);
            this.setButton.TabIndex = 71;
            this.setButton.Text = "Kaydet";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // plc1_unitId
            // 
            this.plc1_unitId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc1_unitId.Location = new System.Drawing.Point(780, 16);
            this.plc1_unitId.Name = "plc1_unitId";
            this.plc1_unitId.Size = new System.Drawing.Size(100, 30);
            this.plc1_unitId.TabIndex = 34;
            // 
            // plc2_unitId
            // 
            this.plc2_unitId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc2_unitId.Location = new System.Drawing.Point(780, 14);
            this.plc2_unitId.Name = "plc2_unitId";
            this.plc2_unitId.Size = new System.Drawing.Size(100, 30);
            this.plc2_unitId.TabIndex = 40;
            // 
            // sql_panel
            // 
            this.sql_panel.Controls.Add(this.label15);
            this.sql_panel.Controls.Add(this.label14);
            this.sql_panel.Controls.Add(this.label13);
            this.sql_panel.Controls.Add(this.sql_connectionType);
            this.sql_panel.Controls.Add(this.sql_portNumber);
            this.sql_panel.Controls.Add(this.sql_ipAddress);
            this.sql_panel.Location = new System.Drawing.Point(268, 249);
            this.sql_panel.Name = "sql_panel";
            this.sql_panel.Size = new System.Drawing.Size(949, 95);
            this.sql_panel.TabIndex = 75;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(16, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 25);
            this.label15.TabIndex = 41;
            this.label15.Text = "Ip Address:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(310, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 25);
            this.label14.TabIndex = 42;
            this.label14.Text = "Port Number:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(597, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(168, 25);
            this.label13.TabIndex = 45;
            this.label13.Text = "Connection Type:";
            // 
            // sql_connectionType
            // 
            this.sql_connectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sql_connectionType.FormattingEnabled = true;
            this.sql_connectionType.Location = new System.Drawing.Point(780, 29);
            this.sql_connectionType.Name = "sql_connectionType";
            this.sql_connectionType.Size = new System.Drawing.Size(121, 33);
            this.sql_connectionType.TabIndex = 40;
            // 
            // sql_portNumber
            // 
            this.sql_portNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sql_portNumber.Location = new System.Drawing.Point(443, 29);
            this.sql_portNumber.Name = "sql_portNumber";
            this.sql_portNumber.Size = new System.Drawing.Size(100, 30);
            this.sql_portNumber.TabIndex = 44;
            // 
            // sql_ipAddress
            // 
            this.sql_ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sql_ipAddress.Location = new System.Drawing.Point(136, 37);
            this.sql_ipAddress.Name = "sql_ipAddress";
            this.sql_ipAddress.Size = new System.Drawing.Size(100, 30);
            this.sql_ipAddress.TabIndex = 43;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(134, 286);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 74;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(22, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 25);
            this.label5.TabIndex = 73;
            this.label5.Text = "SQL";
            // 
            // UC_setActiveDeactive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sql_panel);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.plc2_panel);
            this.Controls.Add(this.plc1_panel);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "UC_setActiveDeactive";
            this.Size = new System.Drawing.Size(1677, 876);
            this.Load += new System.EventHandler(this.UC_setActiveDeactive_Load);
            this.plc2_panel.ResumeLayout(false);
            this.plc2_panel.PerformLayout();
            this.plc1_panel.ResumeLayout(false);
            this.plc1_panel.PerformLayout();
            this.sql_panel.ResumeLayout(false);
            this.sql_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plc2_panel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox plc2_ipAddress;
        private System.Windows.Forms.TextBox plc2_portNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel plc1_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox plc1_ipAddress;
        private System.Windows.Forms.TextBox plc1_portNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.TextBox plc2_unitId;
        private System.Windows.Forms.TextBox plc1_unitId;
        private System.Windows.Forms.Panel sql_panel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox sql_connectionType;
        private System.Windows.Forms.TextBox sql_portNumber;
        private System.Windows.Forms.TextBox sql_ipAddress;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label5;
    }
}
