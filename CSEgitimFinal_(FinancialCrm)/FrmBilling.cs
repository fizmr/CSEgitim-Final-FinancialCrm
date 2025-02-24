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
    public partial class FrmBilling: Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmEntities4 db = new FinancialCrmEntities4();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            string title=txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bill = new Bills();
            bill.BillTitle = title;
            bill.BillAmount = amount;
            bill.BillPeriod = period;
            db.Bills.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Fatura Eklendi!", "Yeni Ödeme",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnBİllDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillID.Text);
            var bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
            db.SaveChanges();
            MessageBox.Show("Fatura Silindi!", "Ödeme Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBillUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillID.Text);
            var bill = db.Bills.Find(id);
            bill.BillTitle = txtBillTitle.Text;
            bill.BillAmount = decimal.Parse(txtBillAmount.Text);
            bill.BillPeriod = txtBillPeriod.Text;
            db.SaveChanges();
            MessageBox.Show("Fatura Güncellendi!", "Ödeme Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GİDERLER_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnBanks_Click_1(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnCategories_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FrmBilling_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 72)
            {
                panel1.Width = 223;
                panel2.Location = new Point(223, panel2.Location.Y); // İçerik panelini sağa kaydır
                panel2.Width = this.ClientSize.Width - 223; // İçerik panelinin genişliğini ayarla
           
            }
            else
            {
                panel1.Width = 72;
                panel2.Location = new Point(72, panel2.Location.Y); // İçerik panelini sola kaydır
                panel2.Width = this.ClientSize.Width - 72; // İçerik panelinin genişliğini ayarla
                
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            FrmTransactions frm = new FrmTransactions();
            frm.Show();
            this.Hide();
        }
    }
}
