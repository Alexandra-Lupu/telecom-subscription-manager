using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Proiect_PAW
{
    public partial class FormGrafic : Form
    {
        private List<Clienti> listaClientiGrafic;

        public FormGrafic(List<Clienti> lista)
        {
            InitializeComponent();
            this.listaClientiGrafic = lista;
            this.Text = "Grafic Seminar";
            this.Width = 500;
            this.Height = 420;

            this.Paint += new PaintEventHandler(FormGrafic_Paint);
        }

        private void FormGrafic_Paint(object sender, PaintEventArgs e)
        {
            deseneazaCeva(e.Graphics);
        }


        public void btnTipar_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument(); 
            pd.PrintPage += new PrintPageEventHandler(pd_gett_document);

            PrintPreviewDialog dlg = new PrintPreviewDialog(); 
            dlg.Document = pd; 
            dlg.ShowDialog(); 
        }


        private void pd_gett_document(object sender, PrintPageEventArgs e)
        {
            deseneazaCeva(e.Graphics);
        }

        private void deseneazaCeva(Graphics g)
        {
            if (listaClientiGrafic == null || listaClientiGrafic.Count == 0)
            {
                g.DrawString("Fara date.", new Font("Arial", 12), Brushes.Black, 20, 20);
                return;
            }

            double max = 0;
            foreach (Clienti c in listaClientiGrafic)
            {
                if (c.CalculeazaFacturaTotala() > max) max = c.CalculeazaFacturaTotala();
            }
            if (max == 0) max = 1;

            // Draw the axes
            Pen pen = new Pen(Color.Black, 1);
            g.DrawLine(pen, 40, 250, 450, 250); // X axis
            g.DrawLine(pen, 40, 250, 40, 30);   // Y axis

            int x = 60;
            Brush brushBara = Brushes.Red;
            Font fontS = new Font("Arial", 8);

            for (int i = 0; i < listaClientiGrafic.Count; i++)
            {
                double val = listaClientiGrafic[i].CalculeazaFacturaTotala();

                int inaltime = (int)((val / max) * 180);
                int y = 250 - inaltime;

                g.FillRectangle(brushBara, x, y, 30, inaltime);
                g.DrawString(val.ToString(), fontS, Brushes.Black, x, y - 15);

                string nume = listaClientiGrafic[i].NumeClient;
                if (nume.Length > 5) nume = nume.Substring(0, 5);
                g.DrawString(nume, fontS, Brushes.Black, x, 255);

                x += 50;
            }
        }

        private void FormGrafic_Load(object sender, EventArgs e)
        {

        }
    }
}