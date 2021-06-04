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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int count = 1;
            string deleteid;
            deleteid = textBox1.Text;
            bool takjumpa=false;

            var tempdata = Path.GetTempFileName();   //to make file temporary name
            FileInfo fileInfo = new FileInfo(tempdata);  
            fileInfo.Attributes = FileAttributes.Temporary;

            List<string> line = new List<string>();   
           string ggPath = "db.txt";
            line = File.ReadAllLines(ggPath).ToList();

            foreach (string buang in line) //read line by line of the text file
            {
                string[] column = buang.Split(','); //to separate 1 line into 3 array 

                if (deleteid.ToLower().Replace(" ",string.Empty) != column[0].ToLower()) 
                {
                    //if the deleted id is not the same in the array [0], write the line into temporary file.
                    using (StreamWriter intext = new StreamWriter(tempdata, true))  
                    {
                        column[0] = "MCT" + count;
                        intext.WriteLine(column[0] + "," + column[1] + "," + column[2]);
                        count++;
                    }   
                    //set true into takjumpa if not same 
                    takjumpa = true;
                }
                if (deleteid.ToLower().Replace(" ", string.Empty) == column[0].ToLower())
                {
                    //set false into tak jumpa if same
                    takjumpa = false;
                }              
            }
            //after reading all line in the text, depend on the condition of tak jumpa, pop out the message box
            if (takjumpa == false)
            {
                MessageBox.Show(deleteid.Replace(" ", string.Empty).ToUpper() + " is succesfully delete");
            }
            else
            {             
                MessageBox.Show("The " + deleteid.Replace(" ", string.Empty).ToUpper() + " is not found. \nPlease refer in the view form");
            }
            
            File.Delete(@ggPath);           //to delete the old file which is ggpath
            File.Move(tempdata, ggPath);    //move the data from temporary file into new file name as the oldfile
            textBox1.Text = "";
        }

       
    }

               
}
    

