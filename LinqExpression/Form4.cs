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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //hangi personel kaç adet satış yapmuştır.
            NorthwindDataContext DB = new NorthwindDataContext();

            var result = (from o in DB.Orders
                          //join em in DB.Employees on o.EmployeeID equals em.EmployeeID
                          //group em by new { o.EmployeeID, em.FirstName } into g
                          group o by o.EmployeeID into g
                          select new
                          {
                              
                              EmployeeID=g.Key,
                              FirstName=DB.Employees.FirstOrDefault(x=>x.EmployeeID==g.Key).FirstName,
                              
                              Total=g.Count()


                          });
            dataGridView1.DataSource = result;

        }
    }
}
