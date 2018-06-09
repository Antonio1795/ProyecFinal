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
    public partial class FormProducto : Form
    {
        
        public FormProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventario invetemp = new Inventario();

            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            invetemp.Producto = textBox1.Text;
            invetemp.Cantidad = Convert.ToInt16(textBox2.Text);
            invetemp.Precio = Convert.ToDecimal(textBox3.Text);

            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(textBox3.Text);

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            writer.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Inventario> inve = new List<Inventario>();
            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario invetemp = new Inventario();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());
                inve.Add(invetemp);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = inve;
            dataGridView1.Refresh();
        }
    }
}
