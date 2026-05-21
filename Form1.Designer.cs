namespace YapayZekaAsistan
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnGeri = new Button();
            labelTitle = new Label();
            pnlMenu = new Panel();
            btnDonusturucu = new Button();
            btnHaftalikPlan = new Button();
            btnDoviz = new Button();
            btnGoogleArama = new Button();
            btnHavaDurumu = new Button();
            pnlIslemAlani = new Panel();
            pnlDonusturucuGrup = new Panel();
            cmbHedef = new ComboBox();
            lblTo = new Label();
            cmbKaynak = new ComboBox();
            btnIslem = new Button();
            txtGiris1 = new TextBox();
            lblBaslik = new Label();
            txtSonuc = new RichTextBox();
            pnlHeader.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlIslemAlani.SuspendLayout();
            pnlDonusturucuGrup.SuspendLayout();
            SuspendLayout();

            
            pnlHeader.BackColor = Color.FromArgb(76, 29, 149);
            pnlHeader.Controls.Add(btnGeri);
            pnlHeader.Controls.Add(labelTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(880, 55);
            pnlHeader.TabIndex = 3;

            
            btnGeri.BackColor = Color.FromArgb(124, 58, 237);
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGeri.ForeColor = Color.White;
            btnGeri.Location = new Point(770, 11);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(95, 33);
            btnGeri.TabIndex = 1;
            btnGeri.Text = "← MENU";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Visible = false;
            btnGeri.Click += btnGeri_Click;

            
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(14, 13);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(292, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Powered By Eyup Tekce";

            
            pnlMenu.Controls.Add(btnDonusturucu);
            pnlMenu.Controls.Add(btnHaftalikPlan);
            pnlMenu.Controls.Add(btnDoviz = new Button());
            pnlMenu.Controls.Add(btnGoogleArama);
            pnlMenu.Controls.Add(btnHavaDurumu);
            pnlMenu.Location = new Point(14, 70);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(851, 110);
            pnlMenu.TabIndex = 4;

            
            btnDonusturucu.BackColor = Color.FromArgb(31, 41, 55);
            btnDonusturucu.FlatStyle = FlatStyle.Flat;
            btnDonusturucu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDonusturucu.ForeColor = Color.White;
            btnDonusturucu.Location = new Point(684, 15);
            btnDonusturucu.Name = "btnDonusturucu";
            btnDonusturucu.Size = new Size(150, 75);
            btnDonusturucu.TabIndex = 4;
            btnDonusturucu.Text = "FORMAT\r\nCONVERTER";
            btnDonusturucu.UseVisualStyleBackColor = false;
            btnDonusturucu.Click += btnDonusturucu_Click;

            
            btnHaftalikPlan.BackColor = Color.FromArgb(31, 41, 55);
            btnHaftalikPlan.FlatStyle = FlatStyle.Flat;
            btnHaftalikPlan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnHaftalikPlan.ForeColor = Color.White;
            btnHaftalikPlan.Location = new Point(516, 15);
            btnHaftalikPlan.Name = "btnHaftalikPlan";
            btnHaftalikPlan.Size = new Size(150, 75);
            btnHaftalikPlan.TabIndex = 3;
            btnHaftalikPlan.Text = "HTML WEEKLY\r\nPLANNER";
            btnHaftalikPlan.UseVisualStyleBackColor = false;
            btnHaftalikPlan.Click += btnHaftalikPlan_Click;

           
            btnDoviz.BackColor = Color.FromArgb(31, 41, 55);
            btnDoviz.FlatStyle = FlatStyle.Flat;
            btnDoviz.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDoviz.ForeColor = Color.White;
            btnDoviz.Location = new Point(349, 15);
            btnDoviz.Name = "btnDoviz";
            btnDoviz.Size = new Size(150, 75);
            btnDoviz.TabIndex = 2;
            btnDoviz.Text = "CURRENCY\r\n RATES";
            btnDoviz.UseVisualStyleBackColor = false;
            btnDoviz.Click += btnDoviz_Click;

            
            btnGoogleArama.BackColor = Color.FromArgb(31, 41, 55);
            btnGoogleArama.FlatStyle = FlatStyle.Flat;
            btnGoogleArama.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnGoogleArama.ForeColor = Color.White;
            btnGoogleArama.Location = new Point(182, 15);
            btnGoogleArama.Name = "btnGoogleArama";
            btnGoogleArama.Size = new Size(150, 75);
            btnGoogleArama.TabIndex = 1;
            btnGoogleArama.Text = "GOOGLE\r\nREQUEST SEARCH";
            btnGoogleArama.UseVisualStyleBackColor = false;
            btnGoogleArama.Click += btnGoogleArama_Click;

            
            btnHavaDurumu.BackColor = Color.FromArgb(31, 41, 55);
            btnHavaDurumu.FlatStyle = FlatStyle.Flat;
            btnHavaDurumu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnHavaDurumu.ForeColor = Color.White;
            btnHavaDurumu.Location = new Point(15, 15);
            btnHavaDurumu.Name = "btnHavaDurumu";
            btnHavaDurumu.Size = new Size(150, 75);
            btnHavaDurumu.TabIndex = 0;
            btnHavaDurumu.Text = "WEATHER\r\nSTATUS";
            btnHavaDurumu.UseVisualStyleBackColor = false;
            btnHavaDurumu.Click += btnHavaDurumu_Click;

            
            pnlIslemAlani.Controls.Add(pnlDonusturucuGrup);
            pnlIslemAlani.Controls.Add(btnIslem);
            pnlIslemAlani.Controls.Add(txtGiris1);
            pnlIslemAlani.Controls.Add(lblBaslik);
            pnlIslemAlani.Location = new Point(14, 70);
            pnlIslemAlani.Name = "pnlIslemAlani";
            pnlIslemAlani.Size = new Size(851, 110);
            pnlIslemAlani.TabIndex = 5;
            pnlIslemAlani.Visible = false;

            
            pnlDonusturucuGrup.Controls.Add(cmbHedef);
            pnlDonusturucuGrup.Controls.Add(lblTo);
            pnlDonusturucuGrup.Controls.Add(cmbKaynak);
            pnlDonusturucuGrup.Location = new Point(15, 49);
            pnlDonusturucuGrup.Name = "pnlDonusturucuGrup";
            pnlDonusturucuGrup.Size = new Size(499, 44);
            pnlDonusturucuGrup.TabIndex = 4;
            pnlDonusturucuGrup.Visible = false;

            
            cmbHedef.BackColor = Color.FromArgb(31, 41, 55);
            cmbHedef.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHedef.FlatStyle = FlatStyle.Flat;
            cmbHedef.Font = new Font("Segoe UI", 10F);
            cmbHedef.ForeColor = Color.White;
            cmbHedef.FormattingEnabled = true;
            cmbHedef.Location = new Point(220, 7);
            cmbHedef.Name = "cmbHedef";
            cmbHedef.Size = new Size(121, 31);
            cmbHedef.TabIndex = 3;

            
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTo.ForeColor = Color.White;
            lblTo.Location = new Point(150, 10);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(41, 25);
            lblTo.TabIndex = 1;
            lblTo.Text = " TO ";


            cmbKaynak.BackColor = Color.FromArgb(31, 41, 55);
            cmbKaynak.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKaynak.FlatStyle = FlatStyle.Flat;
            cmbKaynak.Font = new Font("Segoe UI", 10F);
            cmbKaynak.ForeColor = Color.White;
            cmbKaynak.FormattingEnabled = true;
            cmbKaynak.Location = new Point(3, 7);
            cmbKaynak.Name = "cmbKaynak";
            cmbKaynak.Size = new Size(121, 31);
            cmbKaynak.TabIndex = 0;
            cmbKaynak.SelectedIndexChanged += CmbKaynak_SelectedIndexChanged;

            
            btnIslem.BackColor = Color.FromArgb(124, 58, 237);
            btnIslem.FlatStyle = FlatStyle.Flat;
            btnIslem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnIslem.ForeColor = Color.White;
            btnIslem.Location = new Point(644, 49);
            btnIslem.Name = "btnIslem";
            btnIslem.Size = new Size(190, 44);
            btnIslem.TabIndex = 3;
            btnIslem.Text = "EXECUTE";
            btnIslem.UseVisualStyleBackColor = false;
            btnIslem.Click += btnIslem_Click;

            txtGiris1.BackColor = Color.FromArgb(31, 41, 55);
            txtGiris1.BorderStyle = BorderStyle.FixedSingle;
            txtGiris1.Font = new Font("Segoe UI", 11F);
            txtGiris1.ForeColor = Color.White;
            txtGiris1.Location = new Point(15, 55);
            txtGiris1.Name = "txtGiris1";
            txtGiris1.Size = new Size(610, 32);
            txtGiris1.TabIndex = 1;

            
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.White;
            lblBaslik.Location = new Point(11, 11);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(107, 28);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Action Workspace";

            
            txtSonuc.BackColor = Color.FromArgb(17, 24, 39);
            txtSonuc.BorderStyle = BorderStyle.None;
            txtSonuc.Font = new Font("Consolas", 11F);
            txtSonuc.ForeColor = Color.FromArgb(34, 197, 94);
            txtSonuc.Location = new Point(14, 200);
            txtSonuc.Name = "txtSonuc";
            txtSonuc.ReadOnly = true;
            txtSonuc.Size = new Size(851, 325);
            txtSonuc.TabIndex = 6;
            txtSonuc.Text = "Please select an action from the menu above.";

            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            this.pnlIslemAlani.Location = new System.Drawing.Point(14, 70);
            this.pnlIslemAlani.Size = new System.Drawing.Size(851, 110);
            ClientSize = new Size(880, 545);
            Controls.Add(txtSonuc);
            Controls.Add(pnlMenu);
            Controls.Add(pnlIslemAlani);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AI Agent Multi-Tool v2.6";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlIslemAlani.ResumeLayout(false);
            pnlIslemAlani.PerformLayout();
            pnlDonusturucuGrup.ResumeLayout(false);
            pnlDonusturucuGrup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlHeader;
        private Label labelTitle;
        private Panel pnlMenu;
        private Button btnHavaDurumu;
        private Button btnDonusturucu;
        private Button btnHaftalikPlan;
        private Button btnDoviz;
        private Button btnGoogleArama;
        private Panel pnlIslemAlani;
        private Label lblBaslik;
        private TextBox txtGiris1;
        private Button btnIslem;
        private RichTextBox txtSonuc;
        private Button btnGeri;
        private Panel pnlDonusturucuGrup;
        private ComboBox cmbKaynak;
        private ComboBox cmbHedef;
        private Label lblTo;
    }
}
