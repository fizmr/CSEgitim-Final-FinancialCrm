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
    public partial class FrmDashboard: Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        FinancialCrmEntities4 db = new FinancialCrmEntities4();
        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + "₺";

            var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + "₺";

            //Chart1
            var bankData =db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series= chart1.Series.Add("Hesaplarım");
            foreach(var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }
            //Chart2
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalarım");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var billKYK = db.Bills.Where(x => x.BillTitle == "KYK").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "KYK ÖDEME";
                lblBillAmount.Text = billKYK.ToString() + "₺";
            }
            if (count % 4 == 2)
            {
                 var billAmazon = db.Bills.Where(x => x.BillTitle == "Amazon").Select(y => y.BillAmount).FirstOrDefault();
                 lblBillTitle.Text = "AMAZON PRIME";
                 lblBillAmount.Text = billAmazon.ToString() + "₺";                
            }
            if (count % 4 == 3)
            {
                var billYt = db.Bills.Where(x => x.BillTitle == "Youtube").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "YOUTUBE PREMIUM";
                lblBillAmount.Text = billYt.ToString() + "₺";
            }
            if (count % 4 == 0)
            {
                var billTt = db.Bills.Where(x => x.BillTitle == "Türk Telekom Data").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İNTERNET";
                lblBillAmount.Text = billTt.ToString() + "₺";
            }

            if (count % 4 == 0)
            {
                var spendingShop = db.Spending.Where(x => x.SpendingTitle == "A-101,BİM").Select(y => y.SpendingAmount).FirstOrDefault();
                lblSpendings.Text = "ALIŞVERİŞ";
                lblSpendingAmount.Text = spendingShop.ToString() + "₺";
            }
            if (count % 4 == 3)
            {
                var spendingBus = db.Spending.Where(x => x.SpendingTitle == "Otobüs").Select(y => y.SpendingAmount).FirstOrDefault();
                lblSpendings.Text = "ULAŞIM";
                lblSpendingAmount.Text = spendingBus.ToString() + "₺";
            }
            if (count % 4 == 2)
            {
                var spendingSchool = db.Spending.Where(x => x.SpendingTitle == "Öğrenci Kartı").Select(y => y.SpendingAmount).FirstOrDefault();
                lblSpendings.Text = "OKUL";
                lblSpendingAmount.Text = spendingSchool.ToString() + "₺";
            }
            if (count % 4 == 1)
            {
                var spendingEating = db.Spending.Where(x => x.SpendingTitle == "Fast Food (Total)").Select(y => y.SpendingAmount).FirstOrDefault();
                lblSpendings.Text = "YEME-İÇME";
                lblSpendingAmount.Text = spendingEating.ToString() + "₺";
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void FrmDashboard_MouseHover(object sender, EventArgs e)
        {
            
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

        private void btnCategories_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            
            if (panel1.Width == 72)
            {
                panel1.Width = 223;
                panel6.Location = new Point(223, panel6.Location.Y); // İçerik panelini sağa kaydır
                panel6.Width = this.ClientSize.Width - 223; // İçerik panelinin genişliğini ayarla
            }
            else
            {
                panel1.Width = 72;
                panel6.Location = new Point(72, panel6.Location.Y); // İçerik panelini sola kaydır
                panel6.Width = this.ClientSize.Width - 72; // İçerik panelinin genişliğini ayarla
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

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            FrmTransactions frm = new FrmTransactions();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }
    }
}
