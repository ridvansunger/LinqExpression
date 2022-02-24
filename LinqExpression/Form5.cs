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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }


        NorthwindDataContext DB = new NorthwindDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            //fiyata göre sıralansın
            var result = (from p in DB.Products
                          orderby p.UnitPrice
                          select p);

            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = (from p in DB.Products
                          orderby p.UnitPrice descending
                          select p);


            var result2 = (from o in DB.Orders
                          orderby o.OrderDate descending
                          select o);

            dataGridView1.DataSource = result2;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //girdiğim tarih için satışları getir.
            DateTime date = Convert.ToDateTime(maskedTextBox1.Text);

           
            var result = from o in DB.Orders
                         where o.OrderDate == date
                         select o;





            DateTime date1 = Convert.ToDateTime(maskedTextBox2.Text);
            var result2 =(from t in DB.Orders
                          orderby t.OrderDate descending
                         where (t.OrderDate>=date && t.OrderDate<=date1 )
                         select t );


            dataGridView1.DataSource = result2;
        }
    }
}
