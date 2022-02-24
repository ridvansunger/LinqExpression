using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqExpression
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //hangi üründen ne kadar satılmıştır. link sorguları
            NorthwindDataContext DB = new NorthwindDataContext();

            var sonuc = (from p in DB.Products
                         join od in DB.Order_Details on p.ProductID equals od.ProductID
                         group od by  p.ProductName into grup
                         select new
                         {
                             //key grupladığnız alan anlmaına geliyor neye grupladık urun adına göre
                             ProductName = grup.Key,
                             ToplamSatis = grup.Sum(x =>x.UnitPrice * x.Quantity * (decimal)(1-x.Discount))
                         });

            var sonuc2 = (from p in DB.Products
                          select new
                          {
                              p.ProductName,

                              ToplamSatis = p.Order_Details.Any() ? p.Order_Details.Sum(x => x.UnitPrice * x.Quantity * (decimal)(1 - x.Discount)):0

                              //ToplamSatis =p.Order_Details.Sum(x=>x.UnitPrice*x.Quantity*(decimal)(1-x.Discount)) ==null ? 0 : p.Order_Details.Sum(x => x.UnitPrice * x.Quantity * (decimal)(1 - x.Discount))

                          });

            dataGridView1.DataSource = sonuc2;
        }
    }
}
