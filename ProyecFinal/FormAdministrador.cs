using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyecFinal
{
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProducto pro = new FormProducto();
            pro.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormModInventario mod = new FormModInventario();
            mod.Show();
        }
    }
}
