using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyecFinal
{
    public partial class FormEmpleado : Form
    {
        List<Clientes> clie = new List<Clientes>();
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Clientes clietemp = new Clientes();
                clietemp.Nit = reader.ReadLine();
                clietemp.Nombre = reader.ReadLine();
                clietemp.Apellido = reader.ReadLine();
                clietemp.Direccion = reader.ReadLine();
                clie.Add(clietemp);
            }
            reader.Close();

            for(int i=0; i<clie.Count; i++)
            {
                if (textBox1.Text == clie[i].Nit)
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = clie;
                    dataGridView2.Refresh();
                }
                else
                {
                    label7.Text = "El nit ingreado no existe";
                }

            }
        }
    }
}
