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


        private void button6_Click(object sender, EventArgs e)
        {
            List<Ventas> ven = new List<Ventas>();
            List<VentasEmpleadosporMes> vent2 = new List<VentasEmpleadosporMes>();
            List<Empleados> emple = new List<Empleados>();

            string fileName2 = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Ventas.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Ventas vetemp = new Ventas();
                vetemp.Nitcliente = reader2.ReadLine();
                vetemp.Codigoempleado = reader2.ReadLine();
                vetemp.Producto = reader2.ReadLine();
                vetemp.Cantidad = Convert.ToInt16(reader2.ReadLine());
                vetemp.Precio = Convert.ToDecimal(reader2.ReadLine());
                vetemp.Fechaventa = Convert.ToDateTime(reader2.ReadLine());
                ven.Add(vetemp);
            }
            reader2.Close();

            string fileName3 = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Empleados.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Empleados emtemp = new Empleados();
                emtemp.Codigo = reader3.ReadLine();
                emtemp.Nombre = reader3.ReadLine();
                emtemp.Apellido = reader3.ReadLine();
                emple.Add(emtemp);
            }
            reader3.Close();


            vent2.Capacity = ven.Count;
            for (int i = 0; i < ven.Count; i++)
            {
                for (int j = 0; j < emple.Count; j++)
                {
                    if (ven[i].Fechaventa.Month.ToString() == comboBox2.Text)
                    {
                        if (ven[i].Codigoempleado == emple[j].Codigo)
                        {
                            vent2[i].Codigoempleado = emple[j].Codigo;
                            vent2[i].Cantidadvendida = vent2[i].Cantidadvendida + ven[i].Cantidad;
                            vent2[i].Totalvendido = vent2[i].Totalvendido + ven[i].Precio;
                            vent2[i].Mes1 = Convert.ToInt16(comboBox2.Text);
                        }
                    }
                }
                }
        
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Ventas> ven = new List<Ventas>();
            List<Ventas> vent2 = new List<Ventas>();
            string fileName2 = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Ventas.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Ventas vetemp = new Ventas();
                vetemp.Nitcliente = reader2.ReadLine();
                vetemp.Codigoempleado = reader2.ReadLine();
                vetemp.Producto = reader2.ReadLine();
                vetemp.Cantidad = Convert.ToInt16(reader2.ReadLine());
                vetemp.Precio = Convert.ToDecimal(reader2.ReadLine());
                vetemp.Fechaventa = Convert.ToDateTime(reader2.ReadLine());
                ven.Add(vetemp);
            }
            reader2.Close();
            


            for (int i = 0; i < ven.Count; i++)
            {

                if (true)
                {

                }
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                comboBox2.Items.Add(i + 1);
            }
        }
    }
}
