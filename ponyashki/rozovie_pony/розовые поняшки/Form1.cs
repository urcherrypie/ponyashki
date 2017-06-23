using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace розовые_поняшки
{
  
        public partial class Form1 : Form
        {
        int a = 1;
        public Form1()
            {
                InitializeComponent();
            }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Process [] procs;

            private void GetProcesses()
            {
                procs = Process.GetProcesses();
           
                if (Convert.ToInt32(label2.Text) != procs.Length) // Check if new processes have been started or terminated
                {
                
                    label2.Text = procs.Length.ToString();
                for (int i = 0; i < procs.Length; i++) // Цикл добавления строк
                {
                    this.dataGridView1.Rows.Add();  // добавление строки 
                }
                
                    for (int i = 0; i < procs.Length; i++)
                    {
                        try
                        {
                            this.dataGridView1.Rows[i].Cells[0].Value = procs[i].ProcessName;
                            double mega = (procs[i].NonpagedSystemMemorySize64 + procs[i].PagedMemorySize64) / 1000000.0;
                            this.dataGridView1.Rows[i].Cells[1].Value = mega;
                            this.dataGridView1.Rows[i].Cells[2].Value = procs[i].HandleCount;
                            this.dataGridView1.Rows[i].Cells[3].Value = procs[i].EnableRaisingEvents;
                            this.dataGridView1.Rows[i].Cells[4].Value = procs[i].Id;

                    }
                        catch 
                        {
                            MessageBox.Show(" Помилка!!! ");
                        }
                    }
                }
                 else
            {
                MessageBox.Show(" :) ");
            }
        }
            private void Form1_Load(object sender, EventArgs e)
            {
                GetProcesses();
            
        }

            // Check every 1 second for changes in the processes list
            private void timer1_Tick(object sender, EventArgs e)
            {
                GetProcesses();
            }
        
        private void button1_Click_1(object sender, EventArgs e)
        {

            int x;
            int delet = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delet);
            procs[dataGridView1.SelectedCells[0].RowIndex].Kill();
            x = procs.Length - a;
            a++;
            label2.Text = x.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }



    

