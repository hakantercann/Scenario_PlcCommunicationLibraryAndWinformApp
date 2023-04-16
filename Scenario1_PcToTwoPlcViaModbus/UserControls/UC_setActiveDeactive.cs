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

namespace Scenario1_PcToTwoPlcViaModbus.UserControls
{
    public partial class UC_setActiveDeactive : UserControl
    {
        public UC_setActiveDeactive()
        {
            InitializeComponent();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            string text1 = "1;false;null;null;null;";
            string text2 = "2;false;null;null;null;";
            string text3 = "3;false;null;null;null;";
            if (checkBox1.Checked)
            {
                text1 = "1;true;" + plc1_ipAddress.Text + ";" + plc1_portNumber.Text + ";" + plc1_unitId.Text + ";";
            }
            if (checkBox2.Checked)
            {
                text2 = "2;true;" + plc2_ipAddress.Text + ";" + plc2_portNumber.Text + ";" + plc2_unitId + ";";
            }
            if (checkBox3.Checked)
            {
                text3 = "3;true;" + sql_ipAddress.Text + ";" + sql_portNumber.Text + ";" + Enum.GetName(typeof(SqlConnectionType), sql_connectionType.Items[sql_connectionType.SelectedIndex]) + ";";
            }
            Properties.Settings.Default.plc1 = text1;
            Properties.Settings.Default.plc2 = text2;
            Properties.Settings.Default.sql = text3;
            Properties.Settings.Default.Save();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            plc1_panel.Enabled = checkBox1.Checked;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            plc2_panel.Enabled = checkBox2.Checked;
        }

        private void UC_setActiveDeactive_Load(object sender, EventArgs e)
        {
            plc1_panel.Enabled = false;
            plc2_panel.Enabled = false;
            sql_panel.Enabled = false;
            string text1 = Properties.Settings.Default.plc1;
            string text2 = Properties.Settings.Default.plc2;
            string text3 = Properties.Settings.Default.sql;
            if (text1 != null || !text1.Equals(""))
            {
                var plc1Feature = text1.Split(';');
                if (Convert.ToBoolean(plc1Feature[1]))
                {
                    checkBox1.Checked = Convert.ToBoolean(plc1Feature[1]);
                    plc1_ipAddress.Text = plc1Feature[2];
                    plc1_portNumber.Text = plc1Feature[3];
                    plc1_unitId.Text = plc1Feature[4];
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
                    plc2_unitId.Text = plc2Feature[4];
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
                checkBox1.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            sql_panel.Enabled = checkBox3.Checked;
        }
    }
}
