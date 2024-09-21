using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.LinkLabel;

namespace Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                Pen pen = new Pen(Color.Black);
                int x = 300;
                int y = 300;
                double a = 0;
                List<comand> cmds = new List<comand>()
                {
                    new comand("Forward", "100"), 
                    new comand("Right", "90"),
                    new comand("Forward", "100"), 
                    new comand("Right", "90"),
                    new comand("Forward", "100"),
                    new comand("Right", "90"),
                    new comand("Forward", "100"),
                    new comand("Right", "90"),
                    new comand("Forward", "100"),
                    new comand("Left", "110"),
                    new comand("Forward", "100"),
                    new comand("Left", "125"),
                    new comand("Forward", "110"),
                };
                e.Graphics.Clear(Color.White);
                for (int i = 0; i < cmds.Count; i++)
                {
                    Point point1 = new Point(x, y);
                    if (cmds[i].key == "Right")
                        a += double.Parse(cmds[i].value);
                    if (cmds[i].key == "Forward")
                    {
                        x += (int)(int.Parse(cmds[i].value) * Math.Cos(a / 180 * Math.PI));
                        y += (int)(int.Parse(cmds[i].value) * Math.Sin(a / 180 * Math.PI));
                    }
                    if (cmds[i].key == "Left")
                        a -= double.Parse(cmds[i].value);
                    Point point2 = new Point(x, y);
                    e.Graphics.DrawLine(pen, point1, point2);
                }
            }
        }
        public class comand
        {
            public string key;
            public string value;
            public comand(string key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }