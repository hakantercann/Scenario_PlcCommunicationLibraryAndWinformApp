using Scenario1_PcToTwoPlcViaModbus.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scenario1_PcToTwoPlcViaModbus.Pages
{
    public partial class SettingsCommunication : Form
    {
        public SettingsCommunication()
        {
            InitializeComponent();
            plc1_comboBox.DataSource = Enum.GetValues(typeof(PlcConnectionType));
            plc2_comboBox.DataSource = Enum.GetValues(typeof(PlcConnectionType));
            plc3_comboBox.DataSource = Enum.GetValues(typeof(PlcConnectionType));
            plc3_comboBox.DataSource = Enum.GetValues(typeof(PlcConnectionType));
            plc4_comboBox.DataSource = Enum.GetValues(typeof(PlcConnectionType));
            plc5_comboBox.DataSource = Enum.GetValues(typeof(PlcConnectionType));
            plc1_comboBox.SelectedIndex = 0;
            plc2_comboBox.SelectedIndex = 0;
            plc3_comboBox.SelectedIndex = 0;
            plc4_comboBox.SelectedIndex = 0;
            plc5_comboBox.SelectedIndex = 0;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            string text1 = "1;false;null;null;none;";
            string text2 = "2;false;null;null;none;";
            string text3 = "3;false;null;null;none;";
            string text4 = "4;false;null;null;none;";
            string text5 = "5;false;null;null;none;";
            string text6 = "6;false;null;null;none;";
            if (checkBox1.Checked)
            {
                text1 = "1;true;" + plc1_ipAddress.Text + ";" + plc1_portNumber.Text + ";" + Enum.GetName(typeof(PlcConnectionType), plc1_comboBox.SelectedIndex) + ";";
            }
            if (checkBox2.Checked)
            {
                text2 = "2;true;" + plc2_ipAddress.Text + ";" + plc2_portNumber.Text + ";" + Enum.GetName(typeof(PlcConnectionType), plc2_comboBox.SelectedIndex) + ";";
            }
            if (checkBox3.Checked)
            {
                text3 = "3;true;" + sql_ipAddress.Text + ";" + sql_portNumber.Text + ";" + Enum.GetName(typeof(SqlConnectionType), sql_connectionType.Items[sql_connectionType.SelectedIndex]) + ";";
            }
            if (checkBox4.Checked)
            {
                text4 = "4;true;" + plc3_ipAddress.Text + ";" + plc3_portNumber.Text + ";" + Enum.GetName(typeof(PlcConnectionType), plc3_comboBox.Items[plc3_comboBox.SelectedIndex]) + ";";
            }
            if (checkBox5.Checked)
            {
                text5 = "5;true;" + plc4_ipAddress.Text + ";" + plc4_portNumber.Text + ";" + Enum.GetName(typeof(PlcConnectionType), plc4_comboBox.Items[plc4_comboBox.SelectedIndex]) + ";";
            }
            if (checkBox6.Checked)
            {
                text6 = "6;true;" + plc5_ipAddress.Text + ";" + plc5_portNumber.Text + ";" + Enum.GetName(typeof(PlcConnectionType), plc5_comboBox.Items[plc5_comboBox.SelectedIndex]) + ";";
            }
            Properties.Settings.Default.plc1 = text1;
            Properties.Settings.Default.plc2 = text2;
            Properties.Settings.Default.sql = text3;
            Properties.Settings.Default.plc3 = text4;
            Properties.Settings.Default.plc4 = text5;
            Properties.Settings.Default.plc5 = text6;
            Properties.Settings.Default.Save();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plc1_panel.Enabled = false;
            plc2_panel.Enabled = false;
            plc3_panel.Enabled = false;
            plc4_panel.Enabled = false;
            plc5_panel.Enabled = false;
            sql_panel.Enabled = false;
            string text1 = Properties.Settings.Default.plc1;
            string text2 = Properties.Settings.Default.plc2;
            string text3 = Properties.Settings.Default.sql;

            string text4 = Properties.Settings.Default.plc3;
            string text5 = Properties.Settings.Default.plc4;
            string text6 = Properties.Settings.Default.plc5;
            if (text1 != null || !text1.Equals(""))
            {
                var plc1Feature = text1.Split(';');
                if (Convert.ToBoolean(plc1Feature[1]))
                {
                    checkBox1.Checked = Convert.ToBoolean(plc1Feature[1]);
                    plc1_ipAddress.Text = plc1Feature[2];
                    plc1_portNumber.Text = plc1Feature[3];
                    plc1_comboBox.SelectedIndex = (int)Enum.Parse(typeof(PlcConnectionType), plc1Feature[4]);
                }
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (text2 != null || !text2.Equals(""))
            {
                var plc2Feature = text2.Split(';');
                if (Convert.ToBoolean(plc2Feature[1]))
                {
                    checkBox2.Checked = Convert.ToBoolean(plc2Feature[1]);
                    plc2_ipAddress.Text = plc2Feature[2];
                    plc2_portNumber.Text = plc2Feature[3];
                    plc2_comboBox.SelectedIndex = (int)Enum.Parse(typeof(PlcConnectionType), plc2Feature[4]);
                }
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (text3 != null || !text3.Equals(""))
            {
                var sqlFeature = text3.Split(';');
                if (Convert.ToBoolean(sqlFeature[1]))
                {
                    checkBox3.Checked = Convert.ToBoolean(sqlFeature[1]);
                    sql_ipAddress.Text = sqlFeature[2];
                    sql_portNumber.Text = sqlFeature[3];
                }
            }

            else
            {
                checkBox3.Checked = false;
            }
            if (text4 != null || !text4.Equals(""))
            {
                var plc3Feature = text4.Split(';');
                if (Convert.ToBoolean(plc3Feature[1]))
                {
                    checkBox4.Checked = Convert.ToBoolean(plc3Feature[1]);
                    plc3_ipAddress.Text = plc3Feature[2];
                    plc3_portNumber.Text = plc3Feature[3];
                    plc3_comboBox.SelectedIndex = (int)Enum.Parse(typeof(PlcConnectionType), plc3Feature[4]);
                }
            }
            else
            {
                checkBox4.Checked = false;
            }
            if (text5 != null || !text5.Equals(""))
            {
                var plc4Feature = text5.Split(';');
                if (Convert.ToBoolean(plc4Feature[1]))
                {
                    checkBox5.Checked = Convert.ToBoolean(plc4Feature[1]);
                    plc4_ipAddress.Text = plc4Feature[2];
                    plc4_portNumber.Text = plc4Feature[3];
                    plc4_comboBox.SelectedIndex = (int)Enum.Parse(typeof(PlcConnectionType), plc4Feature[4]);
                }
            }
            else
            {
                checkBox5.Checked = false;
            }
            if (text6 != null || !text6.Equals(""))
            {
                var plc5Feature = text6.Split(';');
                if (Convert.ToBoolean(plc5Feature[1]))
                {
                    checkBox6.Checked = Convert.ToBoolean(plc5Feature[1]);
                    plc5_ipAddress.Text = plc5Feature[2];
                    plc5_portNumber.Text = plc5Feature[3];
                    plc5_comboBox.SelectedIndex = (int)Enum.Parse(typeof(PlcConnectionType), plc5Feature[4]);
                }
            }
            else
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            plc1_panel.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            plc2_panel.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            sql_panel.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            plc3_panel.Enabled = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            plc4_panel.Enabled = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            plc5_panel.Enabled = checkBox6.Checked;
        }
    }
}
