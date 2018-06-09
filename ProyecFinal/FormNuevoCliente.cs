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
    public partial class FormNuevoCliente : Form
    {
        public FormNuevoCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            
            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(textBox3.Text);
            writer.WriteLine(textBox4.Text);

            label5.Text = "Cliente agregado satisfactoriamente";
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            writer.Close();
            
        }

       
    }
}
