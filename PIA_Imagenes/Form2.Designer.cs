
namespace _1er_Avance_PI
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label2 = new System.Windows.Forms.Label();
            this.loadImage = new System.Windows.Forms.Button();
            this.imgResult = new System.Windows.Forms.PictureBox();
            this.imgOriginal = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numCaras = new System.Windows.Forms.Label();
            this.Contador = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelRuta = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnPausar = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnVCargar = new System.Windows.Forms.Button();
            this.histogramBox1 = new Emgu.CV.UI.HistogramBox();
            this.histogramBox2 = new Emgu.CV.UI.HistogramBox();
            this.histogramBox3 = new Emgu.CV.UI.HistogramBox();
            this.histogramBox4 = new Emgu.CV.UI.HistogramBox();
            this.histogramBox5 = new Emgu.CV.UI.HistogramBox();
            this.histogramBox6 = new Emgu.CV.UI.HistogramBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOriginal)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 305);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Histograma";
            // 
            // loadImage
            // 
            this.loadImage.BackColor = System.Drawing.SystemColors.Window;
            this.loadImage.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadImage.ForeColor = System.Drawing.SystemColors.InfoText;
            this.loadImage.Location = new System.Drawing.Point(19, 5);
            this.loadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(130, 32);
            this.loadImage.TabIndex = 27;
            this.loadImage.Text = "Cargar Imagen";
            this.loadImage.UseVisualStyleBackColor = false;
            this.loadImage.Click += new System.EventHandler(this.Button1_Click);
            // 
            // imgResult
            // 
            this.imgResult.Location = new System.Drawing.Point(497, 305);
            this.imgResult.Margin = new System.Windows.Forms.Padding(4);
            this.imgResult.Name = "imgResult";
            this.imgResult.Size = new System.Drawing.Size(1023, 443);
            this.imgResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgResult.TabIndex = 25;
            this.imgResult.TabStop = false;
            this.imgResult.Click += new System.EventHandler(this.imgResult_Click);
            this.imgResult.Paint += new System.Windows.Forms.PaintEventHandler(this.ImgR_Paint);
            // 
            // imgOriginal
            // 
            this.imgOriginal.Location = new System.Drawing.Point(12, 42);
            this.imgOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.imgOriginal.Name = "imgOriginal";
            this.imgOriginal.Size = new System.Drawing.Size(471, 239);
            this.imgOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOriginal.TabIndex = 24;
            this.imgOriginal.TabStop = false;
            this.imgOriginal.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(1543, -47);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 883);
            this.panel1.TabIndex = 23;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkCyan;
            this.button6.Location = new System.Drawing.Point(0, 606);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(204, 71);
            this.button6.TabIndex = 11;
            this.button6.Text = "Aberración Cromática";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkCyan;
            this.button2.Location = new System.Drawing.Point(0, 369);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 69);
            this.button2.TabIndex = 6;
            this.button2.Text = "Sobel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkCyan;
            this.button3.Location = new System.Drawing.Point(0, 487);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 71);
            this.button3.TabIndex = 7;
            this.button3.Text = "Sepia";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkCyan;
            this.button5.Location = new System.Drawing.Point(0, 133);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(204, 69);
            this.button5.TabIndex = 9;
            this.button5.Text = "Escala de Grises";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkCyan;
            this.button4.Location = new System.Drawing.Point(-3, 252);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 69);
            this.button4.TabIndex = 8;
            this.button4.Text = "Negativo";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CadetBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagenToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.manualToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1753, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imagenToolStripMenuItem
            // 
            this.imagenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem});
            this.imagenToolStripMenuItem.Name = "imagenToolStripMenuItem";
            this.imagenToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.imagenToolStripMenuItem.Text = "Imagen";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.cargarToolStripMenuItem.Text = "Cargar";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem1});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // videoToolStripMenuItem1
            // 
            this.videoToolStripMenuItem1.Name = "videoToolStripMenuItem1";
            this.videoToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.videoToolStripMenuItem1.Text = "Cargar Video";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(920, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Histograma con filtro";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 33);
            this.button1.TabIndex = 31;
            this.button1.Text = "Camara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(286, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 24);
            this.comboBox1.TabIndex = 32;
            // 
            // numCaras
            // 
            this.numCaras.AutoSize = true;
            this.numCaras.Location = new System.Drawing.Point(494, 284);
            this.numCaras.Name = "numCaras";
            this.numCaras.Size = new System.Drawing.Size(49, 17);
            this.numCaras.TabIndex = 33;
            this.numCaras.Text = "Caras:";
            this.numCaras.Click += new System.EventHandler(this.label3_Click);
            // 
            // Contador
            // 
            this.Contador.AutoSize = true;
            this.Contador.Location = new System.Drawing.Point(549, 284);
            this.Contador.Name = "Contador";
            this.Contador.Size = new System.Drawing.Size(46, 17);
            this.Contador.TabIndex = 34;
            this.Contador.Text = "label3";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(562, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(186, 33);
            this.button7.TabIndex = 36;
            this.button7.Text = "Cargar Histograma";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Red";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1359, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Blue";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 722);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 44;
            this.label5.Text = "Blue";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 533);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "Green";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(990, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Green";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(637, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 47;
            this.label8.Text = "Red";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1741, 861);
            this.tabControl1.TabIndex = 48;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.histogramBox6);
            this.tabPage1.Controls.Add(this.histogramBox5);
            this.tabPage1.Controls.Add(this.histogramBox4);
            this.tabPage1.Controls.Add(this.histogramBox3);
            this.tabPage1.Controls.Add(this.histogramBox2);
            this.tabPage1.Controls.Add(this.histogramBox1);
            this.tabPage1.Controls.Add(this.loadImage);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.imgOriginal);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.imgResult);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.numCaras);
            this.tabPage1.Controls.Add(this.Contador);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1733, 832);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelRuta);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabPage2.Controls.Add(this.btnPausar);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.btnVCargar);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1733, 832);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelRuta
            // 
            this.labelRuta.AutoSize = true;
            this.labelRuta.Location = new System.Drawing.Point(698, 30);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Size = new System.Drawing.Size(54, 17);
            this.labelRuta.TabIndex = 6;
            this.labelRuta.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(649, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ruta:";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(495, 24);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(148, 28);
            this.button11.TabIndex = 4;
            this.button11.Text = "Parar";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(30, 76);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(459, 339);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // btnPausar
            // 
            this.btnPausar.Location = new System.Drawing.Point(340, 24);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(149, 31);
            this.btnPausar.TabIndex = 2;
            this.btnPausar.Text = "Pausar";
            this.btnPausar.UseVisualStyleBackColor = true;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(185, 24);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(149, 30);
            this.button9.TabIndex = 1;
            this.button9.Text = "Reproducir";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnVCargar
            // 
            this.btnVCargar.Location = new System.Drawing.Point(30, 23);
            this.btnVCargar.Name = "btnVCargar";
            this.btnVCargar.Size = new System.Drawing.Size(149, 31);
            this.btnVCargar.TabIndex = 0;
            this.btnVCargar.Text = "Cargar";
            this.btnVCargar.UseVisualStyleBackColor = true;
            this.btnVCargar.Click += new System.EventHandler(this.btnVCargar_Click);
            // 
            // histogramBox1
            // 
            this.histogramBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox1.Location = new System.Drawing.Point(115, 289);
            this.histogramBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramBox1.Name = "histogramBox1";
            this.histogramBox1.Size = new System.Drawing.Size(335, 169);
            this.histogramBox1.TabIndex = 48;
            // 
            // histogramBox2
            // 
            this.histogramBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox2.Location = new System.Drawing.Point(115, 466);
            this.histogramBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramBox2.Name = "histogramBox2";
            this.histogramBox2.Size = new System.Drawing.Size(335, 169);
            this.histogramBox2.TabIndex = 49;
            // 
            // histogramBox3
            // 
            this.histogramBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox3.Location = new System.Drawing.Point(115, 656);
            this.histogramBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramBox3.Name = "histogramBox3";
            this.histogramBox3.Size = new System.Drawing.Size(335, 169);
            this.histogramBox3.TabIndex = 50;
            // 
            // histogramBox4
            // 
            this.histogramBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox4.Location = new System.Drawing.Point(491, 60);
            this.histogramBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramBox4.Name = "histogramBox4";
            this.histogramBox4.Size = new System.Drawing.Size(335, 169);
            this.histogramBox4.TabIndex = 51;
            // 
            // histogramBox5
            // 
            this.histogramBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox5.Location = new System.Drawing.Point(848, 60);
            this.histogramBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramBox5.Name = "histogramBox5";
            this.histogramBox5.Size = new System.Drawing.Size(335, 169);
            this.histogramBox5.TabIndex = 52;
            // 
            // histogramBox6
            // 
            this.histogramBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox6.Location = new System.Drawing.Point(1201, 60);
            this.histogramBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramBox6.Name = "histogramBox6";
            this.histogramBox6.Size = new System.Drawing.Size(335, 169);
            this.histogramBox6.TabIndex = 53;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1753, 904);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOriginal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.PictureBox imgResult;
        private System.Windows.Forms.PictureBox imgOriginal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label numCaras;
        private System.Windows.Forms.Label Contador;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnVCargar;
        private System.Windows.Forms.Button button11;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label labelRuta;
        private System.Windows.Forms.Label label9;
        private Emgu.CV.UI.HistogramBox histogramBox3;
        private Emgu.CV.UI.HistogramBox histogramBox2;
        private Emgu.CV.UI.HistogramBox histogramBox1;
        private Emgu.CV.UI.HistogramBox histogramBox6;
        private Emgu.CV.UI.HistogramBox histogramBox5;
        private Emgu.CV.UI.HistogramBox histogramBox4;
        //private Emgu.CV.UI.HistogramBox histogramBox6;
        //private Emgu.CV.UI.HistogramBox histogramBox5;
        //private Emgu.CV.UI.HistogramBox histogramBox4;
        //private Emgu.CV.UI.HistogramBox histogramBox3;
        //private Emgu.CV.UI.HistogramBox histogramBox2;
        //private Emgu.CV.UI.HistogramBox histogramBox1;
        //private Emgu.CV.UI.HistogramBox histogramBox1;
        //private Emgu.CV.UI.HistogramBox histogramBox6;
        //private Emgu.CV.UI.HistogramBox histogramBox5;
        //private Emgu.CV.UI.HistogramBox histogramBox4;
        //private Emgu.CV.UI.HistogramBox histogramBox3;
        //private Emgu.CV.UI.HistogramBox histogramBox2;
        //private Emgu.CV.UI.HistogramBox histogramBox1;
        //private Emgu.CV.UI.HistogramBox histogramBox3;
        //private Emgu.CV.UI.HistogramBox histogramBox2;
        //private Emgu.CV.UI.HistogramBox histogramBox6;
        //private Emgu.CV.UI.HistogramBox histogramBox5;
        //private Emgu.CV.UI.HistogramBox histogramBox4;
    }
}