using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentRegistration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CourseRegistration;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.textname.Text = "";
            this.textfname.Text = "";
            this.textmname.Text = "";
            this.textphone.Text = "";
            this.textemail.Text = "";
            this.textadd.Text = "";
            this.textpin.Text = "";
            this.textcdur.Text = "";


        }


        private void button2_Click(object sender, EventArgs e)
        {
            string gender;
            string name =textname.Text;

            if(name==""){
                MessageBox.Show("Please fill information!!");
            }
            else{
            if (btnMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            con.Open();
            String query = "insert into sregistration(Name,Fname,Mname,Mno,email,address,gender,Dob,pincode,cname,cdur,Dor) VALUES('" + textname.Text + "','" + textfname.Text + "','" + textmname.Text + "','" + textphone.Text + "','" + textemail.Text + "','" + textadd.Text + "','" + gender + "','" + this.dateTimePicker1.Text + "','" + textpin.Text + "','" + comboBox1.Text + "','" + textcdur.Text + "','" + this.dateTimePicker2.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Save Succesfully :");
            con.Close();

            }


        }


        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select *from sregistration";
            SqlDataAdapter adb = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            adb.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from sregistration where Name = '" + textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("Deleted information !!!!!");
            }
            else
            {
                MessageBox.Show("Failed to Delete Data!!!!!!!!!!");
            }

            con.Close();

        }
    }
}
