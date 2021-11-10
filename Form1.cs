using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace LabOOP2WinForms
{
    public partial class Form1 : Form
    {            
        string path = "Library.xml";
        public Form1()
        {
            InitializeComponent();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            //string path = @"C:\Users\yasma\Desktop\Library.xml";
            Output.Clear();
            Library _problem = OurLibrary();
            if (LINQButton.Checked)
            {
                XMLProcessor CurrentStrategy = new LINQtoXML(path);
                List<Library> final = new List<Library>();
                final = CurrentStrategy.Algorithm(_problem, path);
                PrintOutput(final);
            } else if (DOMButton.Checked)
            {
                XMLProcessor CurrentStrategy = new DOMModel(path);
                List<Library> final = new List<Library>();
                final = CurrentStrategy.Algorithm(_problem, path);
                PrintOutput(final);
            } else if (SAXButton.Checked)
            {
                XMLProcessor CurrentStrategy = new SAXSearch(path);
                List<Library> final = new List<Library>();
                final = CurrentStrategy.Algorithm(_problem, path);
                PrintOutput(final);
            }
        }

        private Library OurLibrary()
        {
            string[] information = new string[7];
            if (AuthorName.Checked) information[0] = Convert.ToString(AuthorNameBox.Text);
            if (BookName.Checked) information[1] = Convert.ToString(BookNameBox.Text);
            if (Anotation.Checked) information[2] = Convert.ToString(AnotationBox.Text);
            if (QualificationProperties.Checked) information[3] = Convert.ToString(QualificationBox.Text);
            if (Faculty.Checked) information[4] = Convert.ToString(FacultyBox.Text);
            if (Department.Checked) information[5] = Convert.ToString(DepartmentBox.Text);
            if (Position.Checked) information[6] = Convert.ToString(PositionBox.Text);
            return new Library(information);
        }
        private void PrintOutput(List<Library> final)
        {
            int i = 1;
            Console.WriteLine("Alg+");
            foreach(Library pr in final)
            {
                Output.AppendText(i++ + "." + "\n");
                Output.AppendText("Author name: " + pr.AuthorName + "\n");
                Output.AppendText("Book name: " + pr.BookName + "\n");
                Output.AppendText("Anotation: " + pr.Anotation + "\n");
                Output.AppendText("Qualification properties: " + pr.QualificationProperties + "\n");
                Output.AppendText("Faculty: " + pr.Faculty + "\n");
                Output.AppendText("Department: " + pr.Department + "\n");
                Output.AppendText("Position:  " + pr.Position + "\n");
            }
        }

        private void Transform_Click(object sender, EventArgs e)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(@"C:\Users\yasma\source\repos\LabOOP2WinForms\bin\Debug\net5.0-windows\stylesheet.xsl");
            string input = @"C:\Users\yasma\source\repos\LabOOP2WinForms\bin\Debug\net5.0-windows\Root.xml";
            string result = @"C:\Users\yasma\source\repos\LabOOP2WinForms\bin\Debug\net5.0-windows\Root.html";
            xslt.Transform(input, result);
        }
    }
}
