namespace OOP_Project_Concept2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            panel_Card = new BorderPanel();
            label_Title = new Label();
            label_TotalHint = new Label();
            textBox_Total = new TextBox();
            panel_Div1 = new Panel();
            label_Sons = new Label();
            num_Sons = new NumericUpDown();
            label_Daughters = new Label();
            num_Daughters = new NumericUpDown();
            panel_Div2 = new Panel();
            label_Gender = new Label();
            rb_Male = new RadioButton();
            rb_Female = new RadioButton();
            panel_Div3 = new Panel();
            Chk_PartnerAlive = new CheckBox();
            chk_Mother = new CheckBox();
            chk_Father = new CheckBox();
            panel_Div4 = new Panel();
            label_Brothers = new Label();
            num_FullBrothers = new NumericUpDown();
            label_Sisters = new Label();
            num_FullSisters = new NumericUpDown();
            panel_Div5 = new Panel();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel_Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Sons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Daughters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_FullBrothers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_FullSisters).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackgroundImage = Properties.Resources.arch_pattern;
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel_Card, 1, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // panel_Card
            // 
            panel_Card.BackColor = Color.FromArgb(8, 22, 48);
            panel_Card.BorderColor = Color.FromArgb(80, 68, 34);
            panel_Card.BorderRadius = 14;
            panel_Card.BorderThickness = 1;
            panel_Card.Controls.Add(label_Title);
            panel_Card.Controls.Add(label_TotalHint);
            panel_Card.Controls.Add(textBox_Total);
            panel_Card.Controls.Add(panel_Div1);
            panel_Card.Controls.Add(label_Sons);
            panel_Card.Controls.Add(num_Sons);
            panel_Card.Controls.Add(label_Daughters);
            panel_Card.Controls.Add(num_Daughters);
            panel_Card.Controls.Add(panel_Div2);
            panel_Card.Controls.Add(label_Gender);
            panel_Card.Controls.Add(rb_Male);
            panel_Card.Controls.Add(rb_Female);
            panel_Card.Controls.Add(panel_Div3);
            panel_Card.Controls.Add(Chk_PartnerAlive);
            panel_Card.Controls.Add(chk_Mother);
            panel_Card.Controls.Add(chk_Father);
            panel_Card.Controls.Add(panel_Div4);
            panel_Card.Controls.Add(label_Brothers);
            panel_Card.Controls.Add(num_FullBrothers);
            panel_Card.Controls.Add(label_Sisters);
            panel_Card.Controls.Add(num_FullSisters);
            panel_Card.Controls.Add(panel_Div5);
            panel_Card.Controls.Add(button1);
            resources.ApplyResources(panel_Card, "panel_Card");
            panel_Card.Name = "panel_Card";
            panel_Card.Paint += panel_Card_Paint;
            // 
            // label_Title
            // 
            resources.ApplyResources(label_Title, "label_Title");
            label_Title.ForeColor = Color.FromArgb(196, 160, 80);
            label_Title.Name = "label_Title";
            // 
            // label_TotalHint
            // 
            resources.ApplyResources(label_TotalHint, "label_TotalHint");
            label_TotalHint.ForeColor = Color.FromArgb(168, 144, 96);
            label_TotalHint.Name = "label_TotalHint";
            // 
            // textBox_Total
            // 
            textBox_Total.BackColor = Color.FromArgb(18, 35, 62);
            textBox_Total.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_Total, "textBox_Total");
            textBox_Total.ForeColor = Color.FromArgb(232, 217, 181);
            textBox_Total.Name = "textBox_Total";
            // 
            // panel_Div1
            // 
            panel_Div1.BackColor = Color.FromArgb(68, 58, 30);
            resources.ApplyResources(panel_Div1, "panel_Div1");
            panel_Div1.Name = "panel_Div1";
            // 
            // label_Sons
            // 
            resources.ApplyResources(label_Sons, "label_Sons");
            label_Sons.ForeColor = Color.FromArgb(168, 144, 96);
            label_Sons.Name = "label_Sons";
            // 
            // num_Sons
            // 
            num_Sons.BackColor = Color.FromArgb(18, 35, 62);
            resources.ApplyResources(num_Sons, "num_Sons");
            num_Sons.ForeColor = Color.FromArgb(232, 217, 181);
            num_Sons.Name = "num_Sons";
            // 
            // label_Daughters
            // 
            resources.ApplyResources(label_Daughters, "label_Daughters");
            label_Daughters.ForeColor = Color.FromArgb(168, 144, 96);
            label_Daughters.Name = "label_Daughters";
            // 
            // num_Daughters
            // 
            num_Daughters.BackColor = Color.FromArgb(18, 35, 62);
            resources.ApplyResources(num_Daughters, "num_Daughters");
            num_Daughters.ForeColor = Color.FromArgb(232, 217, 181);
            num_Daughters.Name = "num_Daughters";
            // 
            // panel_Div2
            // 
            panel_Div2.BackColor = Color.FromArgb(68, 58, 30);
            resources.ApplyResources(panel_Div2, "panel_Div2");
            panel_Div2.Name = "panel_Div2";
            // 
            // label_Gender
            // 
            resources.ApplyResources(label_Gender, "label_Gender");
            label_Gender.ForeColor = Color.FromArgb(168, 144, 96);
            label_Gender.Name = "label_Gender";
            // 
            // rb_Male
            // 
            resources.ApplyResources(rb_Male, "rb_Male");
            rb_Male.BackColor = Color.Transparent;
            rb_Male.Checked = true;
            rb_Male.FlatAppearance.BorderColor = Color.FromArgb(168, 144, 96);
            rb_Male.FlatAppearance.CheckedBackColor = Color.FromArgb(45, 40, 18);
            rb_Male.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 24, 10);
            rb_Male.ForeColor = Color.FromArgb(168, 144, 96);
            rb_Male.Name = "rb_Male";
            rb_Male.TabStop = true;
            rb_Male.UseVisualStyleBackColor = false;
            rb_Male.CheckedChanged += rb_Male_CheckedChanged_1;
            // 
            // rb_Female
            // 
            resources.ApplyResources(rb_Female, "rb_Female");
            rb_Female.BackColor = Color.Transparent;
            rb_Female.FlatAppearance.BorderColor = Color.FromArgb(168, 144, 96);
            rb_Female.FlatAppearance.CheckedBackColor = Color.FromArgb(45, 40, 18);
            rb_Female.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 24, 10);
            rb_Female.ForeColor = Color.FromArgb(168, 144, 96);
            rb_Female.Name = "rb_Female";
            rb_Female.UseVisualStyleBackColor = false;
            rb_Female.CheckedChanged += rb_Female_CheckedChanged_1;
            // 
            // panel_Div3
            // 
            panel_Div3.BackColor = Color.FromArgb(68, 58, 30);
            resources.ApplyResources(panel_Div3, "panel_Div3");
            panel_Div3.Name = "panel_Div3";
            // 
            // Chk_PartnerAlive
            // 
            Chk_PartnerAlive.BackColor = Color.Transparent;
            resources.ApplyResources(Chk_PartnerAlive, "Chk_PartnerAlive");
            Chk_PartnerAlive.ForeColor = Color.FromArgb(232, 217, 181);
            Chk_PartnerAlive.Name = "Chk_PartnerAlive";
            Chk_PartnerAlive.UseVisualStyleBackColor = false;
            // 
            // chk_Mother
            // 
            chk_Mother.BackColor = Color.Transparent;
            resources.ApplyResources(chk_Mother, "chk_Mother");
            chk_Mother.ForeColor = Color.FromArgb(232, 217, 181);
            chk_Mother.Name = "chk_Mother";
            chk_Mother.UseVisualStyleBackColor = false;
            // 
            // chk_Father
            // 
            chk_Father.BackColor = Color.Transparent;
            resources.ApplyResources(chk_Father, "chk_Father");
            chk_Father.ForeColor = Color.FromArgb(232, 217, 181);
            chk_Father.Name = "chk_Father";
            chk_Father.UseVisualStyleBackColor = false;
            // 
            // panel_Div4
            // 
            panel_Div4.BackColor = Color.FromArgb(68, 58, 30);
            resources.ApplyResources(panel_Div4, "panel_Div4");
            panel_Div4.Name = "panel_Div4";
            // 
            // label_Brothers
            // 
            resources.ApplyResources(label_Brothers, "label_Brothers");
            label_Brothers.ForeColor = Color.FromArgb(168, 144, 96);
            label_Brothers.Name = "label_Brothers";
            // 
            // num_FullBrothers
            // 
            num_FullBrothers.BackColor = Color.FromArgb(18, 35, 62);
            resources.ApplyResources(num_FullBrothers, "num_FullBrothers");
            num_FullBrothers.ForeColor = Color.FromArgb(232, 217, 181);
            num_FullBrothers.Name = "num_FullBrothers";
            // 
            // label_Sisters
            // 
            resources.ApplyResources(label_Sisters, "label_Sisters");
            label_Sisters.ForeColor = Color.FromArgb(168, 144, 96);
            label_Sisters.Name = "label_Sisters";
            // 
            // num_FullSisters
            // 
            num_FullSisters.BackColor = Color.FromArgb(18, 35, 62);
            resources.ApplyResources(num_FullSisters, "num_FullSisters");
            num_FullSisters.ForeColor = Color.FromArgb(232, 217, 181);
            num_FullSisters.Name = "num_FullSisters";
            // 
            // panel_Div5
            // 
            panel_Div5.BackColor = Color.FromArgb(68, 58, 30);
            resources.ApplyResources(panel_Div5, "panel_Div5");
            panel_Div5.Name = "panel_Div5";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(196, 160, 80);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(button1, "button1");
            button1.ForeColor = Color.FromArgb(8, 22, 48);
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 31, 58);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.FromArgb(232, 217, 181);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel_Card.ResumeLayout(false);
            panel_Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_Sons).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Daughters).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_FullBrothers).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_FullSisters).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private BorderPanel panel_Card;
        private Label label_Title;
        private Label label_TotalHint;
        private TextBox textBox_Total;
        private Panel panel_Div1;
        private Label label_Sons;
        private NumericUpDown num_Sons;
        private Label label_Daughters;
        private NumericUpDown num_Daughters;
        private Panel panel_Div2;
        private Label label_Gender;
        private RadioButton rb_Male;
        private RadioButton rb_Female;
        private Panel panel_Div3;
        private CheckBox Chk_PartnerAlive;
        private CheckBox chk_Mother;
        private CheckBox chk_Father;
        private Panel panel_Div4;
        private Label label_Brothers;
        private NumericUpDown num_FullBrothers;
        private Label label_Sisters;
        private NumericUpDown num_FullSisters;
        private Panel panel_Div5;
        private Button button1;
        private Label label1;
    }
}
