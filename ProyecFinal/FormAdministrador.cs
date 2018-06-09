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

        private void button5_Click(object sender, EventArgs e)
        {
            List<Inventario> invent = new List<Inventario>();

            string fileName2 = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Inventario invetemp = new Inventario();
                invetemp.Producto = reader2.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader2.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader2.ReadLine());
                invent.Add(invetemp);
            }
            reader2.Close();

            List<Inventario> invent2 = new List<Inventario>();
            Inventario intemp = new Inventario();

            int menor = 1;
            for (int i = 0; i < invent.Count; i++)
            {
                if (invent[i].Cantidad < invent[menor].Cantidad)
                {
                    menor = i;
                }
            }
            intemp.Producto = invent[menor].Producto;
            intemp.Cantidad = invent[menor].Cantidad;
            intemp.Precio = invent[menor].Precio;
            invent2.Add(intemp);

            dataGridView3.DataSource = null;
            dataGridView3.Refresh();
            dataGridView3.DataSource = invent2;
            dataGridView3.Refresh();

        }
    }
}
