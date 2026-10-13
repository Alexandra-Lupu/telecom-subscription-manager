namespace Proiect_PAW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fisierToolStripMenuItem = new ToolStripMenuItem();
            salvareTextToolStripMenuItem = new ToolStripMenuItem();
            restaurareTextToolStripMenuItem = new ToolStripMenuItem();
            serializareXMLToolStripMenuItem = new ToolStripMenuItem();
            deserializareXMLToolStripMenuItem = new ToolStripMenuItem();
            vizualizareGraficToolStripMenuItem = new ToolStripMenuItem();
            Lista_Abonati = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            stergeClientToolStripMenuItem = new ToolStripMenuItem();
            btnDeschideAdaugare = new Button();
            panelVIP = new Panel();
            lbl1 = new Label();
            lstVIP = new ListBox();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panelVIP.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fisierToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1418, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fisierToolStripMenuItem
            // 
            fisierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salvareTextToolStripMenuItem, restaurareTextToolStripMenuItem, serializareXMLToolStripMenuItem, deserializareXMLToolStripMenuItem, vizualizareGraficToolStripMenuItem });
            fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            fisierToolStripMenuItem.Size = new Size(57, 24);
            fisierToolStripMenuItem.Text = "&Fisier";
            // 
            // salvareTextToolStripMenuItem
            // 
            salvareTextToolStripMenuItem.Name = "salvareTextToolStripMenuItem";
            salvareTextToolStripMenuItem.Size = new Size(211, 26);
            salvareTextToolStripMenuItem.Text = "&Salvare Text";
            salvareTextToolStripMenuItem.Click += salvareTextToolStripMenuItem_Click;
            // 
            // restaurareTextToolStripMenuItem
            // 
            restaurareTextToolStripMenuItem.Name = "restaurareTextToolStripMenuItem";
            restaurareTextToolStripMenuItem.Size = new Size(211, 26);
            restaurareTextToolStripMenuItem.Text = "&Restaurare Text";
            restaurareTextToolStripMenuItem.Click += restaurareTextToolStripMenuItem_Click;
            // 
            // serializareXMLToolStripMenuItem
            // 
            serializareXMLToolStripMenuItem.Name = "serializareXMLToolStripMenuItem";
            serializareXMLToolStripMenuItem.Size = new Size(211, 26);
            serializareXMLToolStripMenuItem.Text = "Serializare &XML";
            serializareXMLToolStripMenuItem.Click += serializareXMLToolStripMenuItem_Click;
            // 
            // deserializareXMLToolStripMenuItem
            // 
            deserializareXMLToolStripMenuItem.Name = "deserializareXMLToolStripMenuItem";
            deserializareXMLToolStripMenuItem.Size = new Size(211, 26);
            deserializareXMLToolStripMenuItem.Text = "Deserializare &XML";
            deserializareXMLToolStripMenuItem.Click += deserializareXMLToolStripMenuItem_Click;
            // 
            // vizualizareGraficToolStripMenuItem
            // 
            vizualizareGraficToolStripMenuItem.Name = "vizualizareGraficToolStripMenuItem";
            vizualizareGraficToolStripMenuItem.Size = new Size(211, 26);
            vizualizareGraficToolStripMenuItem.Text = "Vizualizare Grafic";
            vizualizareGraficToolStripMenuItem.Click += vizualizareGraficToolStripMenuItem_Click;
            // 
            // Lista_Abonati
            // 
            Lista_Abonati.ContextMenuStrip = contextMenuStrip1;
            Lista_Abonati.FormattingEnabled = true;
            Lista_Abonati.Location = new Point(119, 45);
            Lista_Abonati.Name = "Lista_Abonati";
            Lista_Abonati.Size = new Size(345, 524);
            Lista_Abonati.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { stergeClientToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(164, 28);
            // 
            // stergeClientToolStripMenuItem
            // 
            stergeClientToolStripMenuItem.Name = "stergeClientToolStripMenuItem";
            stergeClientToolStripMenuItem.Size = new Size(163, 24);
            stergeClientToolStripMenuItem.Text = "Sterge Client";
            stergeClientToolStripMenuItem.Click += stergeClientToolStripMenuItem_Click;
            // 
            // btnDeschideAdaugare
            // 
            btnDeschideAdaugare.Location = new Point(494, 45);
            btnDeschideAdaugare.Name = "btnDeschideAdaugare";
            btnDeschideAdaugare.Size = new Size(215, 29);
            btnDeschideAdaugare.TabIndex = 2;
            btnDeschideAdaugare.Text = "&Adauga Abonat Nou";
            btnDeschideAdaugare.UseVisualStyleBackColor = true;
            btnDeschideAdaugare.Click += btnDeschideAdaugare_Click;
            // 
            // panelVIP
            // 
            panelVIP.AllowDrop = true;
            panelVIP.BackColor = SystemColors.Info;
            panelVIP.Controls.Add(lbl1);
            panelVIP.Location = new Point(898, 47);
            panelVIP.Name = "panelVIP";
            panelVIP.Size = new Size(366, 188);
            panelVIP.TabIndex = 3;
            // 
            // lbl1
            // 
            lbl1.BorderStyle = BorderStyle.FixedSingle;
            lbl1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbl1.Location = new Point(61, 78);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(250, 25);
            lbl1.TabIndex = 0;
            lbl1.Text = "Zona DROP - Clienti VIP";
            lbl1.Click += label1_Click;
            // 
            // lstVIP
            // 
            lstVIP.BackColor = SystemColors.Info;
            lstVIP.FormattingEnabled = true;
            lstVIP.Location = new Point(898, 252);
            lstVIP.Name = "lstVIP";
            lstVIP.Size = new Size(366, 284);
            lstVIP.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 690);
            Controls.Add(lstVIP);
            Controls.Add(panelVIP);
            Controls.Add(btnDeschideAdaugare);
            Controls.Add(Lista_Abonati);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panelVIP.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fisierToolStripMenuItem;
        private ToolStripMenuItem salvareTextToolStripMenuItem;
        private ToolStripMenuItem restaurareTextToolStripMenuItem;
        private ToolStripMenuItem serializareXMLToolStripMenuItem;
        private ToolStripMenuItem deserializareXMLToolStripMenuItem;
        private ListBox Lista_Abonati;
        private Button btnDeschideAdaugare;
        private ToolStripMenuItem vizualizareGraficToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem stergeClientToolStripMenuItem;
        private Panel panelVIP;
        private Label lbl1;
        private ListBox lstVIP;
    }
}
