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

      
        int meelegido;
        private void button8_Click(object sender, EventArgs e)
        {
            List<Ventas> ven = new List<Ventas>();
            List<VentasEmpleadosporMes> vent2 = new List<VentasEmpleadosporMes>();
            List<Empleados> emple = new List<Empleados>();
            List<Mes> meusar = new List<Mes>();
            List<Inventario> inven = new List<Inventario>();
            List<VentatotaldelMes> ventasmes = new List<VentatotaldelMes>();

            string fileName = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario invetemp = new Inventario();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());

                inven.Add(invetemp);
            }
            reader.Close();
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

            string fileName4 = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Empleados.txt";
            FileStream stream4 = new FileStream(fileName4, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                Empleados emtemp = new Empleados();
                emtemp.Codigo = reader4.ReadLine();
                emtemp.Nombre = reader4.ReadLine();
                emtemp.Apellido = reader4.ReadLine();
                emple.Add(emtemp);
            }
            reader4.Close();

            string fileName3 = @"C:\Users\Antonio\source\repos\ProyecFinal\ProyecFinal\bin\Debug\Mes.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Mes mestemp = new Mes();
                mestemp.Mesano = reader3.ReadLine();
                meusar.Add(mestemp);
            }
            reader3.Close();

            for(int i=0; i<inven.Count; i++)
            {
                VentatotaldelMes ventmestemporal = new VentatotaldelMes();
                ventmestemporal.Producto = inven[i].Producto;
                ventmestemporal.Cantidad = 0;
                ventmestemporal.Totalvendido = 0;
                ventasmes.Add(ventmestemporal);
            }

            for (int i = 0; i < emple.Count; i++)
            {
                VentasEmpleadosporMes empleadomes = new VentasEmpleadosporMes();
                empleadomes.Codigoempleado = emple[i].Codigo;
                empleadomes.Cantidadvendida = 0;
                empleadomes.Totalvendido = 0;
                vent2.Add(empleadomes);
            }

            for (int i = 0; i < 12; i++)
            {
                if(Convert.ToInt16(comboBox2.Text) == i)
                {
                    meelegido = i;
                    break;
                }
            }
            label7.Text = meelegido.ToString();
            //ventas totales del mes
            for (int i = 0; i < ven.Count; i++) // revisa todas las ventas hechas de cierto mes 
            {
                if (ven[i].Fechaventa.Month == meelegido)
                {
                    for (int j = 0; j < ventasmes.Count; j++)
                    {
                        if (ven[i].Producto == ventasmes[j].Producto)
                        {
                            ventasmes[j].Cantidad = ventasmes[j].Cantidad + ven[i].Cantidad;
                            ventasmes[j].Totalvendido = ventasmes[j].Cantidad + ven[i].Precio;
                        }
                    }
                }
            }

            //Ventas organizadas por empleados +vendedor
            for (int i = 0; i < ven.Count; i++) // revisa todas las ventas hechas de cierto mes 
            {
                if (ven[i].Fechaventa.Month == meelegido)
                {
                    for (int j = 0; j < vent2.Count; j++)
                    {
                        if (ven[i].Codigoempleado == vent2[j].Codigoempleado)
                        {
                            vent2[j].Cantidadvendida = vent2[j].Cantidadvendida + ven[i].Cantidad;
                            vent2[j].Totalvendido = vent2[j].Totalvendido + ven[i].Precio;
                        }
                    }
                }
            }
           

            List<Inventario> inven2menor = new List<Inventario>();
            Inventario intemp = new Inventario();
            int menor = 1;
            for (int i = 0; i < inven.Count; i++)
            {
                if (inven[i].Cantidad < inven[menor].Cantidad)
                {
                    menor = i;
                }

            }

            intemp.Producto = inven[menor].Producto;
            intemp.Cantidad = inven[menor].Cantidad;
            intemp.Precio = inven[menor].Precio;
            inven2menor.Add(intemp);
            dataGridView3.DataSource = null;
            dataGridView3.Refresh();
            dataGridView3.DataSource = inven2menor;
            dataGridView3.Refresh();

            


            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = ventasmes;
            dataGridView2.Refresh();

            dataGridView4.DataSource = null;
            dataGridView4.Refresh();
            dataGridView4.DataSource = vent2;
            dataGridView4.Refresh();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                comboBox2.Items.Add(i+1);
            }
        }
    }
}
