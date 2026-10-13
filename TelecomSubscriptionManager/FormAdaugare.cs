using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_PAW
{
    public partial class FormAdaugare : Form
    {
        internal Clienti ClientCreat { get; private set; }

        public FormAdaugare()
        {
            InitializeComponent();
        }

        // Save button: check the input data and create the client
        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            txtId.ForeColor = Color.Black;
            txtNume.ForeColor = Color.Black;
            txtPretBaza.ForeColor = Color.Black;
            txtCostSuplimentar.ForeColor = Color.Black;

            int id = 0;
            string nume = txtNume.Text;
            double pretBaza = 0;
            double costSuplimentar = 0;

            // 1. Client ID must be a whole number
            try
            {
                id = Convert.ToInt32(txtId.Text);
            }
            catch
            {
                txtId.ForeColor = Color.Red;
                txtId.Focus();
                MessageBox.Show("ID-ul clientului trebuie să fie un număr valid!", "Eroare Validare");
                return;
            }

            // 2. Client name must not be empty
            if (string.IsNullOrEmpty(nume))
            {
                txtNume.ForeColor = Color.Red;
                txtNume.Focus();
                MessageBox.Show("Numele clientului nu poate fi gol!", "Eroare Validare");
                return;
            }

            // 3. Plan price must be a valid number
            try
            {
                pretBaza = Convert.ToDouble(txtPretBaza.Text);
            }
            catch
            {
                txtPretBaza.ForeColor = Color.Red;
                txtPretBaza.Focus();
                MessageBox.Show("Prețul de bază trebuie să fie un număr valid!", "Eroare Validare");
                return;
            }

            // 4. Extra cost must be a valid number
            try
            {
                costSuplimentar = Convert.ToDouble(txtCostSuplimentar.Text);
            }
            catch
            {
                txtCostSuplimentar.ForeColor = Color.Red;
                txtCostSuplimentar.Focus();
                MessageBox.Show("Costul suplimentar trebuie să fie un număr valid!", "Eroare Validare");
                return;
            }

            // Create the objects from the checked data
            TipAbonament abonament = new TipAbonament("Abonament Personalizat", pretBaza, null);
            ClientCreat = new Clienti(id, nume, abonament, costSuplimentar);

            // Send the new client back to the main window
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormAdaugare_Load(object sender, EventArgs e)
        {

        }
    }
}