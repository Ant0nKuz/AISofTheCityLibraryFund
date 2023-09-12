using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["key"].ConnectionString);

            sqlConnection.Open();



            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                          "SELECT Surname, Name, TitleOfThePublication FROM Readers, Publication, Readings WHERE Publication.EditionId = Readings.EditionId AND Readers.ReaderId = Readings.ReaderId ",
                           sqlConnection);

            DataSet db = new DataSet();
            dataAdapter.Fill(db);
            dataGridView3.DataSource = db.Tables[0];

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(
                          "SELECT Surname, Name, DateRegistration FROM Readers",
                           sqlConnection);

            DataSet db1 = new DataSet();
            dataAdapter1.Fill(db1);
            dataGridView2.DataSource = db1.Tables[0];

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(
                          "SELECT Surname, Name, TitleOfThePublication, DateofIssue, DateOfReturn FROM Readers, Readings , Publication WHERE Publication.EditionId = Readings.EditionId AND Readers.ReaderId = Readings.ReaderId",
                           sqlConnection);

            DataSet db2 = new DataSet();
            dataAdapter2.Fill(db2);
            dataGridView4.DataSource = db2.Tables[0];

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            SqlDataAdapter dataAdapter8 = new SqlDataAdapter(
                        "SELECT Title, Address, LastNameOfTheLibrarian, NameOfTheLibrarian FROM Libraries , Librarians WHERE Libraries.LibraryId = Librarians.LibraryId",
                         sqlConnection);

            DataSet db8 = new DataSet();
            dataAdapter8.Fill(db8);
            dataGridView5.DataSource = db8.Tables[0];

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           
            SqlDataAdapter dataAdapter6 = new SqlDataAdapter(
                        "SELECT P.EditionId, P.TitleOfThePublication, R.DateOfIssue, R.DateOfReturn FROM Publication P JOIN Readings R ON P.EditionId = R.EditionId JOIN Librarians L ON L.LibraryId = L.LibraryId WHERE L.LibraryId = '2' AND (R.DateOfIssue BETWEEN '2023-05-08' AND '2023-09-16') OR (R.DateOfReturn BETWEEN 'початкова дата' AND 'кінцева дата')",
                         sqlConnection);

            DataSet db6 = new DataSet();
            dataAdapter6.Fill(db6);
            dataGridView6.DataSource = db6.Tables[0];
            
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            SqlDataAdapter dataAdapter7 = new SqlDataAdapter(
                        "SELECT P.EditionId, P.TitleOfThePublication, R.DateOfIssue, R.DateOfReturn FROM Publication P LEFT JOIN Readings R ON P.EditionId = R.EditionId WHERE (R.DateOfIssue BETWEEN '2023-04-08' AND '2023-09-08') OR (R.DateOfReturn BETWEEN 'початкова дата' AND 'кінцева дата')",
                         sqlConnection);

            DataSet db7 = new DataSet();
            dataAdapter7.Fill(db7);
            dataGridView7.DataSource = db7.Tables[0];

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlDataAdapter dataAdapter9 = new SqlDataAdapter(
                                   "SELECT ReaderId , r.Surname, r.Name FROM Readers r WHERE r.ReaderId NOT IN (SELECT DISTINCT c.ReaderId FROM Readings c WHERE c.DateofIssue BETWEEN '2023-03-25' AND '2023-08-25')",
                                    sqlConnection);

            DataSet db9 = new DataSet();
            dataAdapter9.Fill(db9);
            dataGridView8.DataSource = db9.Tables[0];



            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           
            SqlDataAdapter dataAdapter11 = new SqlDataAdapter(
                                    "SELECT p.EditionId AS PublicationID, p.TitleOfThePublication AS TitlePublication, COUNT(r.ReaderId) AS NumberReadings FROM Publication p JOIN Readings r ON p.EditionId = r.ReaderId WHERE r.DateOfIssue BETWEEN '2023-03-25' AND '2023-08-23' GROUP BY p.EditionId, p.TitleOfThePublication",
                                     sqlConnection);
            DataSet db11 = new DataSet();
            dataAdapter11.Fill(db11);
            dataGridView10.DataSource = db11.Tables[0];

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            SqlDataAdapter dataAdapter10 = new SqlDataAdapter(
                                    "SELECT EditionId, TitleOfThePublication, Autor FROM Publication",
                                     sqlConnection);
            DataSet db10 = new DataSet();
            dataAdapter10.Fill(db10);
            dataGridView9.DataSource = db10.Tables[0];
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT Surname, Name, Category, CategoryAttribute  FROM Readers",
                sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];   
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"TitleOfThePublication LIKE '%{textBox1.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Surname LIKE '%{textBox2.Text}%'";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = $"DateRegistration LIKE '%{textBox3.Text}%'";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"DateofIssue LIKE '%{textBox4.Text}%'" ; 
            
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            (dataGridView5.DataSource as DataTable).DefaultView.RowFilter = $"Title LIKE '%{textBox5.Text}%'";
        }  
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            (dataGridView9.DataSource as DataTable).DefaultView.RowFilter = $"TitleOfThePublication LIKE '%{textBox10.Text}%'";
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            (dataGridView9.DataSource as DataTable).DefaultView.RowFilter = $"Autor LIKE '%{textBox12.Text}%'";
        }







        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
