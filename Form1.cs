﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Activity_01_Lab
{
    public partial class Form1 : Form
    {
 
        string Gender;
        string status;
        string Hobby;

        public Form1()
        {
            InitializeComponent();
        }

        private bool form_data_validation()
        {
            try
            {
                CustomerValidation cv = new CustomerValidation();
                cv.checkCustomerName(txt_cname.Text);
                cv.checkGender(radio_Male, radio_female);
                cv.checkHobby(chk_reading, chk_painting);
                cv.checkStatus(radio_married, radio_unmarried);



                if (radio_Male.Checked)
                    Gender = radio_Male.Text;
                else
                    Gender = radio_female.Text;

                if (chk_reading.Checked)
                    Hobby = "Reading";
                else
                    Hobby = "Painting";

                if (radio_married.Checked)
                    status = radio_married.Text;
                else
                    status = radio_unmarried.Text;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input Validation", MessageBoxButtons.OK);
                return false;
            }
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            if (form_data_validation())
            {
                frmCustomerPreview newf1 = new frmCustomerPreview();
                newf1.SetValues(txt_cname.Text, combo_country.Text, Gender, Hobby, status);
                newf1.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customerDataSet1.Identity' table. You can move, or remove it, as needed.
            this.identityTableAdapter1.Fill(this.customerDataSet1.Identity);
            // TODO: This line of code loads data into the 'customerDataSet.Identity' table. You can move, or remove it, as needed.
            this.identityTableAdapter.Fill(this.customerDataSet.Identity);
            loadCustomer();

            combo_country.Items.Add("Pakistan");
            combo_country.Items.Add("India");
            combo_country.Items.Add("Bangladesh");
            combo_country.Items.Add("America");
            combo_country.Items.Add("Srilanka");
            combo_country.SelectedIndex = 0;
        }


        private void loadCustomer()
        {
            try
            {
                string strconnection = "Data Source=AUMC-LAB3-11\\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True";


                SqlConnection objconnection = new SqlConnection(strconnection);

                string strcommand = "SELECT * FROM [Identity]"; 
                SqlCommand objCommand = new SqlCommand(strcommand, objconnection);

                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(objCommand);
                objadapter.Fill(objdataset);
                dtgCustomer.DataSource = objdataset.Tables[0];
                objconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occur", MessageBoxButtons.OK);
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (form_data_validation())
            {
                try
                {
                    string strconnection = "Data Source=AUMC-LAB3-11\\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True";
                    using (SqlConnection objconnection = new SqlConnection(strconnection))
                    {
                        string strcommand = "INSERT INTO [Identity] (Customer_Name, Country, Gender,Status,Hobbies) VALUES (@CustomerName, @Country, @Gender, @Hobby, @Status)";
                        using (SqlCommand objCommand = new SqlCommand(strcommand, objconnection))
                        {
                            objCommand.Parameters.AddWithValue("@CustomerName", txt_cname.Text);
                            objCommand.Parameters.AddWithValue("@Country", combo_country.Text);
                            objCommand.Parameters.AddWithValue("@Gender", Gender);
                            objCommand.Parameters.AddWithValue("@Hobby", Hobby);
                            objCommand.Parameters.AddWithValue("@Status", status);
                            objconnection.Open();
                            int rowsaffected = objCommand.ExecuteNonQuery();
                            if (rowsaffected > 0)
                            {
                                MessageBox.Show("Customer Data Saved Successfully", "Successful", MessageBoxButtons.OK);
                            }
                        }
                    }
                    loadCustomer();
                    clearForm();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"SQL Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"General Error: {ex.Message}", "Error Occur", MessageBoxButtons.OK);
                }
            }
        }




        private void clearForm()
        {
            txt_cname.Text = "";
            combo_country.Text = "";
            radio_Male.Checked = false;
            radio_female.Checked = false;
            chk_reading.Checked = false;
            chk_painting.Checked = false;
            radio_married.Checked = false;
            radio_unmarried.Checked = false;
        }

       private void btn_delete_Click(object sender, EventArgs e)
{
    try
    {
        CustomerValidation check = new CustomerValidation();
        check.checkCustomerName(txt_cname.Text);
        
        string strconnection = "Data Source=AUMC-LAB3-11\\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True";
        using (SqlConnection objconnection = new SqlConnection(strconnection))
        {
            string strcommand = "DELETE FROM [Identity] WHERE Customer_Name = @CustomerName";
            using (SqlCommand objCommand = new SqlCommand(strcommand, objconnection))
            {
                objCommand.Parameters.AddWithValue("@CustomerName", txt_cname.Text);
                objconnection.Open();
                int rowsaffected = objCommand.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    MessageBox.Show("Customer Data Deleted Successfully", "Successful", MessageBoxButtons.OK);
                }
            }
        }
        loadCustomer();
        clearForm();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error Occur", MessageBoxButtons.OK);
    }
}


        private void dtgCellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string CustomerName = dtgCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(CustomerName);
        }

        private void displayCustomer(string strCustomer)
        {
            // Open a Connection
            string strconnection = "Data Source=AUMC-LAB3-11\\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True";

            SqlConnection objConnection = new SqlConnection(strconnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "Select * From IdentityTable where CustomerName = '" + strCustomer + "'";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            // Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();
            txt_cname.Text = objDataSet.Tables[0].Rows[0][0].ToString();
            combo_country.Text = objDataSet.Tables[0].Rows[0][1].ToString();

            Gender = objDataSet.Tables[0].Rows[0][2].ToString();

            if (Gender.Equals("Male"))
                radio_Male.Checked = true;
            else
                radio_female.Checked = true;

            Hobby = objDataSet.Tables[0].Rows[0][3].ToString();

            if (Hobby.Equals("Reading"))
                chk_reading.Checked = true;
            else
                chk_painting.Checked = true;

            status = objDataSet.Tables[0].Rows[0][4].ToString();
            if (status.Equals("Married"))
                radio_married.Checked = true;
            else
                radio_unmarried.Checked = true;

        }

        private void dtgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.identityTableAdapter.FillBy(this.customerDataSet.Identity);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}