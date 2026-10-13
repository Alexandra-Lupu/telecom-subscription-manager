namespace Proiect_PAW
{
    partial class FormGrafic
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
            btnTipar = new Button();
            SuspendLayout();
            // 
            // btnTipar
            // 
            btnTipar.Location = new Point(60, 297);
            btnTipar.Name = "btnTipar";
            btnTipar.Size = new Size(241, 29);
            btnTipar.TabIndex = 0;
            btnTipar.Text = "Tipareste Grafic";
            btnTipar.UseVisualStyleBackColor = true;
            btnTipar.Click += btnTipar_Click;
            // 
            // FormGrafic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTipar);
            Name = "FormGrafic";
            Text = "FormGrafic";
            Load += FormGrafic_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnTipar;
    }
}