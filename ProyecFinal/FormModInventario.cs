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
    public partial class FormModInventario : Form
    {
        List<Inventario> invent = new List<Inventario>();
        public FormModInventario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario invetemp = new Inventario();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());
                invent.Add(invetemp);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = invent;
            dataGridView1.Refresh();

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario invetemp = new Inventario();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());
                invent.Add(invetemp);
            }
            reader.Close();


            for (int i = 0; i < invent.Count; i++)
            {
                if (textBox1.Text == invent[i].Producto)
                {
                    textBox2.Text = invent[i].Cantidad.ToString();
                    textBox3.Text = invent[i].Precio.ToString();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            string nombcambiar = textBox1.Text;
            int cantidadcambiar = Convert.ToInt16(textBox2.Text);
            Decimal preciocambiar = Convert.ToDecimal(textBox3.Text);

            for(int i=0; i<invent.Count; i++)
            {
                if(invent[i].Producto != nombcambiar)
                {
                    writer.WriteLine(invent[i].Producto);
                    writer.WriteLine(invent[i].Cantidad);
                    writer.WriteLine(invent[i].Precio);
                }
                else
                {
                    writer.WriteLine(nombcambiar);
                    writer.WriteLine(cantidadcambiar);
                    writer.WriteLine(preciocambiar);


                }
            }
            writer.Close();
        }
    }
}
