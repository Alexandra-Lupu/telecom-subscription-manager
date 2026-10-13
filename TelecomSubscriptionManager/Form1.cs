using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Proiect_PAW
{
    public partial class Form1 : Form
    {
        private List<Clienti> listaClienti = new List<Clienti>();

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            ActualizeazaInterfata();

            // Add the 5G option button to the window at startup
            AdaugaButonOpțiuneRăpida();

            // Turn on drag and drop
            this.Lista_Abonati.MouseDown += new MouseEventHandler(Lista_Abonati_MouseDown);
            this.panelVIP.DragEnter += new DragEventHandler(panelVIP_DragEnter);
            this.panelVIP.DragDrop += new DragEventHandler(panelVIP_DragDrop);
        }

        private void ActualizeazaInterfata()
        {
            Lista_Abonati.Items.Clear();
            foreach (Clienti c in listaClienti)
            {
                Lista_Abonati.Items.Add(c);
            }
        }

        // Keyboard shortcuts
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) ExecutaDeschidereMacheta();
            if (e.Control && e.KeyCode == Keys.G) DeschideFereastraGrafic();
        }

        private void btnDeschideAdaugare_Click(object sender, EventArgs e)
        {
            ExecutaDeschidereMacheta();
        }

        private void ExecutaDeschidereMacheta()
        {
            FormAdaugare frm = new FormAdaugare();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.ClientCreat != null)
                {
                    // Event that changes the background color of the main window
                    frm.ClientCreat.OnSchimbareCuloare += Frm_OnSchimbareCuloare;
                    frm.ClientCreat.DeclanșeazăNotificareVizuală();

                    listaClienti.Add(frm.ClientCreat);
                    ActualizeazaInterfata();
                }
            }
        }

        private void Frm_OnSchimbareCuloare()
        {
            this.BackColor = Color.LightSteelBlue;
        }


        // Save to text file
        private void salvareTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Fișiere Text|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName))
                {
                    foreach (Clienti c in listaClienti)
                    {
                        string pretBazaStr = c.AbonamentClasa.PretBaza.ToString(CultureInfo.InvariantCulture);
                        string costSuplimentarStr = c.CostSuplimentarAparut.ToString(CultureInfo.InvariantCulture);

                        // Check if the client has the 5G option
                        int are5G = 0;
                        if (c.AbonamentClasa.OptiuniIncluse != null)
                        {
                            foreach (ExtraOptiuni eo in c.AbonamentClasa.OptiuniIncluse)
                            {
                                if (eo.NumeOptiune == "Internet 5G")
                                {
                                    are5G = 1;
                                    break;
                                }
                            }
                        }

                        sw.WriteLine($"{c.IdClient},{c.NumeClient},{pretBazaStr},{costSuplimentarStr},{are5G}");
                    }
                }
                MessageBox.Show("Datele au fost salvate cu succes în fișierul text!", "Info");
            }
        }

        // Load from text file
        private void restaurareTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Fișiere Text|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                listaClienti.Clear();
                string linie;

                using (StreamReader sr = new StreamReader(dlg.FileName))
                {
                    while ((linie = sr.ReadLine()) != null)
                    {
                        string[] bucati = linie.Split(',');
                        if (bucati.Length >= 4)
                        {
                            int id = Convert.ToInt32(bucati[0]);
                            string nume = bucati[1];
                            double pretBaza = Convert.ToDouble(bucati[2], CultureInfo.InvariantCulture);
                            double costSuplimentar = Convert.ToDouble(bucati[3], CultureInfo.InvariantCulture);

                            TipAbonament tab = new TipAbonament("Abonament Importat", pretBaza, null);

                            // Check the 5G flag (the 5th value on the line is 1)
                            if (bucati.Length == 5 && bucati[4] == "1")
                            {
                                ExtraOptiuni optiuneNoua = new ExtraOptiuni("Internet 5G", 5.50);
                                // Use the + operator to add the option back
                                tab = tab + optiuneNoua;
                            }

                            Clienti c = new Clienti(id, nume, tab, costSuplimentar);
                            listaClienti.Add(c);
                        }
                    }
                }
                ActualizeazaInterfata();
                MessageBox.Show("Datele au fost restaurate cu succes!", "Info");
            }
        }

        // Save to XML file
        private void serializareXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Fișiere XML|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializare = new XmlSerializer(typeof(List<Clienti>));
                    serializare.Serialize(fs, listaClienti);
                }
                MessageBox.Show("Fișierul XML a fost creat cu succes!", "Info");
            }
        }

        // Load from XML file
        private void deserializareXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Fișiere XML|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer deserializator = new XmlSerializer(typeof(List<Clienti>));
                    listaClienti = (List<Clienti>)deserializator.Deserialize(fs);
                }

                ActualizeazaInterfata();
                MessageBox.Show("Datele XML au fost deserializate cu succes!", "Info");
            }
        }

        private void vizualizareGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeschideFereastraGrafic();
        }

        private void DeschideFereastraGrafic()
        {
            FormGrafic frmG = new FormGrafic(listaClienti);
            frmG.ShowDialog();
        }

        private void stergeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Lista_Abonati.SelectedIndex != -1)
            {
                listaClienti.RemoveAt(Lista_Abonati.SelectedIndex);
                ActualizeazaInterfata();
            }
        }

        // Create the 5G option button under the 'add client' button
        private void AdaugaButonOpțiuneRăpida()
        {
            Button btnOpțiune = new Button();
            btnOpțiune.Text = "Adaugă Opțiune (+)";
            btnOpțiune.Size = new Size(130, 30);
            btnOpțiune.Location = new Point(btnDeschideAdaugare.Location.X, btnDeschideAdaugare.Location.Y + 35);
            btnOpțiune.Click += new EventHandler(btnAdaugaOptiuneRapida_Click);
            this.Controls.Add(btnOpțiune);
        }

        // Click handler for the 5G button (uses the + operator and the indexer)
        private void btnAdaugaOptiuneRapida_Click(object sender, EventArgs e)
        {
            if (Lista_Abonati.SelectedIndex != -1)
            {
                Clienti clientSelectat = listaClienti[Lista_Abonati.SelectedIndex];

                // Check if the client already has Internet 5G
                bool dejaActiva = false;
                if (clientSelectat.AbonamentClasa.OptiuniIncluse != null)
                {
                    foreach (ExtraOptiuni eo in clientSelectat.AbonamentClasa.OptiuniIncluse)
                    {
                        if (eo.NumeOptiune == "Internet 5G")
                        {
                            dejaActiva = true;
                            break;
                        }
                    }
                }

                if (dejaActiva)
                {
                    MessageBox.Show("Această opțiune este deja activă pe abonamentul clientului selectat!", "Opțiune Activă");
                    return;
                }

                ExtraOptiuni optiuneNoua = new ExtraOptiuni("Internet 5G", 5.50);

                // Use the + operator
                clientSelectat.AbonamentClasa = clientSelectat.AbonamentClasa + optiuneNoua;

                int pozitieCurenta = clientSelectat.AbonamentClasa.OptiuniIncluse.Length - 1;
                string numeConfirmat = clientSelectat.AbonamentClasa[pozitieCurenta].NumeOptiune;

                ActualizeazaInterfata();

                MessageBox.Show($"Opțiunea '{numeConfirmat}' a fost adăugată!\nNoua factură: {clientSelectat.CalculeazaFacturaTotala()} EUR", "Succes");
            }
            else
            {
                MessageBox.Show("Vă rugăm selectați un client din listă!", "Atenție");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Drag and drop event handlers

        private void Lista_Abonati_MouseDown(object sender, MouseEventArgs e)
        {
            if (Lista_Abonati.SelectedItem != null && e.Button == MouseButtons.Left)
            {
                Clienti clientSelectat = (Clienti)Lista_Abonati.SelectedItem;
                Lista_Abonati.DoDragDrop(clientSelectat, DragDropEffects.Copy);
            }
        }
        private void panelVIP_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Clienti)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelVIP_DragDrop(object sender, DragEventArgs e)
        {
            Clienti clientVIP = (Clienti)e.Data.GetData(typeof(Clienti));

            if (clientVIP != null)
            {
                if (!lstVIP.Items.Contains(clientVIP))
                {
                    lstVIP.Items.Add(clientVIP);

                    MessageBox.Show($"Clientul {clientVIP.NumeClient} a fost promovat în lista VIP!", "Drag & Drop Reușit");
                }
                else
                {
                    MessageBox.Show("Acest abonat este deja inclus în lista VIP!", "Informație");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}