namespace GUICompteBancaire
{
    partial class GestionCompte
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
            listeTransactions = new ListView();
            columnDate = new ColumnHeader();
            columnMontant = new ColumnHeader();
            columnNotes = new ColumnHeader();
            label1 = new Label();
            pickerDate = new DateTimePicker();
            label2 = new Label();
            textBoxMontant = new TextBox();
            label3 = new Label();
            textBoxNotes = new TextBox();
            statusSolde = new StatusStrip();
            labelSolde = new ToolStripStatusLabel();
            panelZoom = new Panel();
            buttonSupprimer = new Button();
            buttonAjouter = new Button();
            buttonValider = new Button();
            labelErreur = new ToolStripStatusLabel();
            statusSolde.SuspendLayout();
            panelZoom.SuspendLayout();
            SuspendLayout();
            // 
            // listeTransactions
            // 
            listeTransactions.Columns.AddRange(new ColumnHeader[] { columnDate, columnMontant, columnNotes });
            listeTransactions.FullRowSelect = true;
            listeTransactions.GridLines = true;
            listeTransactions.Location = new Point(12, 12);
            listeTransactions.MultiSelect = false;
            listeTransactions.Name = "listeTransactions";
            listeTransactions.Size = new Size(393, 426);
            listeTransactions.TabIndex = 0;
            listeTransactions.UseCompatibleStateImageBehavior = false;
            listeTransactions.View = View.Details;
            listeTransactions.SelectedIndexChanged += listeTransactions_SelectedIndexChanged;
            // 
            // columnDate
            // 
            columnDate.Text = "Date";
            columnDate.Width = 120;
            // 
            // columnMontant
            // 
            columnMontant.Text = "Montant";
            columnMontant.TextAlign = HorizontalAlignment.Right;
            columnMontant.Width = 160;
            // 
            // columnNotes
            // 
            columnNotes.Text = "Notes";
            columnNotes.Width = 250;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Date";
            // 
            // pickerDate
            // 
            pickerDate.Location = new Point(3, 22);
            pickerDate.Name = "pickerDate";
            pickerDate.Size = new Size(200, 23);
            pickerDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 94);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Montant";
            // 
            // textBoxMontant
            // 
            textBoxMontant.Location = new Point(3, 112);
            textBoxMontant.Name = "textBoxMontant";
            textBoxMontant.Size = new Size(200, 23);
            textBoxMontant.TabIndex = 4;
            textBoxMontant.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 174);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "Notes";
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(3, 192);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.ScrollBars = ScrollBars.Both;
            textBoxNotes.Size = new Size(362, 100);
            textBoxNotes.TabIndex = 6;
            // 
            // statusSolde
            // 
            statusSolde.Items.AddRange(new ToolStripItem[] { labelSolde, labelErreur });
            statusSolde.Location = new Point(0, 453);
            statusSolde.Name = "statusSolde";
            statusSolde.Size = new Size(794, 22);
            statusSolde.TabIndex = 7;
            statusSolde.Text = "statusStrip1";
            // 
            // labelSolde
            // 
            labelSolde.Name = "labelSolde";
            labelSolde.Size = new Size(0, 17);
            // 
            // panelZoom
            // 
            panelZoom.Controls.Add(textBoxNotes);
            panelZoom.Controls.Add(label1);
            panelZoom.Controls.Add(pickerDate);
            panelZoom.Controls.Add(label3);
            panelZoom.Controls.Add(label2);
            panelZoom.Controls.Add(textBoxMontant);
            panelZoom.Enabled = false;
            panelZoom.Location = new Point(411, 12);
            panelZoom.Name = "panelZoom";
            panelZoom.Size = new Size(371, 305);
            panelZoom.TabIndex = 8;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.Location = new Point(414, 343);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(75, 23);
            buttonSupprimer.TabIndex = 9;
            buttonSupprimer.Text = "Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = true;
            buttonSupprimer.Click += buttonSupprimer_Click;
            // 
            // buttonAjouter
            // 
            buttonAjouter.Location = new Point(701, 343);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(75, 23);
            buttonAjouter.TabIndex = 10;
            buttonAjouter.Text = "Ajouter";
            buttonAjouter.UseVisualStyleBackColor = true;
            buttonAjouter.Click += buttonAjouter_Click;
            // 
            // buttonValider
            // 
            buttonValider.Location = new Point(701, 343);
            buttonValider.Name = "buttonValider";
            buttonValider.Size = new Size(75, 23);
            buttonValider.TabIndex = 11;
            buttonValider.Text = "Ajouter";
            buttonValider.UseVisualStyleBackColor = true;
            buttonValider.Visible = false;
            buttonValider.Click += buttonValider_Click;
            // 
            // labelErreur
            // 
            labelErreur.ForeColor = Color.Red;
            labelErreur.Name = "labelErreur";
            labelErreur.Size = new Size(0, 17);
            // 
            // GestionCompte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 475);
            Controls.Add(buttonValider);
            Controls.Add(buttonAjouter);
            Controls.Add(buttonSupprimer);
            Controls.Add(panelZoom);
            Controls.Add(statusSolde);
            Controls.Add(listeTransactions);
            Name = "GestionCompte";
            Text = "GestionCompte";
            statusSolde.ResumeLayout(false);
            statusSolde.PerformLayout();
            panelZoom.ResumeLayout(false);
            panelZoom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listeTransactions;
        private ColumnHeader columnDate;
        private ColumnHeader columnMontant;
        private ColumnHeader columnNotes;
        private Label label1;
        private DateTimePicker pickerDate;
        private Label label2;
        private TextBox textBoxMontant;
        private Label label3;
        private TextBox textBoxNotes;
        private StatusStrip statusSolde;
        private ToolStripStatusLabel labelSolde;
        private Panel panelZoom;
        private Button buttonSupprimer;
        private Button buttonAjouter;
        private Button buttonValider;
        private ToolStripStatusLabel labelErreur;
    }
}