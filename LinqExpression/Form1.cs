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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthwindDataContext DB = new NorthwindDataContext();

            //sql sorgusunu testen yazmaya benzer
            //daha önce bir yerde tanımlanmamış bir tip oluşturmak için new değeri anonim tip oluşturacağız.
            //benzersiz bir tip oluşturur.
            dataGridView1.DataSource = from p in DB.Products
                                       join c in DB.Categories on p.CategoryID equals c.CategoryID
                                       select new
                                       {
                                           p.ProductName,
                                           c.CategoryName,
                                           p.UnitPrice,
                                           p.UnitsInStock
                                       };
        }
    }
}
