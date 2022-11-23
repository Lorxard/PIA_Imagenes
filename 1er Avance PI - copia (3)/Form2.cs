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
using AForge.Vision.Motion;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;

namespace _1er_Avance_PI
{
    public partial class Form2 : Form
    {

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private Bitmap original;
        private int caras = 0;


        private bool CamActiva = false;
        private bool ImgActiva = false;
        private bool VidActiva = false;
        private Bitmap resultante;
        private int[] histograma = new int[256];
        private int[,] conv3x3 = new int[3, 3];

        private int[] histograma2;
        private int mayor;

        int filtro = 0;

        private Color[] colorCamCapture = new Color[10];

        private bool aplicado = false;

        bool isPause = false;
        double countFrame = 0;

        double TotalFrames;
        double CurrentFrameNo;
        Mat CurrentFrame;
        bool IsPlaying = false;
        int FPS;
        double Fps;
        int FrameNo;


        Image<Bgr, byte> _InputImage;

        bool isVideo = false;
        Bitmap Video;

        VideoCapture videoCapture;
        private string ruta = "";

        //Variables para deteccion
        MotionDetector Detector;
        float NvlDetect;

        int hacer = 0;

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
            Detector = new MotionDetector(new TwoFramesDifferenceDetector(),new MotionBorderHighlighting());
            NvlDetect = 0;


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
                ImgActiva = true;
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

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    if (CamActiva)
        //    {
        //        CerrarWebCam();
        //        CamActiva = false;
        //    }


        //    //int i = comboBox1.SelectedIndex;
        //    //string NombreVideo = MiDispositivos[i].MonikerString;
        //    try
        //    {

        //        int i = comboBox1.SelectedIndex;
        //        string NombreVideo = MiDispositivos[i].MonikerString;
        //        MiWebCam = new VideoCaptureDevice(NombreVideo);
        //        MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
               
        //        MiWebCam.Start();
        //        CamActiva = true;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("No se selecciono camara", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    //MiWebCam = new VideoCaptureDevice(NombreVideo);
        //    //MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
        //    //MiWebCam.Start();
        //    //CamActiva = true;


        //}

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            switch (hacer)
            {
                case 0:
                    break;

                case 1:
                    NvlDetect = Detector.ProcessFrame(Imagen);
                    break;
                case 2:
                    Image<Rgb, byte> grayImage = new Image<Rgb, byte>(Imagen);
                    Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
                    caras = 0;

                    foreach (Rectangle rectangulo in rectangles)
                    {
                        caras++;
                        using (Graphics graphics = Graphics.FromImage(Imagen))
                        {
                            using (Pen lapiz = new Pen(Color.Blue, 1))
                            {
                                SolidBrush s = new SolidBrush(Color.Blue);
                                graphics.DrawRectangle(lapiz, rectangulo);
                                
                            }
                        }
                        

                    }
                    if (InvokeRequired)
                        Invoke(new Action(() => Contador.Text = caras.ToString()));

                    break;

            }




            if(CamActiva)
            {
                camaraBox1.Image = Imagen;
                camaraBox1.Image = Imagen;
            }
           

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(ImgActiva)
            {
                Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
                Grises(copyBitmap);
                imgResult.Image = copyBitmap;
                aplicado = true;
            }
           
            //histo(copyBitmap);
            //Test(copyBitmap,2);

        }

        public void Grises(Bitmap bmp)
        {
            int x, y = 0;

            Color rColor = new Color();
            Color oColor = new Color();

            float g = 0;

            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    oColor = bmp.GetPixel(x, y);

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
            if(ImgActiva)
            {
                Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
                Negativo(copyBitmap);
                imgResult.Image = copyBitmap;
                aplicado = true;
            }
           
            //Test(copyBitmap, 2);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ImgActiva)
            {
                Bitmap copyBitmap = (Bitmap)imgOriginal.Image;

                Ruido(copyBitmap);
                imgResult.Image = copyBitmap;
                aplicado = true;
                //Test(copyBitmap,2);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ImgActiva)
            {
                Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
                Sepia(copyBitmap);
                imgResult.Image = copyBitmap;
                aplicado = true;
                //Test(copyBitmap,2);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ImgActiva)
            {
                Bitmap copyBitmap = new Bitmap(imgOriginal.Image);
                Croma(copyBitmap);
                imgResult.Image = copyBitmap;

                aplicado = true;
                //Test(copyBitmap, 2);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Test(Bitmap prueba, int op)
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
            int n;

            mayor = 0;

            for (n = 0; n < 256; n++)
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

                for (n = 0; n < 256; n++)
                {
                    g.DrawLine(plumaH, n + 20, 270, n + 20, 270 - histograma[n]);
                }

            }
            //histoRR.Image = img;

        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (!ImgActiva)
            {
                MessageBox.Show("No se encontro imagen", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {


                CargarHistogramas(new Bitmap(imgOriginal.Image), 1);
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
        private async void PlayVideo()
        {
            if (videoCapture == null)
            {
                return;
            }

            try
            {
                while (IsPlaying == true && CurrentFrameNo < TotalFrames)
                {
                    videoCapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videoCapture.Read(CurrentFrame);
                    Image<Bgr, byte> img = CurrentFrame.ToImage<Bgr, byte>();


                    switch (filtro)
                    {
                        case 0:
                            videoBox.Image = CurrentFrame.Bitmap;
                            break;

                        case 1:
                            videoBox.Image = Invertido(img);
                            //video2Box.Image = bitResult;
                            break;

                        case 2:
                            videoBox.Image = EscalaGrises(img);
                            break;

                        case 3:
                            videoBox.Image = Sepia(img);
                            break;

                        case 4:
                            videoBox.Image = RuidoVid(img.Bitmap);
                            break;

                        case 5:
                            videoBox.Image = CromaVid(img);
                            break;

                        case 6:
                            videoBox.Image = Croma2(img.Bitmap);
                            break;

                        default:
                            videoBox.Image = CurrentFrame.Bitmap;
                            break;

                    }





                    CurrentFrameNo += 1;
                    await Task.Delay(1000 / Convert.ToInt32(FPS));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {
                MessageBox.Show("No se selecciono video", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                if (IsPlaying == true)
            {
                return;
            }
            //axWindowsMediaPlayer1.URL = ruta;
            //axWindowsMediaPlayer1.Ctlcontrols.play();
            if (CurrentFrameNo >= TotalFrames)
                CurrentFrameNo = 0;


            if (videoCapture != null)
            {
                IsPlaying = true;
                PlayVideo();
            }

            else
            {
                IsPlaying = false;
            }





            //    if (isPause)
            //        isPause = !isPause;

            //    while (!isPause && CurrentFrameNo<TotalFrames)
            //    {
            //        Mat m = new Mat();
            //        videoCapture.Read(m);

            //        if (!m.IsEmpty)
            //        {
            //            videoBox.Image = m.Bitmap;
            //            double fps = videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
            //            await Task.Delay(1000 / Convert.ToInt32(fps));
            //        }
            //        else
            //        {
            //            break;
            //        }

            //    }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
            if (!VidActiva)
            {
                MessageBox.Show("No se selecciono video", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IsPlaying = false;
            CurrentFrameNo = 0;

            videoBox.Image = null;
            videoBox.Invalidate();
        }

        private async void btnVCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                videoCapture = new VideoCapture(openFileDialog.FileName);
                TotalFrames = Convert.ToInt32(videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount));
                FPS = Convert.ToInt32(videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));

                IsPlaying = true;
                CurrentFrame = new Mat();
                CurrentFrameNo = 0;


                VidActiva = true;

                PlayVideo();


            }
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {
                MessageBox.Show("No se selecciono video", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //axWindowsMediaPlayer1.Ctlcontrols.pause();
            //if (!isPause)
            //    isPause = !isPause;

            IsPlaying = false;

        }

        private Bitmap EscalaGrises(Image<Bgr, byte> bmp)
        {
            Bitmap bmpOut = bmp.ToBitmap();
            Bitmap newbitmap = new Bitmap(bmp.Width, bmp.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                new float[]{0.59f, 0.59f, 0.59f, 0, 0},
                new float[]{0.11f, 0.11f, 0.11f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 0}
            });
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            using (Graphics graphics = Graphics.FromImage(newbitmap))
            {
                graphics.DrawImage(bmpOut,
                                  new Rectangle(0, 0, bmpOut.Width, bmpOut.Height),
                                  0, 0,
                                  bmpOut.Width,
                                  bmpOut.Height,
                                  GraphicsUnit.Pixel,
                                  imageAttributes);
                graphics.Dispose();
            }




            return newbitmap;
        }
        private Bitmap Invertido(Image<Bgr, byte> bmp)
        {
            Bitmap bmpOut = bmp.ToBitmap();
            Bitmap newbitmap = new Bitmap(bmp.Width, bmp.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[]{-1, 0, 0, 0, 0},
                new float[]{0, -1, 0, 0, 0},
                new float[]{0, 0, -1, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{1, 1, 1, 0, 1}
            });
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            using (Graphics graphics = Graphics.FromImage(newbitmap))
            {
                graphics.DrawImage(bmpOut,
                                  new Rectangle(0, 0, bmpOut.Width, bmpOut.Height),
                                  0, 0,
                                  bmpOut.Width,
                                  bmpOut.Height,
                                  GraphicsUnit.Pixel,
                                  imageAttributes);
                graphics.Dispose();
            }




            return newbitmap;
        }


        private Bitmap Sepia(Image<Bgr, byte> bmp)
        {
            Bitmap bmpOut = bmp.ToBitmap();
            Bitmap newbitmap = new Bitmap(bmp.Width, bmp.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[]{0.393f, 0.349f, 0.272f, 0, 0},
                new float[]{0.769f, 0.686f, 0.534f, 0, 0},
                new float[]{0.189f, 0.168f, 0.131f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 0}
            });
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            using (Graphics graphics = Graphics.FromImage(newbitmap))
            {
                graphics.DrawImage(bmpOut,
                                  new Rectangle(0, 0, bmpOut.Width, bmpOut.Height),
                                  0, 0,
                                  bmpOut.Width,
                                  bmpOut.Height,
                                  GraphicsUnit.Pixel,
                                  imageAttributes);
                graphics.Dispose();
            }

            return newbitmap;
        }

        private Bitmap RuidoVid(Bitmap img)
        {

            Bitmap bitmap = new Bitmap(img);

            int porcentaje = 8;
            int rangoMin = 200;
            int rangoMax = 255;
            Random rnd = new Random();
            Color rcolor;
            Color oColor;
            unsafe
            {
                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bitmapData = bitmap.LockBits(rectangle,
                                                      ImageLockMode.ReadWrite,
                                                      bitmap.PixelFormat);
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) /8;
                int heightInPixels = bitmap.Height;
                int widthInPixels = bitmap.Width * bytesPerPixel;
                byte* firstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = firstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInPixels; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        if(rnd.Next(1,200)<= porcentaje)
                        {
                            int newblue = (byte)(rnd.Next(rangoMin, rangoMax));
                            int newgreen = (byte)(rnd.Next(rangoMin, rangoMax));
                            int newRed = (byte)(rnd.Next(rangoMin, rangoMax));
                            currentLine[x] = (byte)newblue;
                            currentLine[x + 1] = (byte)newgreen;
                            currentLine[x + 2] = (byte)newRed;
                        }
                        else
                        {
                            currentLine[x] = (byte)oldBlue;
                            currentLine[x + 1] = (byte)oldGreen;
                            currentLine[x + 2] = (byte)oldRed;
                        }


                    }
                });
                bitmap.UnlockBits(bitmapData);
            }

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(bitmap,
                               new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                               0,
                               0,
                               bitmap.Width,
                               bitmap.Height,
                               GraphicsUnit.Pixel);
            return bitmap;
        }

        private Bitmap Croma2(Bitmap img)
        {
            Bitmap bitmap = new Bitmap(img);

            int a = 4;

            unsafe
            {
                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bitmapData = bitmap.LockBits(rectangle,
                                                      ImageLockMode.ReadWrite,
                                                      bitmap.PixelFormat);
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmap.Height;
                int widthInPixels = bitmap.Width * bytesPerPixel;
                byte* firstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = firstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInPixels; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        currentLine[x + 1] = (byte)oldGreen;

                        if ((x + 2 +a < widthInPixels))
                        {
                            currentLine[x + 2] = (byte)(currentLine[x + 2 +(a)]);


                            //int newblue = (byte)(rnd.Next(rangoMin, rangoMax));
                            //int newgreen = (byte)(rnd.Next(rangoMin, rangoMax));
                            //int newRed = (byte)(rnd.Next(rangoMin, rangoMax));
                            //currentLine[x] = (byte)newblue;
                            //currentLine[x + 1] = (byte)newgreen;
                            //currentLine[x + 2] = (byte)newRed;
                        }
                        else
                        {
                            currentLine[x + 2] = 0;
                            //currentLine[x] = (byte)oldBlue;
                            //currentLine[x + 1] = (byte)oldGreen;
                            //currentLine[x + 2] = (byte)oldRed;
                        }

                        if ((x + 2 -a) > 0)
                        {
                            currentLine[x] = (byte)(currentLine[x + 2 -a]);
                        }
                        else
                        {
                            currentLine[x] = 0;
                        }


                    }
                });
                bitmap.UnlockBits(bitmapData);
            }

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(bitmap,
                               new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                               0,
                               0,
                               bitmap.Width,
                               bitmap.Height,
                               GraphicsUnit.Pixel);
            return bitmap;
        }

        private Bitmap CromaVid(Image<Bgr, byte> bmp)
        {

            //Bitmap bitmap = new Bitmap(img);

            //int a = 4;

            //unsafe
            //{
            //    Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //    BitmapData bitmapData = bitmap.LockBits(rectangle,
            //                                          ImageLockMode.ReadWrite,
            //                                          bitmap.PixelFormat);
            //    int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            //    int heightInPixels = bitmap.Height;
            //    int widthInPixels = bitmap.Width * bytesPerPixel;
            //    byte* firstPixel = (byte*)bitmapData.Scan0;
            //    Parallel.For(0, heightInPixels, y =>
            //    {
            //        byte* currentLine = firstPixel + (y * bitmapData.Stride);
            //        for (int x = 0; x < widthInPixels; x = x + bytesPerPixel)
            //        {
            //            int oldBlue = currentLine[x];
            //            int oldGreen = currentLine[x + 1];
            //            int oldRed = currentLine[x + 2];

            //            currentLine[x + 1] = (byte)oldGreen;

            //            if ((x + 2 + (bytesPerPixel * a)) < widthInPixels)
            //            {
            //                currentLine[x +2] = (byte)(currentLine[x + 2 +(bytesPerPixel*a)]);


            //                //int newblue = (byte)(rnd.Next(rangoMin, rangoMax));
            //                //int newgreen = (byte)(rnd.Next(rangoMin, rangoMax));
            //                //int newRed = (byte)(rnd.Next(rangoMin, rangoMax));
            //                //currentLine[x] = (byte)newblue;
            //                //currentLine[x + 1] = (byte)newgreen;
            //                //currentLine[x + 2] = (byte)newRed;
            //            }
            //            else
            //            {
            //                currentLine[x + 2] = 0;
            //                //currentLine[x] = (byte)oldBlue;
            //                //currentLine[x + 1] = (byte)oldGreen;
            //                //currentLine[x + 2] = (byte)oldRed;
            //            }

            //            if((x + 2 + (bytesPerPixel * a)) > 0)
            //            {
            //                currentLine[x]= (byte)(currentLine[x + 2 - (bytesPerPixel * a)]);
            //            }
            //            else
            //            {
            //                currentLine[x] = 0;
            //            }


            //        }
            //    });
            //    bitmap.UnlockBits(bitmapData);
            //}

            //Graphics graphics = Graphics.FromImage(bitmap);
            //graphics.DrawImage(bitmap,
            //                   new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            //                   0,
            //                   0,
            //                   bitmap.Width,
            //                   bitmap.Height,
            //                   GraphicsUnit.Pixel);
            //return bitmap;

            Bitmap bmpOut = bmp.ToBitmap();
            Bitmap newbitmap = new Bitmap(bmp.Width, bmp.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[]{1.438f, -0.062f, -0.062f, 0, 0},
                new float[]{-0.122f, 1.378f, -0.122f, 0,0},
                new float[]{-0.016f, -0.016f, 1.483f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{-0.03f, 0.05f, -0.02f, 0, 1}
            });
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            using (Graphics graphics = Graphics.FromImage(newbitmap))
            {
                graphics.DrawImage(bmpOut,
                                  new Rectangle(0, 0, bmpOut.Width, bmpOut.Height),
                                  0, 0,
                                  bmpOut.Width,
                                  bmpOut.Height,
                                  GraphicsUnit.Pixel,
                                  imageAttributes);
                graphics.Dispose();
            }




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
            if (!VidActiva)
            {

                return;
            }
            filtro =2;
        }

        private void video2Box_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {

                return;
            }
            filtro = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            filtro = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {

                return;
            }
            filtro = 3;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {

                return;
            }
            filtro = 4;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {
               
                return;
            }
            filtro = 5;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!VidActiva)
            {

                return;
            }
            filtro = 6;
        }

        private void button1_Click_2(object sender, EventArgs e)
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

        private void button18_Click(object sender, EventArgs e)

        { 
            if(CamActiva)
            {
                hacer = 1;
            }
            else
            {
                MessageBox.Show("No se selecciono camara", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (CamActiva)
            {
                hacer = 2;
            }
            else
            {
                MessageBox.Show("No se selecciono camara", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (CamActiva)
            {
                hacer = 0;
            }
            else
            {
                MessageBox.Show("No se selecciono camara", "sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            CamActiva = false;
        }

        private void Contador_Click_1(object sender, EventArgs e)
        {

        }

        public void CerrarWebCam()
    {
            if(MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
                camaraBox1 = null;
                CamActiva = false;
            }
        }

    }
}
