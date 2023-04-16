using System;

namespace Scenario1_PcToTwoPlcViaModbus
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
            this.statesPanel = new System.Windows.Forms.Panel();
            this.plc5_status = new System.Windows.Forms.Label();
            this.plc4_status = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.plc5State = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.plc4State = new System.Windows.Forms.Label();
            this.plc3_status = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.plc3State = new System.Windows.Forms.Label();
            this.plc2_status = new System.Windows.Forms.Label();
            this.plc1_status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.plc2State = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plc1State = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupCommunicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setActiveDeactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.control_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.transferToPlc1_coils = new System.Windows.Forms.Button();
            this.transferToPlc2_coils = new System.Windows.Forms.Button();
            this.transferToPlc1 = new System.Windows.Forms.Button();
            this.transferToPlc2 = new System.Windows.Forms.Button();
            this.rc_checkBox = new System.Windows.Forms.CheckBox();
            this.rh_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.statesPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.control_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statesPanel
            // 
            this.statesPanel.Controls.Add(this.plc5_status);
            this.statesPanel.Controls.Add(this.plc4_status);
            this.statesPanel.Controls.Add(this.label8);
            this.statesPanel.Controls.Add(this.plc5State);
            this.statesPanel.Controls.Add(this.label10);
            this.statesPanel.Controls.Add(this.plc4State);
            this.statesPanel.Controls.Add(this.plc3_status);
            this.statesPanel.Controls.Add(this.label7);
            this.statesPanel.Controls.Add(this.plc3State);
            this.statesPanel.Controls.Add(this.plc2_status);
            this.statesPanel.Controls.Add(this.plc1_status);
            this.statesPanel.Controls.Add(this.label3);
            this.statesPanel.Controls.Add(this.plc2State);
            this.statesPanel.Controls.Add(this.label2);
            this.statesPanel.Controls.Add(this.label1);
            this.statesPanel.Controls.Add(this.plc1State);
            this.statesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.statesPanel.Location = new System.Drawing.Point(0, 0);
            this.statesPanel.Name = "statesPanel";
            this.statesPanel.Size = new System.Drawing.Size(225, 976);
            this.statesPanel.TabIndex = 0;
            // 
            // plc5_status
            // 
            this.plc5_status.AutoSize = true;
            this.plc5_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc5_status.Location = new System.Drawing.Point(12, 650);
            this.plc5_status.Name = "plc5_status";
            this.plc5_status.Size = new System.Drawing.Size(0, 25);
            this.plc5_status.TabIndex = 24;
            // 
            // plc4_status
            // 
            this.plc4_status.AutoSize = true;
            this.plc4_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc4_status.Location = new System.Drawing.Point(12, 512);
            this.plc4_status.Name = "plc4_status";
            this.plc4_status.Size = new System.Drawing.Size(0, 25);
            this.plc4_status.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(12, 602);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "PLC5";
            // 
            // plc5State
            // 
            this.plc5State.BackColor = System.Drawing.Color.Red;
            this.plc5State.Location = new System.Drawing.Point(120, 589);
            this.plc5State.Name = "plc5State";
            this.plc5State.Size = new System.Drawing.Size(40, 40);
            this.plc5State.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(12, 487);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "PLC4";
            // 
            // plc4State
            // 
            this.plc4State.BackColor = System.Drawing.Color.Red;
            this.plc4State.Location = new System.Drawing.Point(120, 472);
            this.plc4State.Name = "plc4State";
            this.plc4State.Size = new System.Drawing.Size(40, 40);
            this.plc4State.TabIndex = 19;
            // 
            // plc3_status
            // 
            this.plc3_status.AutoSize = true;
            this.plc3_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc3_status.Location = new System.Drawing.Point(12, 430);
            this.plc3_status.Name = "plc3_status";
            this.plc3_status.Size = new System.Drawing.Size(0, 25);
            this.plc3_status.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(12, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "PLC3";
            // 
            // plc3State
            // 
            this.plc3State.BackColor = System.Drawing.Color.Red;
            this.plc3State.Location = new System.Drawing.Point(120, 374);
            this.plc3State.Name = "plc3State";
            this.plc3State.Size = new System.Drawing.Size(40, 40);
            this.plc3State.TabIndex = 16;
            this.plc3State.Click += new System.EventHandler(this.plc3State_Click);
            // 
            // plc2_status
            // 
            this.plc2_status.AutoSize = true;
            this.plc2_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc2_status.Location = new System.Drawing.Point(12, 308);
            this.plc2_status.Name = "plc2_status";
            this.plc2_status.Size = new System.Drawing.Size(0, 25);
            this.plc2_status.TabIndex = 14;
            // 
            // plc1_status
            // 
            this.plc1_status.AutoSize = true;
            this.plc1_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plc1_status.Location = new System.Drawing.Point(12, 188);
            this.plc1_status.Name = "plc1_status";
            this.plc1_status.Size = new System.Drawing.Size(0, 25);
            this.plc1_status.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "PLC2";
            // 
            // plc2State
            // 
            this.plc2State.BackColor = System.Drawing.Color.Red;
            this.plc2State.Location = new System.Drawing.Point(120, 257);
            this.plc2State.Name = "plc2State";
            this.plc2State.Size = new System.Drawing.Size(40, 40);
            this.plc2State.TabIndex = 3;
            this.plc2State.Click += new System.EventHandler(this.plc2State_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "PLC1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bağlantı Durumları";
            // 
            // plc1State
            // 
            this.plc1State.BackColor = System.Drawing.Color.Red;
            this.plc1State.Location = new System.Drawing.Point(120, 132);
            this.plc1State.Name = "plc1State";
            this.plc1State.Size = new System.Drawing.Size(40, 40);
            this.plc1State.TabIndex = 0;
            this.plc1State.Click += new System.EventHandler(this.plc1State_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(225, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1677, 100);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.setupCommunicationToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1677, 100);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.operatorPanelToolStripMenuItem});
            this.mainMenuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.mainMenuToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(134, 96);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // operatorPanelToolStripMenuItem
            // 
            this.operatorPanelToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.operatorPanelToolStripMenuItem.Name = "operatorPanelToolStripMenuItem";
            this.operatorPanelToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.operatorPanelToolStripMenuItem.Text = "Operator Panel";
            this.operatorPanelToolStripMenuItem.Click += new System.EventHandler(this.operatorPanelToolStripMenuItem_Click);
            // 
            // setupCommunicationToolStripMenuItem
            // 
            this.setupCommunicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setActiveDeactiveToolStripMenuItem});
            this.setupCommunicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.setupCommunicationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.setupCommunicationToolStripMenuItem.Name = "setupCommunicationToolStripMenuItem";
            this.setupCommunicationToolStripMenuItem.Size = new System.Drawing.Size(235, 96);
            this.setupCommunicationToolStripMenuItem.Text = "Setup Communication";
            // 
            // setActiveDeactiveToolStripMenuItem
            // 
            this.setActiveDeactiveToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.setActiveDeactiveToolStripMenuItem.Name = "setActiveDeactiveToolStripMenuItem";
            this.setActiveDeactiveToolStripMenuItem.Size = new System.Drawing.Size(254, 28);
            this.setActiveDeactiveToolStripMenuItem.Text = "Set Active/Deactive";
            this.setActiveDeactiveToolStripMenuItem.Click += new System.EventHandler(this.setActiveDeactiveToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(100, 96);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(103, 96);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.logOutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // control_panel
            // 
            this.control_panel.Controls.Add(this.groupBox2);
            this.control_panel.Controls.Add(this.groupBox1);
            this.control_panel.Controls.Add(this.button1);
            this.control_panel.Controls.Add(this.transferToPlc1_coils);
            this.control_panel.Controls.Add(this.transferToPlc2_coils);
            this.control_panel.Controls.Add(this.transferToPlc1);
            this.control_panel.Controls.Add(this.transferToPlc2);
            this.control_panel.Controls.Add(this.rc_checkBox);
            this.control_panel.Controls.Add(this.rh_textBox);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_panel.Location = new System.Drawing.Point(225, 100);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(1677, 876);
            this.control_panel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1420, 554);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // transferToPlc1_coils
            // 
            this.transferToPlc1_coils.Location = new System.Drawing.Point(1420, 151);
            this.transferToPlc1_coils.Name = "transferToPlc1_coils";
            this.transferToPlc1_coils.Size = new System.Drawing.Size(75, 23);
            this.transferToPlc1_coils.TabIndex = 5;
            this.transferToPlc1_coils.Text = "Aktar <<";
            this.transferToPlc1_coils.UseVisualStyleBackColor = true;
            this.transferToPlc1_coils.Click += new System.EventHandler(this.transferToPlc1_coils_Click);
            // 
            // transferToPlc2_coils
            // 
            this.transferToPlc2_coils.Location = new System.Drawing.Point(1420, 122);
            this.transferToPlc2_coils.Name = "transferToPlc2_coils";
            this.transferToPlc2_coils.Size = new System.Drawing.Size(75, 23);
            this.transferToPlc2_coils.TabIndex = 4;
            this.transferToPlc2_coils.Text = "Aktar >>";
            this.transferToPlc2_coils.UseVisualStyleBackColor = true;
            this.transferToPlc2_coils.Click += new System.EventHandler(this.transferToPlc2_coils_Click);
            // 
            // transferToPlc1
            // 
            this.transferToPlc1.Location = new System.Drawing.Point(1420, 93);
            this.transferToPlc1.Name = "transferToPlc1";
            this.transferToPlc1.Size = new System.Drawing.Size(75, 23);
            this.transferToPlc1.TabIndex = 3;
            this.transferToPlc1.Text = "Aktar <<";
            this.transferToPlc1.UseVisualStyleBackColor = true;
            this.transferToPlc1.Click += new System.EventHandler(this.transferToPlc1_Click);
            // 
            // transferToPlc2
            // 
            this.transferToPlc2.Location = new System.Drawing.Point(1420, 64);
            this.transferToPlc2.Name = "transferToPlc2";
            this.transferToPlc2.Size = new System.Drawing.Size(75, 23);
            this.transferToPlc2.TabIndex = 2;
            this.transferToPlc2.Text = "Aktar >>";
            this.transferToPlc2.UseVisualStyleBackColor = true;
            this.transferToPlc2.Click += new System.EventHandler(this.transferToPlc2_Click);
            // 
            // rc_checkBox
            // 
            this.rc_checkBox.AutoSize = true;
            this.rc_checkBox.Location = new System.Drawing.Point(1420, 38);
            this.rc_checkBox.Name = "rc_checkBox";
            this.rc_checkBox.Size = new System.Drawing.Size(105, 20);
            this.rc_checkBox.TabIndex = 1;
            this.rc_checkBox.Text = "TrueOrFalse";
            this.rc_checkBox.UseVisualStyleBackColor = true;
            // 
            // rh_textBox
            // 
            this.rh_textBox.Location = new System.Drawing.Point(1420, 6);
            this.rh_textBox.Name = "rh_textBox";
            this.rh_textBox.Size = new System.Drawing.Size(100, 22);
            this.rh_textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(1420, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 163);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Plc1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Plc2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 74);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(54, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Plc3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 100);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(54, 20);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Plc4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 126);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(54, 20);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Plc5";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Controls.Add(this.radioButton8);
            this.groupBox2.Controls.Add(this.radioButton9);
            this.groupBox2.Controls.Add(this.radioButton10);
            this.groupBox2.Location = new System.Drawing.Point(1420, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 163);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 126);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(54, 20);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Plc5";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.Click += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(6, 100);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(54, 20);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Plc4";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.Click += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(6, 74);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(54, 20);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Plc3";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.Click += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(6, 48);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(54, 20);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Plc2";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.Click += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(6, 21);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(54, 20);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Plc1";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            this.radioButton10.Click += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 976);
            this.Controls.Add(this.control_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "SettingsCommunication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statesPanel.ResumeLayout(false);
            this.statesPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.control_panel.ResumeLayout(false);
            this.control_panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

 


        #endregion
        private System.Windows.Forms.Panel statesPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupCommunicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label plc2State;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label plc1State;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setActiveDeactiveToolStripMenuItem;
        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label plc1_status;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Label plc2_status;
        private System.Windows.Forms.ToolStripMenuItem operatorPanelToolStripMenuItem;
        private System.Windows.Forms.TextBox rh_textBox;
        private System.Windows.Forms.CheckBox rc_checkBox;
        private System.Windows.Forms.Button transferToPlc2;
        private System.Windows.Forms.Button transferToPlc1;
        private System.Windows.Forms.Button transferToPlc1_coils;
        private System.Windows.Forms.Button transferToPlc2_coils;
        private System.Windows.Forms.Label plc3_status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label plc3State;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label plc5State;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label plc4State;
        private System.Windows.Forms.Label plc5_status;
        private System.Windows.Forms.Label plc4_status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

