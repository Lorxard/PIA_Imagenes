using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;

namespace _1er_Avance_PI
{
    public partial class Form2 : Form
    {

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private Bitmap original;
        private int caras =0;

        
        private bool CamActiva= false;
        private Bitmap resultante;
        private int[] histograma = new int[256];
        private int[,] conv3x3 = new int[3, 3];

        private int[] histograma2;
        private int mayor;

        int filtro=0;

        private Color[] colorCamCapture = new Color[10];

        private bool aplicado = false;

        bool isPause = false;

        double TotalFrame;
        double Fps;
        int FrameNo;


        Image<Bgr, byte> _InputImage;

        bool isVideo = false;
        Bitmap Video;

        VideoCapture videoCapture;
        private string ruta = "";

        //private int factor;
        //private int offset;

        private int anchoVentana, altoVentana;

        private bool HayDispositivos;
        private FilterInfoCollection MiDispositivos;
        private VideoCaptureDevice MiWebCam = null;
        public Form2()
        {
            InitializeComponent();

            resultante = new Bitmap(800, 600);

            anchoVentana = 800;
            altoVentana = 600;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CamActiva)
            {
                CerrarWebCam();
                CamActiva = false;
            }
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargaDispositivos();
        }


        private void ImgR_Paint(object sender, PaintEventArgs e)
        {

            if (resultante != null)
            {


            }
            /* if (imgOriginal.Image != null)
             {   // the 'real thing':
                 Bitmap bmp = new Bitmap(pictureBox1.Image);
                 Color colour = bmp.GetPixel(e.X, e.Y);
                 label1.Text = colour.ToString();
                 bmp.Dispose();
             }
             */
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            if (CamActiva)
            {
                CerrarWebCam();
                CamActiva = false;
            }

            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = "C:\\";
            getImage.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*. jpeg| PNG(*.png)|*.png|GIF (*.gif)|*.gif";

            if (getImage.ShowDialog() == DialogResult.OK)
            {
                imgOriginal.Image = new Bitmap(getImage.FileName);
                imgResult.Image = new Bitmap(getImage.FileName);
                Bitmap copyBitmap = (Bitmap)imgOriginal.Image;
               // Test(copyBitmap,1);





                //imgOriginal.ImageLocation = getImage.FileName;
                //imgResult.ImageLocation = getImage.FileName;

                //imgOriginal.Image = new Bitmap(imgOriginal.ClientSize.Width, imgOriginal.ClientSize.Height);
                //imgResult.Image = new Bitmap(imgResult.ClientSize.Width, imgResult.ClientSize.Height);

                //original = (Bitmap)imgOriginal.Image;
                //resultante = (Bitmap)imgResult.Image;
                //Grises(resultante);


                // txtRutaImagen.Text = getImage.FileName;
            }
            else
            {
                MessageBox.Show("No se selecciono imagen", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CargaDispositivos()
        {
            MiDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MiDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MiDispositivos.Count; i++)
                    comboBox1.Items.Add(MiDispositivos[i].Name.ToString());
                comboBox1.Text = MiDispositivos[0].ToString();


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CamActiva)
            {
                CerrarWebCam();
                CamActiva = false;
            }


            //int i = comboBox1.SelectedIndex;
            //string NombreVideo = MiDispositivos[i].MonikerString;
            try
            {
                int i = comboBox1.SelectedIndex;
                string NombreVideo = MiDispositivos[i].MonikerString;
                MiWebCam = new VideoCaptureDevice(NombreVideo);
                MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
                MiWebCam.Start();
                CamActiva = true;
            }
            catch
            {
                MessageBox.Show("No se selecciono camara", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //MiWebCam = new VideoCaptureDevice(NombreVideo);
            //MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
            //MiWebCam.Start();
            //CamActiva = true;


        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();

            //int x, y = 0;

            //Color rColor = new Color();
            //Color oColor = new Color();

            //float g = 0;

            //for (x = 0; x < Imagen.Width; x++)
            //{
            //    for (y = 0; y < Imagen.Height; y++)
            //    {
            //        oColor = Imagen.GetPixel(x, y);

            //        g = oColor.R * 0.267f + oColor.G * 0.678f + oColor.B * 0.0593f;
            //        if (g > 255)
            //            g = 255;

            //        rColor = Color.FromArgb((int)g, (int)g, (int)g);
            //        Imagen.SetPixel(x, y, rColor);
            //    }

            //}


            Image<Rgb, byte> grayImage = new Image<Rgb, byte>(Imagen);
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.4, 0);
            caras = 0;

            foreach (Rectangle rectangulo in rectangles)
            {
                
                using (Graphics graphics = Graphics.FromImage(Imagen))
                {
                    using (Pen lapiz = new Pen(Color.Blue, 1))
                    {
                        SolidBrush s = new SolidBrush(Color.Blue);
                        graphics.DrawRectangle(lapiz, rectangulo);
                        FontFamily ff = new FontFamily("Arial");
                        System.Drawing.Font font = new System.Drawing.Font(ff, 50);
                        graphics.DrawString("Caras:" + caras.ToString(), font, s, new PointF(20, 20));

                    }
                }
                caras++;

            }
            //if (InvokeRequired)
            //    Invoke(new Action(() => Contador.Text = Contador.ToString()));


            imgOriginal.Image = Imagen;
            imgResult.Image = Imagen;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap (imgOriginal.Image);
            Grises(copyBitmap);
            imgResult.Image = copyBitmap;
            aplicado = true;
            //histo(copyBitmap);
            //Test(copyBitmap,2);

        }

        public void Grises(Bitmap bmp)
        {
            int x,y = 0;

            Color rColor = new Color();
            Color oColor = new Color();

            float g = 0;

            for (x=0; x<bmp.Width;x++)
            {
                for (y=0; y < bmp.Height; y++)
                {
                    oColor = bmp.GetPixel(x,y);

                    g = oColor.R * 0.267f + oColor.G * 0.678f + oColor.B * 0.0593f;
                    if (g > 255)
                        g = 255;

                    rColor = Color.FromArgb((int)g, (int)g, (int)g);
                    bmp.SetPixel(x, y, rColor);
                }

            }



            //for (int i = 0; i < bmp.Height; i++)
            //{
            //    for (int j = 0; j < bmp.Width; j++)
            //    {
            //        Color color = bmp.GetPixel(j, i);
            //        int R = color.R;
            //        int G = color.G;
            //        int B = color.B;
            //        int gris = (R + G + B) / 3;

            //        bmp.SetPixel(j, i, Color.FromArgb(gris, gris, gris));
            //    }
            //}

        }
        public void Croma(Bitmap bmp)
        {
            int x, y = 0;
            int a = 4;

            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {

                    Color color = bmp.GetPixel(x, y);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;

                    G = bmp.GetPixel(x, y).G;

                    if (x + a < bmp.Width)
                    {
                        R = bmp.GetPixel(x + a, y).R;
                    }
                    else
                    {
                        R = 0;
                    }

                    if (x - a > 0)
                    {
                        B = bmp.GetPixel(x - a, y).B;
                    }
                    else
                    {
                        B = 0;
                    }


                    bmp.SetPixel(x, y, Color.FromArgb(R, G, B));

                }
            }


        }

        public void Negativo(Bitmap bmp)
        {

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color color = bmp.GetPixel(j, i);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;
                    Color newColor = Color.FromArgb(255 - R, 255 - G, 255 - B);

                    bmp.SetPixel(j, i, newColor);
                }
            }

        }

        public void Sepia(Bitmap bmp)
        {

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color color = bmp.GetPixel(j, i);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;

                    int sepiaRed = Convert.ToInt32(0.393 * R + 0.769 * G + 0.189 * B);

                    int sepiaGreen = Convert.ToInt32(0.349 * R + 0.686 * G + 0.168 * B);

                    int sepiaBlue = Convert.ToInt32(0.272 * R + 0.534 * G + 0.131 * B);

                    if (sepiaRed > 255)
                    {
                        sepiaRed = 255;
                    }
                    if (sepiaGreen > 255)
                    {
                        sepiaGreen = 255;
                    }
                    if (sepiaBlue > 255)
                    {
                        sepiaBlue = 255;
                    }

                    Color newColor = Color.FromArgb(sepiaRed, sepiaGreen, sepiaBlue);

                    bmp.SetPixel(j, i, newColor);
                }
            }

        }



        private void ConvGris(int[,] pMatriz, Bitmap pImage, int pInferior, int pSuperior)
        {
            int x = 0;
            int y = 0;
            int a = 0;
            int b = 0;
            Color oColor;
            int suma = 0;

            for (x = 1; x < pImage.Width - 1; x++)
            {
                for (y = 1; y < pImage.Height - 1; y++)
                {
                    suma = 0;
                    for (a = -1; a < 2; a++)
                    {
                        for (b = -1; b < 2; b++)
                        {
                            oColor = pImage.GetPixel(x + a, y + b);
                            suma = suma + (oColor.R * pMatriz[a + 1, b + 1]);

                        }

                    }
                    if (suma < pInferior)
                        suma = 0;
                    else if (suma > pSuperior)
                        suma = 255;

                    pImage.SetPixel(x, y, Color.FromArgb(suma, suma, suma));
                }

            }
            this.Invalidate();
        }

        public void Ruido(Bitmap bmp)
        {
            int x = 0;
            int y = 0;
            int porcentaje = 5;

            int rangoMin = 200;
            int rangoMax = 255;
            float pBrillo = 0;

            Random rnd = new Random();
            Color rColor;
            Color oColor;

            int r = 0;
            int g = 0;
            int b = 0;

            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {

                    if (rnd.Next(1, 100) <= porcentaje)
                    {
                        rColor = Color.FromArgb(rnd.Next(rangoMin, rangoMax),
                                                rnd.Next(rangoMin, rangoMax),
                                                rnd.Next(rangoMin, rangoMax));
                    }
                    else
                    {
                        rColor = bmp.GetPixel(x, y);
                    }
                    bmp.SetPixel(x, y, rColor);
                }
            }
        }


        private void imgResult_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
            Negativo(copyBitmap);
            imgResult.Image = copyBitmap;
            aplicado = true;
            //Test(copyBitmap, 2);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = (Bitmap)imgOriginal.Image;

            Ruido(copyBitmap);
            imgResult.Image = copyBitmap;
            aplicado = true;
            //Test(copyBitmap,2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
            Sepia(copyBitmap);
            imgResult.Image = copyBitmap;
            aplicado = true;
            //Test(copyBitmap,2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
            Croma(copyBitmap);
            imgResult.Image = copyBitmap;

            aplicado = true;
            //Test(copyBitmap, 2);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Test(Bitmap prueba,int op)
        {
            Bitmap bmp = prueba;
            int[] histogram_r = new int[256];
            int[] histogram_g = new int[256];
            int[] histogram_b = new int[256];
            float max = 0;
            float maxg = 0;
            float maxb = 0;


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {

                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];

                    int greenValue = bmp.GetPixel(i, j).G;
                    histogram_g[greenValue]++;
                    if (maxg < histogram_g[greenValue])
                        maxg = histogram_g[greenValue];

                    int blueValue = bmp.GetPixel(i, j).B;
                    histogram_b[blueValue]++;
                    if (maxb < histogram_b[blueValue])
                        maxb = histogram_b[blueValue];
                }
            }
            //282, 149
            int histHeight = 100;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Black,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }
            //if (op == 2)
            //    histoRR.Image = img;
            //else if (op == 1)
            //    histoOR.Image = img;

            Bitmap img2 = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img2))
            {
                for (int i = 0; i < histogram_g.Length; i++)
                {
                    float pct = histogram_g[i] / maxg;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Black,
                        new Point(i, img2.Height - 5),
                        new Point(i, img2.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }
            //if (op == 2)
            //    histoRG.Image = img2;
            //else if (op == 1)
            //    histoOG.Image = img2;

            Bitmap img3 = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img3))
            {
                for (int i = 0; i < histogram_b.Length; i++)
                {
                    float pct = histogram_b[i] / maxb;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Black,
                        new Point(i, img3.Height - 5),
                        new Point(i, img3.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }
            //if (op == 2)
            //    histoRB.Image = img3;
            //else if (op == 1)
            //    histoOB.Image = img3;


        }

        private void histo(Bitmap prueba)
        {
            int x, y = 0;
            Color rColor = new Color();

            for (x = 0; x < prueba.Width; x++)
            {
                for (y = 0; y < prueba.Height; y++)
                {

                    rColor = prueba.GetPixel(x, y);
                    histograma[rColor.R]++;
                }
            }
            int n ;

            mayor = 0;

            for (n =0; n < 256; n++)
            {
                if (histograma[n] > mayor)
                    mayor = histograma[n];
            }
            for (n = 0; n < 256; n++)
                histograma[n] = (int)((float)histograma[n] / (float)mayor * 256.0f);


        }

        public void histo2()
        {
           
            int n = 0;

            mayor = 0;

            for (n = 0; n < 256; n++)
            {
                if (histograma[n] > mayor)
                    mayor = histograma[n];
            }
            for (n = 0; n < 256; n++)
                histograma[n] = (int)((float)histograma[n] / (float)mayor * 256.0f);


        }

        private void dibujar()
        {
            int n = 0;
            //int altura = 0;
            int histHeight = 128;
            Bitmap img = new Bitmap(256, histHeight + 10);

            using (Graphics g = Graphics.FromImage(img))
            {
                Pen plumaH = new Pen(Color.Black);
                Pen plumaEjes = new Pen(Color.Coral);

                //g.DrawLine(plumaEjes, 19, 271, 277, 271);
                //g.DrawLine(plumaEjes, 19, 270, 19, 14);

                for(n = 0; n < 256; n++)
                {
                    g.DrawLine(plumaH, n+20, 270, n+20, 270-histograma[n]);
                }

            }
            //histoRR.Image = img;

        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (imgOriginal.Image == null)
            {
                MessageBox.Show("No se encontro imagen", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {


                CargarHistogramas(new Bitmap(imgOriginal.Image),1);
                if (aplicado)
                    CargarHistogramas(new Bitmap(imgResult.Image), 0);

            }


        }

        public void CargarHistogramas(Bitmap imagen, int op)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            DenseHistogram hist2 = new DenseHistogram(256, new RangeF(0, 255));
            DenseHistogram hist3 = new DenseHistogram(256, new RangeF(0, 255));
            Bitmap imgModify = new Bitmap(imgOriginal.Image);

            _InputImage = new Image<Bgr, byte>(imagen);
            //_InputImage = newImage;

            Image<Gray, Byte> R;
            Image<Gray, Byte> G;
            Image<Gray, Byte> B; 

            B = _InputImage[0];
            G = _InputImage[1];
            R = _InputImage[2];

            //_InputImage = new Image<Bgr, byte>(fileName);

            if (_InputImage == null)
            {
                MessageBox.Show("No se encontro imagen", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            hist.Calculate(new Image<Gray, byte>[] { _InputImage[0] }, false, null);
            hist2.Calculate(new Image<Gray, byte>[] { _InputImage[1] }, false, null);
            hist3.Calculate(new Image<Gray, byte>[] { _InputImage[2] }, false, null);

            Mat m = new Mat();
            Mat m2 = new Mat();
            Mat m3 = new Mat();

            hist.CopyTo(m);
            hist2.CopyTo(m2);
            hist3.CopyTo(m3);
            if (op == 1)
            {

                histogramBox1.ClearHistogram();
                histogramBox2.ClearHistogram();
                histogramBox3.ClearHistogram();



                //histogramBox3.GenerateHistograms(B, 64);

                histogramBox1.AddHistogram("Red", Color.Red, m, 256, new float[] { 0, 256 });
                histogramBox1.Refresh();

                histogramBox2.AddHistogram("Green", Color.Green, m2, 256, new float[] { 0, 256 });
                //histogramBox2.GenerateHistograms(G, 64);
                //histogramBox2.GenerateHistograms(B, 64); ;
                histogramBox2.Refresh();

                //histogramBox3.AddHistogram("Blue", Color.Blue, m3, 256, new float[] { 0, 256 });
                histogramBox3.AddHistogram("Blue", Color.Blue, m3, 256, new float[] { 0, 256 });
                //histogramBox1.GenerateHistograms(R, 64);
                histogramBox3.Refresh();
            }
            else if (op == 0)
            {

                histogramBox4.ClearHistogram();
                histogramBox5.ClearHistogram();
                histogramBox6.ClearHistogram();


                histogramBox4.AddHistogram("Red", Color.Red, m, 256, new float[] { 0, 256 });
                histogramBox4.Refresh();

                histogramBox5.AddHistogram("Green", Color.Green, m2, 256, new float[] { 0, 256 });
                histogramBox5.Refresh();

                histogramBox6.AddHistogram("Blue", Color.Blue, m3, 256, new float[] { 0, 256 });
                histogramBox6.Refresh();
            }

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.URL = ruta;
            //axWindowsMediaPlayer1.Ctlcontrols.play();

            if (videoCapture == null)
            {
                return;
            }

            try
            {
                if (isPause)
                    isPause = !isPause;

                while (!isPause)
                {
                    Mat m = new Mat();
                    videoCapture.Read(m);

                    if(!m.IsEmpty)
                    {
                        videoBox.Image = m.Bitmap;
                        double fps = videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                        await Task.Delay(1000/Convert.ToInt32(fps));
                    }
                    else
                    {
                        break;
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private async void btnVCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                videoCapture = new VideoCapture(openFileDialog.FileName);
                ruta = openFileDialog.FileName;
                labelRuta.Text = ruta;

                ImageAttributes imageAttributes = new ImageAttributes();
                Mat mat = new Mat();
                Bitmap originalImage = mat.Bitmap;
                while (!isPause)
                {
                    Image<Bgr, byte> CurrentFrame;
                    videoCapture.Read(mat);
                    if (!mat.IsEmpty)
                    {
                        Bitmap bitResult = new Bitmap(mat.Bitmap);
                        switch (filtro)
                        {
                            case 0:
                                bitResult = mat.Bitmap;
                                break;

                            case 1:
                                bitResult = EscalaGrises(mat.Bitmap);
                                //video2Box.Image = bitResult;
                                break;

                            case 2:

                                break;

                            case 3:

                                break;

                            case 4:

                                break;

                            case 5:

                                break;

                            default:
                                bitResult = mat.Bitmap;
                                break;

                        }


                        videoBox.Image = bitResult;
                        video2Box.Image = bitResult;
                        if (videoCapture == null)
                        {
                            return;
                        }

                        try
                        {
                            if (isPause)
                                isPause = !isPause;

                            while (!isPause)
                            {
                                Mat m = new Mat();
                                videoCapture.Read(m);

                                if (!m.IsEmpty)
                                {
                                    videoBox.Image = m.Bitmap;
                                    double fps = videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                                    await Task.Delay(1000 / Convert.ToInt32(fps));
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }
                }

                
                


                



                //while (!isPause)
                //{
                //    videoCapture.Read(mat);
                //    if(!mat.IsEmpty)
                //    {
                //        //Bitmap Final;

                //        videoBox.Image = mat.Bitmap;
                //    }
                //}


            }
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.pause();
            if (!isPause)
                isPause = !isPause;

        }

        private Bitmap EscalaGrises(Image bmp)
        {
            Bitmap newbitmap = new Bitmap(bmp.Width, bmp.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[]{-1, 0, 0, 0, 0},
                new float[]{0, -1, 0, 0, 0},
                new float[]{0, 0, -1, 0, 0},
                new float[]{0, 0, 0, -1, 0},
                new float[]{1, 1, 1, 0, 1}
            });
            imageAttributes.SetColorMatrix(colorMatrix);
            Graphics graphics = Graphics.FromImage(newbitmap);
            graphics.DrawImage(bmp,
                               new Rectangle(0, 0, bmp.Width, bmp.Height),
                               0, 0,
                               bmp.Width,
                               bmp.Height,
                               GraphicsUnit.Pixel,
                               imageAttributes);
            graphics.Dispose();


            return newbitmap;
        }

        private void histogramBox1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Contador_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            filtro =1;
        }

        private void video2Box_Click(object sender, EventArgs e)
        {

        }

        public void CerrarWebCam()
    {
            if(MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

    }
}
