using SQLExampleApp.Data;
using SQLExampleApp.Data.Tables;
using SQLExampleApp.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SQLExampleApp
{
    public partial class MainForm : Form
    {
        Point LastPoint;
        public MainForm()
        {
            InitializeComponent();
            refresh();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            using (var context = new Data.MYDBContext())
            {
                foreach (var x in context.Cars)
                {
                    dataGridView1.Rows.Add(x.Id, x.Name, x.Power);
                }
            }
        }

        private void DellButton_Click(object sender, EventArgs e)
        {
            using (var context = new Data.MYDBContext())
            {
                for (var i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    foreach (var x in context.Cars)
                    {
                        if ((int)dataGridView1.Rows[i].Cells[0].Value == x.Id)
                        {
                            if (dataGridView1.Rows[i].Cells[3].Value != null)
                            {
                                if ((bool)dataGridView1.Rows[i].Cells[3].Value)
                                {
                                    context.Cars.Remove(x);
                                }
                            }
                        }
                    }
                }
                context.SaveChanges();
                refresh();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var context = new Data.MYDBContext())
            {
                for (var i = 0; i < dataGridView1.Rows.Count - 1 ; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        context.Cars.Add(new Data.Tables.Car { Name = dataGridView1.Rows[i].Cells[1].Value.ToString(), Power = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) });
                    }
                    else
                    {
                        foreach (var x in context.Cars)
                        {
                            if ((int)dataGridView1.Rows[i].Cells[0].Value == x.Id)
                            {
                                if(x.Name != dataGridView1.Rows[i].Cells[1].Value.ToString())
                                    x.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                if(x.Power!= Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value))
                                    x.Power = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                            }
                        }
                    }
                }
                context.SaveChanges();
                refresh();
            }
        }

        private void EXITButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
    }
}
