using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MM_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string sigPath;

        public ColorRGB mcolor { get; set; }

        public Color clr { get; set; }
       

        public MainWindow()
        {

        InitializeComponent();

            mcolor = new ColorRGB();
            mcolor.red = 0;
            mcolor.green = 0;
            mcolor.blue = 0;
           

            //set slider's value here
            penSizeSlider.Value = 1;
            
            

            inkCanvas.DefaultDrawingAttributes.Width = 1;
            inkCanvas.DefaultDrawingAttributes.Height = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        
            {
            inkCanvas.DefaultDrawingAttributes = new System.Windows.Ink.DrawingAttributes();
            inkCanvas.DefaultDrawingAttributes.Width = penSizeSlider.Value;
            inkCanvas.DefaultDrawingAttributes.Height = penSizeSlider.Value;
        }

        private void sld_Color_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            string crlName = slider.Name; 
            double value = slider.Value; 
                                         
            if (crlName.Equals("sld_RedColor"))
            {
                mcolor.red = Convert.ToByte(value);
            }
            if (crlName.Equals("sld_GreenColor"))
            {
                mcolor.green = Convert.ToByte(value);
            }
            if (crlName.Equals("sld_BlueColor"))
            {
                mcolor.blue = Convert.ToByte(value);
            }

           
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
          
            this.inkCanvas.DefaultDrawingAttributes.Color = clr;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try {
            sigPath = System.IO.Path.GetTempFileName();
            FileStream fs = new FileStream(sigPath, FileMode.Create);
            inkCanvas.Strokes.Save(fs);
            fs.Close();
                MessageBox.Show("Сохранено:" + sigPath.ToString());
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
