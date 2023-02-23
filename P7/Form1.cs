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

namespace P7
{
    public partial class Form1 : Form
    {
        List<practica7> clientes;
        public Form1()
        {
            InitializeComponent();
            clientes = new List<practica7>();
            cargar();
            validar();
            
        }
        public void validar()
        {
           
        }
        public void cargar()
        {
            
            StreamReader pizzas = new StreamReader("Entregas.dat");
            while (!pizzas.EndOfStream)
            {
                var linea = pizzas.ReadLine().Split('|');
                string ID = linea[0];
                string status = linea[1];
                string repartidor = linea[2];
                Corden.Items.Add(ID);
                practica7 repartidores = new practica7(ID, status, repartidor);
                clientes.Add(repartidores);
            }
            pizzas.Close();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string id = Corden.Text;
            //string s = CEstatus.Text;
            //string r = TReparitodr.Text;

            //StreamWriter n = new StreamWriter("Entregas.dat", true);
            //foreach (var item in clientes)
            //{
            //    if (id == item.id)
            //    {

            //        n.WriteLine(id + s + r);
            //    }
            //}
            //n.Close();

        }

        private void CEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CEstatus.SelectedIndex == 0 || CEstatus.SelectedIndex == 1)
            {
                TReparitodr.Enabled = false;
              
            }
            else
            {
                TReparitodr.Enabled = true;
            }
        }

        private void Corden_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = Corden.Text;
            foreach (var item in clientes)
            {

                if (id == item.id)
                {
                    CEstatus.Text = item.estado;
                    TReparitodr.Text = item.nombre;
                    break;
                }

            }
        }
    }
}
