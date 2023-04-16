using DynamicCommunication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicCommunication.Pages
{
    public partial class SetActiveDeactiveForm : Form
    {
        private DataTable db; 
        private System.Collections.Specialized.StringCollection _devices;
        public SetActiveDeactiveForm()
        {
            InitializeComponent();
            _devices = Properties.Settings.Default.plcs;
            dataGridView1.ColumnCount = 4;
            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[0].HeaderText = "Plc ID";
            dataGridView1.Columns[1].HeaderText = "Plc Name";
            dataGridView1.Columns[2].HeaderText = "Plc Ip";
            dataGridView1.Columns[3].HeaderText = "Plc Port";
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetNames(typeof(PlcConnectionType));
            combo.HeaderText = "Plc Connection Type";
            dataGridView1.Columns.Add(combo);
            foreach (var item in _devices)
            {

                var features = item.Split(';');
                DataGridViewRow dataRow = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dataRow.Cells[0].Value = features[0];
                dataRow.Cells[1].Value = features[1];
                dataRow.Cells[2].Value = features[2];
                dataRow.Cells[3].Value = features[3];
                dataRow.Cells[4].Value = features[4];
                dataGridView1.Rows.Add(dataRow);

            }
        }

        private void SetActiveDeactiveForm_Load(object sender, EventArgs e)
        {
            if(_devices.Count > 0)
            {

            }

        }

        private void _setButton_Click(object sender, EventArgs e)
        {
            var sizeOfDataGridView = dataGridView1.Rows.Count -1;
            Properties.Settings.Default.plcs.Clear();
            _devices.Clear();
            for(int i = 0; i < sizeOfDataGridView; i++)
            {
                var newReg = dataGridView1.Rows[i].Cells[0].Value.ToString() + ";" + dataGridView1.Rows[i].Cells[1].Value.ToString() + ";" + dataGridView1.Rows[i].Cells[2].Value.ToString() + ";" + dataGridView1.Rows[i].Cells[3].Value.ToString() + ";" + dataGridView1.Rows[i].Cells[4].Value.ToString();
                _devices.Insert(i, newReg);
            }
            Properties.Settings.Default.plcs = _devices;
            Properties.Settings.Default.Save();
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
           int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if(selectedRowCount > 0)
            {
                for(int i = 0; i < selectedRowCount; i++)
                {
      
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
         
        }

    }
}
