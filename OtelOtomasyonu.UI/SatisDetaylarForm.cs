using OtelOtomasyonu.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonu.UI
{
    public partial class SatisDetaylarForm : Form
    {
        public SatisDetaylarForm()
        {
            InitializeComponent();
        }

        private void SatisDetaylarForm_Load(object sender, EventArgs e)
        {
            SatisDetayORM sdOrm = new SatisDetayORM();
            dataGridView1.DataSource = sdOrm.Select();
        }
    }
}
