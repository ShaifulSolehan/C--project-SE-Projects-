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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool notfound=true;
            int count=0;
            string output;
            string findingname;
            findingname = textBox2.Text.ToLower(); 
            string Path = "db.txt";
            List<string> line = new List<string>();
            List<string> samename = new List<string>();   //list to printing the list
            line = File.ReadAllLines(Path).ToList();
            foreach (string finding in line)
            {
                
                string[] column = finding.Split(',');
                if (findingname.ToLower() == column[1].ToLower() && count != line.Count()) //check the name search same in the text file
                {
                    samename.Add("Name " + column[1] + " with Matric No. " + column[2]);  
                    notfound = false;
                }

            }
            if (notfound == false)
            {
                output = string.Join("\n", samename); //printing the list
                MessageBox.Show("Found " + "\n" + "\n" + output);
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Name " + findingname + " not found");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
