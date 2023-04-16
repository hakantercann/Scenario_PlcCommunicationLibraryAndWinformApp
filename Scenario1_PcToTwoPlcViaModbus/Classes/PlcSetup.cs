using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scenario1_PcToTwoPlcViaModbus.Classes
{
    public class PlcSetup
    {
        PlcModel model;
        public PlcSetup(PlcModel model) 
        { 
            this.model = model;
        }

        public void CreateTableLayoutPanel(Panel panel)
        {
            int height = 800;
            int width = 150;
            model.TablePanel.Location = new System.Drawing.Point(0, 0);
            model.TablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            model.TablePanel.AutoScroll = true;
            model.TablePanel.Size = new Size(width, height);
            model.TablePanel.ColumnCount = 3;
            model.TablePanel.RowCount = 100;
            model.TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            model.TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            model.TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                model.TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                model.TablePanel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                model.TextBoxes.Add(textBox);
                textBox.ReadOnly = true;
                model.TablePanel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(click_event_table);
                model.TablePanel.Controls.Add(btn, 2, i);
                panel.Controls.Add(model.TablePanel);

            }
            void click_event_table(object sender, EventArgs e)
            {
                Button button = (Button)sender;
                Console.WriteLine(button.Name.ToString());
                var startAddress = button.Name.ToString();
                string[] packet = new string[2]
                {
                "FC6",
                startAddress,
                };
            //    model.Client.WriteOneItem(packet, rh_textBox.Text);
            }
        }

    }
}
