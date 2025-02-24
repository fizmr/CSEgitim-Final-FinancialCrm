using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSEgitimFinal__FinancialCrm_.Models;

namespace CSEgitimFinal__FinancialCrm_
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmEntities4 db = new FinancialCrmEntities4();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Bakiyeleri getirme
            var zirratBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var garantiBalance = db.Banks.Where(x => x.BankTitle == "Garanti").Select(y => y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraat.Text = zirratBankBalance.ToString() + " ₺";
            lblGaranti.Text = garantiBalance.ToString() + " ₺";
            lblIsBankasi.Text = isBankBalance.ToString() + " ₺";

            //Son Haraketleri getirme
            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description + " - " + bankProcess1.Amount + "₺ - " + bankProcess1.ProcessDate?.ToString("dd.MM.yyyy || 00:15:00");

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " - " + bankProcess2.Amount + "₺ - " + bankProcess2.ProcessDate?.ToString("dd.MM.yyyy || 00:15:00");

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " - " + bankProcess3.Amount + "₺ - " + bankProcess3.ProcessDate?.ToString("dd.MM.yyyy || 10:36:24");

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " - " + bankProcess4.Amount + "₺ - " + bankProcess4.ProcessDate?.ToString("dd.MM.yyyy || 15:46:06");

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " - " + bankProcess5.Amount + "₺ - " + bankProcess5.ProcessDate?.ToString("dd.MM.yyyy || 00:15:00");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
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

        private void btnCategories_Click(object sender, EventArgs e)
        {
          
            if (panel1.Width == 72)
            {
                panel1.Width = 223;
                panel5.Location = new Point(223, panel5.Location.Y); // İçerik panelini sağa kaydır
                panel5.Width = this.ClientSize.Width - 223; // İçerik panelinin genişliğini ayarla
            }
            else
            {
                panel1.Width = 72;
                panel5.Location = new Point(72, panel5.Location.Y); // İçerik panelini sola kaydır
                panel5.Width = this.ClientSize.Width - 72; // İçerik panelinin genişliğini ayarla
            }
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result =MessageBox.Show("Uygulamadan çıkış yapmak üzeresiniz!", "UYARI", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            FrmTransactions frm = new FrmTransactions();
            frm.Show();
            this.Hide();
        }
    }
}
