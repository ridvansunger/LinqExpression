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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //satış tablosunu listeletip urunler tablosunu join yapıp urun adı satış fiyatı, adet, indirim
            NorthwindDataContext DB = new NorthwindDataContext();
            dataGridView1.DataSource = from p in DB.Products
                                       join od in DB.Order_Details on p.ProductID equals od.ProductID
                                       select new
                                       {
                                           p.ProductName,
                                           p.UnitPrice,
                                           OrderUnit=od.UnitPrice,
                                           p.UnitsInStock,
                                           od.Discount
                                       };
        }
    }
}
