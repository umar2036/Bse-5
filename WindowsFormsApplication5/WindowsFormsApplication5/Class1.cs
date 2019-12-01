using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication5
{
    class Student
    {
        public string id;
        public string name;
        public string cgpa;
        public string semester;
        public string department;
        public string university;
        public string attendance;
        public int flag;
        public int noOfStudents;
        public Student[] _students;
        public string s;
        public string[] strArr;
        public Student()
        {
            //s = "";
            strArr = new string[4];
            id = "";
            name = "";
            cgpa = "";
            semester = "";
            department = "";
            university = "";
            attendance = "NIL";
            flag = 0;
           
        }
        public void checkId(Student obj)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].id == obj.id)
                {
                    obj.flag = 0;
                }
                else
                {
                    obj.flag = 1;
                }
            }
        }
        public void checkGpa(Student obj)
        {

            if (Convert.ToDouble(obj.cgpa) > 4)
            {
                obj.flag = 0;
            }
            else
            {
                obj.flag = 1;
            }

        }
        public void checkDel(int k)
        {
            string ch = "n";
            header();
            studentPrint(k);
            Console.Write("Do you want to DELETE this Record:  (y/n) ");
            ch = Console.ReadLine();
            if (ch == "y" || ch == "Y")
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
        }
        public void deleteRecord(string st)
        {
            bool d = false;
            string del;
            int x = 0;
            del = st;
            for (int i = 0; i < _students.Length; i++)
            {
                if (del == _students[i].id)
                {
                    d = true;
                    x = i;
                    //checkDel(i);
                }
            }
            if (d == true)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Umar\Documents\Visual Studio 2015\Projects\WindowsFormsApplication5\WindowsFormsApplication5\Data.txt", false))
                {
                    for (int i = 0; i < _students.Length; i++)
                    {
                        if (i != x)
                        {
                            file.WriteLine(_students[i].id);
                            file.WriteLine(_students[i].name);
                            file.WriteLine(_students[i].cgpa);
                            file.WriteLine(_students[i].semester);
                            file.WriteLine(_students[i].department);
                            file.WriteLine(_students[i].university);
                            file.WriteLine(_students[i].attendance);
                        }
                    }
                    file.Close();
                }
            }

        }
        public void studentInput(Student obj)
        {
            Console.Write("Enter Id: ");
            obj.id = Console.ReadLine();
            checkId(obj);
            if (obj.flag == 1)
            {
                Console.Write("Enter Name: ");
                obj.name = Console.ReadLine();
                Console.Write("Enter CGPA: ");
                obj.cgpa = Console.ReadLine();
                checkGpa(obj);
                if (obj.flag == 1)
                {
                    Console.Write("Enter Semester: ");
                    obj.semester = Console.ReadLine();
                    Console.Write("Enter Department: ");
                    obj.department = Console.ReadLine();
                    Console.Write("Enter University: ");
                    obj.university = Console.ReadLine();
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"Data.txt", true))
                    {
                        file.WriteLine(obj.id);
                        file.WriteLine(obj.name);
                        file.WriteLine(obj.cgpa);
                        file.WriteLine(obj.semester);
                        file.WriteLine(obj.department);
                        file.WriteLine(obj.university);
                        file.WriteLine(obj.attendance);
                        file.Close();
                    }
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\t\t\tRecord Added Successfully!");
                }
                else
                {
                    Console.WriteLine("CGPA Can not Exceed 4!");
                }
            }
            else
            {
                Console.WriteLine("Id Must be Unique!");
            }
        }

        public string topStudent()
        {
            double[] arr = new double[_students.Length];
            double temp;
            if (_students.Length > 2)
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    arr[i] = Convert.ToDouble(_students[i].cgpa);
                }
            }
            else
            {
                Console.WriteLine("Number of Students are Less than 3!");
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            //header();
            for (int j = 0; j < 3; j++)
            {
                //printToppers(arr, i);

                for (int i = 0; i < _students.Length; i++)
                {
                    if (Convert.ToDouble(_students[i].cgpa) == arr[j])
                    {
                        s = s + "|     " + _students[i].id;
                        s = s + "      |        " + _students[i].name;
                        s = s + "     |   " + _students[i].cgpa;
                        s = s + "       |   " + _students[i].semester;
                        s = s + "       |   " + _students[i].department;
                        s = s + "       |   " + _students[i].university;
                        s = s + "       |   " + _students[i].attendance ;
                        s = s + "    |\n";
                    }
                }

            }
            return s;
        }
        public string printToppers(Double[] arr, int j)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (Convert.ToDouble(_students[i].cgpa) == arr[j])
                {
                    s=s+"|"+ _students[i].id;
                    s=s+ "|          "+ _students[i].name;
                    s = s + "" + _students[i].cgpa;
                    s = s + "" + _students[i].semester;
                    s = s + "" + _students[i].department;
                    s = s + "" + _students[i].university;
                    s = s + "" + _students[i].attendance;
                    s = s + "" + "|_____|________|________|___________|____________|______________|_____________|";
                }
            }
            return s;
        }
        public string veiwAttendance()
        {
  
            for (int i = 0; i < _students.Length; i++)
            {
                s = s + "|       " + _students[i].id;
                s = s + "             |    " + _students[i].name;
                s = s + "            |       " + _students[i].attendance;
                s = s + "      |\n";
                //studentPrintAttendance(_students, i);
            }
            return s;
        }
        //public void markAttendance()
        //{
        //   using (System.IO.StreamWriter file =
        //   new System.IO.StreamWriter(@"C:\Users\Umar\Documents\Visual Studio 2015\Projects\WindowsFormsApplication5\WindowsFormsApplication5\Data.txt", false))
        //    {
        //        for (int i = 0; i < _students.Length; i++)
        //        {
        //            textBox14.Text = _students[i].id;
        //            textBox15.Text = _students[i].name;
        //            if (radioButton1.Checked)
        //            {
        //                _students[i].attendance = "Present";
        //            }
        //            else if (radioButton1.Checked)
        //            {
        //                _students[i].attendance = "Absent";
        //            }
        //            file.WriteLine(_students[i].id);
        //            file.WriteLine(_students[i].name);
        //            file.WriteLine(_students[i].cgpa);
        //            file.WriteLine(_students[i].semester);
        //            file.WriteLine(_students[i].department);
        //            file.WriteLine(_students[i].university);
        //            file.WriteLine(_students[i].attendance);
        //        }
        //        file.Close();

        //    }
        //    Console.Clear();
        //    Console.WriteLine("\n\n\n\n\n\n\t\t\tAttendance Marked Successfully!");

        //}
        public void header()
        {
            Console.Clear();
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("                                 Students Record                           ");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("| Id  | Name   | CGPA   |  Semester | Department | University   |  Attendance |");
            Console.WriteLine("|_____|________|________|___________|____________|______________|_____________|");
        }
        public void studentSearch()
        {
            int option;
            bool flag = false;
            Console.WriteLine("Press one of the following: ");
            Console.WriteLine("\t\t1. For Search By Id");
            Console.WriteLine("\t\t2. For Search By Name");
            Console.WriteLine("\t\t3. For Display Records");
            Console.Write(" Your Choice: ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Console.Write("Enter the Id of Student to Search : ");
                string tempId = Console.ReadLine();
                header();
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].id == tempId)
                    {
                        studentPrint(i);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Record Not Found!");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the Name of Student to Search : ");
                string tempName = Console.ReadLine();
                header();
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].name == tempName)
                    {
                        flag = true;
                        studentPrint(i);
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Record Not Found!");
                }
            }
            else if (option == 3)
            {
                header();
                for (int i = 0; i < _students.Length; i++)
                {
                    studentPrint(i);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }

        }
        public void studentPrint(int i)
        {
            Console.Write("|{0,3:G}  |", _students[i].id);
            Console.Write("{0,7:G} |", _students[i].name);
            Console.Write("{0,6:G}  |", _students[i].cgpa);
            Console.Write("{0,7:G}    |", _students[i].semester);
            Console.Write("{0,10:G}  |", _students[i].department);
            Console.Write("{0,10:G}    |", _students[i].university);
            Console.WriteLine("{0,10:G}   |", _students[i].attendance);
            Console.WriteLine("|_____|________|________|___________|____________|______________|_____________|");

            // Console.WriteLine(_students[i].id + "       " + _students[i].name + "       " + _students[i].cgpa + "       " + _students[i].semester + "        " + _students[i].department + "        " + _students[i].university + "         " + _students[i].attendance);           
        }
        public string displayAll()
        {
            for (int i = 0; i < _students.Length; i++)
            {
                
                    s = s + "|     " + _students[i].id;
                    s = s + "      |        " + _students[i].name;
                    s = s + "     |   " + _students[i].cgpa;
                    s = s + "       |   " + _students[i].semester;
                    s = s + "       |   " + _students[i].department;
                    s = s + "       |   " + _students[i].university;
                    s = s + "       |   " + _students[i].attendance;
                    s = s + "    |\n";
                
            }
            return s;
        }
        public string searchByName(string n)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                s = " ";
                if (_students[i].name == n)
                {
                    s = s + "|     " + _students[i].id;
                    s = s + "      |        " + _students[i].name;
                    s = s + "     |   " + _students[i].cgpa;
                    s = s + "       |   " + _students[i].semester;
                    s = s + "       |   " + _students[i].department;
                    s = s + "       |   " + _students[i].university;
                    s = s + "       |   " + _students[i].attendance;
                    s = s + "    |\n";
                    break;
                }
                else
                {
                    s = "Record Not Fount";
                }
            }
            return s;
        }
        public string searchById(string n)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                s = " ";
                if (_students[i].id == n)
                {
                    s = s + "|     " + _students[i].id;
                    s = s + "      |        " + _students[i].name;
                    s = s + "     |   " + _students[i].cgpa;
                    s = s + "       |   " + _students[i].semester;
                    s = s + "       |   " + _students[i].department;
                    s = s + "       |   " + _students[i].university;
                    s = s + "       |   " + _students[i].attendance;
                    s = s + "    |\n";
                    break;
                }
                else
                {
                    s = "Record Not Found";
                }
            }
            return s;
        }
        public void mark(string s,int i)
        {
            _students[i].attendance = s;
        }
        public void markAtt(string[] s)
        {
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\Umar\Documents\Visual Studio 2015\Projects\WindowsFormsApplication5\WindowsFormsApplication5\Data.txt", true))
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    file.WriteLine(_students[i].id);
                    file.WriteLine(_students[i].name);
                    file.WriteLine(_students[i].cgpa);
                    file.WriteLine(_students[i].semester);
                    file.WriteLine(_students[i].department);
                    file.WriteLine(_students[i].university);
                    _students[i].attendance = s[i];
                    file.WriteLine(_students[i].attendance);
                }
                file.Close();

            }
        }

        public void reading()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Umar\Documents\Visual Studio 2015\Projects\WindowsFormsApplication5\WindowsFormsApplication5\Data.txt");
            noOfStudents = lines.Length / 7;
            int index = 0;
            Console.WriteLine(lines.Length);
            Student[] students = new Student[noOfStudents];
            for (int i = 0; i < noOfStudents; i++)
            {
                students[i] = new Student();
                students[i].id = lines[index];
                index++;
                students[i].name = lines[index];
                index++;
                students[i].cgpa = lines[index];
                index++;
                students[i].semester = lines[index];
                index++;
                students[i].department = lines[index];
                index++;
                students[i].university = lines[index];
                index++;
                students[i].attendance = lines[index];
                if (index < lines.Length)
                {
                    index++;
                }
            }
            _students = students;
        }
    }
}