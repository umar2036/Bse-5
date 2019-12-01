using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {

        public string id;
        public string name;
        public string cgpa;
        public string semester;
        public string department;
        public string university;
        public string attendance;
        public int flag;
        public string s;
        public int n;
        public string[] tempStr;
        // Student[] _students;
        public Form1()
        {
            //Student std = new Student();
            InitializeComponent();
            panel1.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel10.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            label19.Visible = false;
            textBox7.Visible = false;
            button18.Visible = false;
            label34.Visible = false;
            textBox8.Visible = false;
            button19.Visible = false;
           // panel3.Size();
            //string[] tempStr = new string[std.noOfStudents];
            //s = "";
            //id = "";
            //name = "";
            //cgpa = "";
            //semester = "";
            //department = "";
            //university = "";
            //attendance = "NIL";
            //flag = 0;

        }
        //public void reading()
        //{
        //    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Umar\Documents\Visual Studio 2015\Projects\ConsoleApplication8\ConsoleApplication8\Data.txt");
        //    int noOfStudents = lines.Length / 6;
        //    int index = 0;
        //    Console.WriteLine(lines.Length);
        //    Student[] students = new Student[noOfStudents];
        //    for (int i = 0; i < noOfStudents; i++)
        //    {
        //        students[i] = new Student();
        //        students[i].id = lines[index];
        //        index++;
        //        students[i].name = lines[index];
        //        index++;
        //        students[i].cgpa = lines[index];
        //        index++;
        //        students[i].semester = lines[index];
        //        index++;
        //        students[i].department = lines[index];
        //        index++;
        //        students[i].university = lines[index];
        //        index++;
        //        students[i].attendance = lines[index];
        //        if (index < lines.Length)
        //        {
        //            index++;
        //        }
        //    }
        //    _students = students;
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
          

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.reading();
            
            panel3.Visible = false;
            s = " ";
            s = std.topStudent();
            richTextBox4.Text = s;
            panel7.Visible = true;



        }

        private void button6_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.reading();
            //std.veiwAttendance();
            panel6.Visible = true;
            panel3.Visible = false;
            string temp = std.veiwAttendance();
            richTextBox2.Text = temp;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Fill The Required Field*");
            }
            else
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Umar\Documents\Visual Studio 2015\Projects\WindowsFormsApplication5\WindowsFormsApplication5\Data.txt", true))
                {
                    file.WriteLine(textBox1.Text);
                    file.WriteLine(textBox2.Text);
                    file.WriteLine(textBox4.Text);
                    file.WriteLine(textBox3.Text);
                    file.WriteLine(textBox5.Text);
                    file.WriteLine(textBox6.Text);
                    file.WriteLine("NULL");
                    file.Close();
                }
            }
            panel3.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.reading();
            
            s = " ";
            s = std.displayAll();
            richTextBox4.Text = s;
            label34.Visible = false;
            textBox8.Visible = false;
            button19.Visible = false;
            label19.Visible = false;
            textBox7.Visible = false;
            button18.Visible = false;
            panel7.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label34.Visible = false;
            textBox8.Visible = false;
            button19.Visible = false;
            label19.Visible = true;
            textBox7.Visible = true;
            button18.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.reading();
            s = "";
            s = std.searchByName(textBox7.Text);
            richTextBox4.Text = s;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label19.Visible = false;
            textBox7.Visible = false;
            button18.Visible = false;
            label34.Visible = true;
            textBox8.Visible = true;
            button19.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.reading();
            s = " ";
            s = std.searchById(textBox8.Text);
            richTextBox4.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel3.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.reading();
            s = " ";
            s = std.searchById(textBox9.Text);
            richTextBox4.Text = s;
            std.deleteRecord(textBox9.Text);
            if (richTextBox4.Text == "Record Not Found")
            {
                MessageBox.Show("Record Not Found!");
            }
            else
            {
                MessageBox.Show("Record Deleted Successfully!");
            }
            richTextBox4.Text = " ";
        }
        int z = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            
            Student std = new Student();
            std.reading();

            if (z < std.noOfStudents)
            {
                textBox14.Text = std._students[z].id;
                textBox15.Text = std._students[z].name;
                std._students[z].attendance = textBox10.Text;

                std.strArr[z] = std._students[z].attendance;
                    richTextBox2.Text += textBox14.Text + "             ";
                    richTextBox2.Text += textBox15.Text + "           ";
                    richTextBox2.Text += textBox10.Text + "\n";
                    std.mark(textBox10.Text, z);
                    z++;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    
            }
            else
            {
                
                MessageBox.Show("Marked Successfully!");
                panel6.Visible = true;
                z = 0;
               
            }
            textBox10.Text = "";

        }
        //public string[] tempArr=new string(n);

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Text = "Present";
            //z++;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox10.Text = "Absent";
            //z++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            Student std = new Student();
            std.reading();
            textBox14.Text = std._students[z].id;
            textBox15.Text = std._students[z].name;
            panel3.Visible = false;
            //z++;
            //public string[] tempArr = new string[std];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel10.Visible = true;
            panel3.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel10.Visible = true;
        }
    }
}

