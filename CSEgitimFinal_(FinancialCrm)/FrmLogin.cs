using CSEgitimFinal__FinancialCrm_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEgitimFinal__FinancialCrm_
{

    public partial class FrmLogin: Form
    {
        string connectionString = "Data Source=FURKAN\\SQLEXPRESS;Initial Catalog=FinancialCrm;integrated security = True";
        
        public FrmLogin()
        {
            InitializeComponent();
            FinancialCrmEntities4 db = new FinancialCrmEntities4();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @KullaniciAdi AND Password = @Sifre";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", txtUsername.Text);
                    command.Parameters.AddWithValue("@Sifre", txtPassword.Text);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        
                        FrmDashboard anaForm = new FrmDashboard();
                        anaForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Password) VALUES (@KullaniciAdi, @Sifre)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", txtUsername.Text);
                    command.Parameters.AddWithValue("@Sifre", txtPassword.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hesabınızı silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE Username = @KullaniciAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciAdi", txtUsername.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Hesap silindi.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}

