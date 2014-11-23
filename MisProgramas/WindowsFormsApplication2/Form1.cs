using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int minimo;
            if (!Int32.TryParse(txtMinimo.Text, out minimo))
            {
                MessageBox.Show("El nimimo no es correcto");
                return;
            }

            int maximo;
                if (!Int32.TryParse(txtMaximo.Text, out maximo))
            {
                MessageBox.Show("El maximo no es correcto");
                return;
            }

            Func<int, int> factorial = null;
            factorial = n => n == 0 ? 1 : n * factorial(n - 1);

            Func<int, int, int> potencia = null;
            potencia = (int x, int n) => n == 0 ? 1 : x * potencia(x, n - 1);

            MostrarTabla(minimo, maximo, 
                new string[] { "n * n", " n ^ 3", "!n" },
                new Func<int, int>[] { n => n * n, n => potencia(n, 3), factorial });
        
        }


        void MostrarTabla(int min, int max, string[] cabeceras, Func<int,int>[] funciones)
        {
            lvTabla.Clear();
            lvTabla.Columns.Add("n", 50).TextAlign = HorizontalAlignment.Center;
            foreach (string cabecera in cabeceras)
                lvTabla.Columns.Add(cabecera, 100).TextAlign = HorizontalAlignment.Right;

            lvTabla.Items.Clear();
            for (int n = min; n <= max; n++)
            {
                ListViewItem item = lvTabla.Items.Add(n.ToString());                
                
                foreach(Func<int,int> funcion in funciones)
                {
                    item.SubItems.Add(funcion(n).ToString());
                }
            }
        }
    }
}
