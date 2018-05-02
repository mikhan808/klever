using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace klever
{
    public partial class Form1 : Form
    {
        int count;
        public Form1()
        {
            InitializeComponent();
            count = 0;
        }
        String path = "D:\\clever\\";
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width/2, Screen.PrimaryScreen.Bounds.Height/2);

                Graphics graphics = Graphics.FromImage(printscreen as Image);

                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

                printscreen.Save(path+"printscreen" + count+ ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Mat bin = bynary_image(printscreen);
                count++;
               
            }
        }

        Mat grayImage(Mat source)
        {
            Mat res = new Mat();
            Cv2.CvtColor(source, res,ColorConversionCodes.RGB2GRAY);
            res.SaveImage(path + "grey.png");
            return res;
        }

        Mat bynary_image(Bitmap image)
        {
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat res = new Mat();
            Cv2.Threshold(grayImage(mat), res, 50, 255, ThresholdTypes.Otsu);
            res.SaveImage(path + "bin.png");
            return res;
        }
        /*Mat[] ansvers_images(Mat source)
        {
            int square = 0;
            int answer = 0;
            Mat [] answers = 
           for(int i=0;i<source.Rows;i++)
            {
                for(int g = 0; g<source.Cols; g++)
                    i
            }
        }*/
    }
}
