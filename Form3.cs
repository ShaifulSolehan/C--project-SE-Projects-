using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SE_project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Student Name", 100);
            listView1.Columns.Add("Matric No", 100);
            string Path ="db.txt";
            List<string> line = new List<string>();
            line = File.ReadAllLines(Path).ToList();    
            foreach (string viewing in line)        //accessing the list
            {
                string[] column = viewing.Split(',');
                ListViewItem itm; 
                itm = new ListViewItem(column[0]);
                for (int x = 1; x < 3; x++)
                {
                    itm.SubItems.Add(column[x]);
                }
                listView1.Items.Add(itm);   //view the added list view
            }
            
        }
    }
}
