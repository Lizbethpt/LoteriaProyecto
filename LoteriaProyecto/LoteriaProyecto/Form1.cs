using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoteriaProyecto
{
    public partial class Form1 : Form
    {
        Random ra = new Random();
        private PictureBox[] cartas;
        private PictureBox[] tabla;

        public Form1()
        {
            InitializeComponent();
            tabla = new PictureBox[25];
            inicializarTabla();
        }
        private void inicializarTabla()
        {
            int[] cartas = new int[34];

            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = i + 1;
            }
            
            Random rnd = new Random();
            int a, aux;
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }

            int r= 0, c = 0;
            for (int i = 0; i < tabla.Length; i++)
            {
                tabla[i] = new PictureBox();
                tabla[i].Location = new System.Drawing.Point(100+(c*90),25+(r*125));
                tabla[i].Name = "PicTabla"+1;
                tabla[i].Size = new System.Drawing.Size(85, 120);
                tabla[i].TabIndex = 0 + 1;
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].TabStop = false;
                tabla[i].Image = Image.FromFile(@"Cartas\" + (cartas[i]) + ".jpg");
                this.Controls.Add(tabla[i]);
                c++;
                if (c==5)
                {
                    r++;
                    c = 0;
                }
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnsigcarta_Click(object sender, EventArgs e)
        {
            int num = ra.Next(1, 54);
            pictureBox1.Image = Image.FromFile(@"Cartas\" +(num) + ".jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
