namespace Proiect_PAW
{
    partial class FormAdaugare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtId = new TextBox();
            txtPretBaza = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtCostSuplimentar = new TextBox();
            btnSalveaza = new Button();
            label4 = new Label();
            txtNume = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 37);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "ID Client:";
            // 
            // txtId
            // 
            txtId.Location = new Point(311, 34);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 1;
            // 
            // txtPretBaza
            // 
            txtPretBaza.Location = new Point(311, 131);
            txtPretBaza.Name = "txtPretBaza";
            txtPretBaza.Size = new Size(125, 27);
            txtPretBaza.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 134);
            label2.Name = "label2";
            label2.Size = new Size(166, 20);
            label2.TabIndex = 3;
            label2.Text = "Pret Abonament (Baza):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 173);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 4;
            label3.Text = "Cost Suplimentar:";
            // 
            // txtCostSuplimentar
            // 
            txtCostSuplimentar.Location = new Point(311, 173);
            txtCostSuplimentar.Name = "txtCostSuplimentar";
            txtCostSuplimentar.Size = new Size(125, 27);
            txtCostSuplimentar.TabIndex = 5;
            // 
            // btnSalveaza
            // 
            btnSalveaza.Location = new Point(162, 211);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(94, 29);
            btnSalveaza.TabIndex = 6;
            btnSalveaza.Text = "&Salveaza";
            btnSalveaza.UseVisualStyleBackColor = true;
            btnSalveaza.Click += btnSalveaza_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 85);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 7;
            label4.Text = "Nume Client:";
            // 
            // txtNume
            // 
            txtNume.Location = new Point(311, 85);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(125, 27);
            txtNume.TabIndex = 8;
            // 
            // FormAdaugare
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNume);
            Controls.Add(label4);
            Controls.Add(btnSalveaza);
            Controls.Add(txtCostSuplimentar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPretBaza);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "FormAdaugare";
            Text = "FormAdaugare";
            Load += FormAdaugare_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox txtPretBaza;
        private Label label2;
        private Label label3;
        private TextBox txtCostSuplimentar;
        private Button btnSalveaza;
        private Label label4;
        private TextBox txtNume;
    }
}