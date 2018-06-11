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
        List<Ventas> ven = new List<Ventas>();
        List<VentasEmpleadosporMes> vent2 = new List<VentasEmpleadosporMes>();
        List<Empleados> emple = new List<Empleados>();
        List<Mes> meusar = new List<Mes>();
        List<Inventario> inven = new List<Inventario>();
        List<VentatotaldelMes> ventasmes = new List<VentatotaldelMes>();


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

       

        private void button6_Click(object sender, EventArgs e)
        {
           
            

            
            for (int i = 0; i < ven.Count; i++)
            {
                for (int j = 0; j < emple.Count; j++)
                {
                    if (ven[i].Fechaventa.Month.ToString() == comboBox2.Text)
                    {
                        if (ven[i].Codigoempleado == emple[j].Codigo)
                        {
                            VentasEmpleadosporMes vetemporalmes = new VentasEmpleadosporMes();
                            vetemporalmes.Codigoempleado = emple[j].Codigo;
                            int sumcont = 0;
                            Decimal sumprecio = 0;
                            for (int k = 0; k < ven.Count; k++)
                            {
                                sumcont = ven[k].Cantidad + sumcont;
                                sumprecio = sumprecio + ven[k].Precio;
                            }
                            vetemporalmes.Cantidadvendida = sumcont;
                            vetemporalmes.Totalvendido = sumprecio;
                            vetemporalmes.Mes1 = Convert.ToInt16(comboBox2.Text);
                            vent2.Add(vetemporalmes);
                            break;
                        }
                    }
                }
            }

            dataGridView4.DataSource = null;
            dataGridView4.Refresh();
            dataGridView4.DataSource = vent2;
            dataGridView4.Refresh();

        }


        int meelegido;
        private void button8_Click(object sender, EventArgs e)
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


            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = ventasmes;
            dataGridView2.Refresh();


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
