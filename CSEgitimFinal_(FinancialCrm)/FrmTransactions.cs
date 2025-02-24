using CSEgitimFinal__FinancialCrm_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEgitimFinal__FinancialCrm_
{
    public partial class FrmTransactions : Form
    {
        public FrmTransactions()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=FURKAN\\SQLEXPRESS;Initial Catalog=FinancialCrm;integrated security = True";
        FinancialCrmEntities4 db = new FinancialCrmEntities4();

        public class BankProcessDTO
        {
            public int? Id { get; set; }
            public string ProcessType { get; set; }
            public DateTime? ProcessDate { get; set; }
            public decimal? Amount { get; set; }
            public string BankTitle { get; set; }
            public string Description { get; set; }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "ID", DisplayIndex = 0 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Description", HeaderText = "Açıklama", DisplayIndex = 1 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ProcessType", HeaderText = "İşlem Türü", DisplayIndex = 2 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ProcessDate", HeaderText = "İşlem Tarihi", DisplayIndex = 3 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Amount", HeaderText = "Tutar", DisplayIndex = 4 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "BankTitle", HeaderText = "Banka Adı", DisplayIndex = 5 });

            var values = (from bp in db.BankProcesses
                          join b in db.Banks on bp.BankID equals b.BankaID
                          select new BankProcessDTO
                          {
                              Id = bp.BankProcess,
                              ProcessType = bp.ProcessType,
                              ProcessDate = bp.ProcessDate,
                              Amount = bp.Amount,
                              BankTitle = b.BankTitle,
                              Description = bp.Description
                          }).ToList();

            dataGridView1.DataSource = values;
        }

        private void FrmTransactions_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BankTitle, BankaID FROM Banks";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable bankalar = new DataTable();
                        adapter.Fill(bankalar);
                        comboChoseBankAccount.DataSource = bankalar;
                        comboChoseBankAccount.DisplayMember = "BankTitle";
                        comboChoseBankAccount.ValueMember = "BankaID";
                    }
                }
            }
            btnList_Click(sender, e);
        }

        private void btnDoProcess_Click(object sender, EventArgs e)
        {
            int bankaId = 0;
            decimal tutar = 0;
            string islemTuru = txtProcessType.Text.Trim();
            string aciklama = txtDescription.Text.Trim();

            if (comboChoseBankAccount.SelectedValue != null && int.TryParse(comboChoseBankAccount.SelectedValue.ToString(), out bankaId) && decimal.TryParse(txtAmount.Text, out tutar) && !string.IsNullOrWhiteSpace(islemTuru) && !string.IsNullOrWhiteSpace(aciklama))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO BankProcesses (BankID, Amount, ProcessType, Description, ProcessDate) VALUES (@BankaId, @Tutar, @IslemTuru, @Aciklama, @IslemTarihi)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BankaId", bankaId);
                        command.Parameters.AddWithValue("@Tutar", tutar);
                        command.Parameters.AddWithValue("@IslemTuru", islemTuru);
                        command.Parameters.AddWithValue("@Aciklama", aciklama);
                        command.Parameters.AddWithValue("@IslemTarihi", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("İşlem başarıyla eklendi.");
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun.");
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 72)
            {
                panel1.Width = 223;
                paneltransactions.Location = new Point(223, paneltransactions.Location.Y); 
                paneltransactions.Width = this.ClientSize.Width - 223; 
            }
            else
            {
                panel1.Width = 72;
                paneltransactions.Location = new Point(72, paneltransactions.Location.Y); 
                paneltransactions.Width = this.ClientSize.Width - 72; 
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uygulamadan çıkış yapmak üzeresiniz!", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

        }
    }
}