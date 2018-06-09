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
       
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Clientes> clie = new List<Clientes>();
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
                if ( textBox1.Text == clie[i].Nit)
                {
                    int pos = 0;
                    for (int j = 0; j < clie.Count; j++)
                    {
                        if (textBox1.Text == clie[j].Nit)
                        {
                            pos = j;
                        }
                    }

                    List<Clientes> cli = new List<Clientes>();
                    Clientes ct = new Clientes();

                    ct.Nit = clie[pos].Nit;
                    ct.Nombre = clie[pos].Nombre;
                    ct.Apellido = clie[pos].Apellido;
                    ct.Direccion = clie[pos].Direccion;
                    cli.Add(ct);


                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = cli;
                    dataGridView2.Refresh();
                    

                    label7.Text = "Nit encontrado";
                    break;
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    label7.Text = "No encontrado";
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormNuevoCliente clientenuevo = new FormNuevoCliente();
            clientenuevo.Show();
        }

     
    }
}
