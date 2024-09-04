using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace inkcanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Color_Checked(object sender , RoutedEventArgs e)
        {
            switch ( ((RadioButton)sender).Content.ToString() )
            {
                case "Red":
                    ink.DefaultDrawingAttributes.Color = Colors.Red;
                    break;
                case "Black":
                    ink.DefaultDrawingAttributes.Color = Colors.Black;
                    break;
                case "Blue":
                    ink.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Green":
                    ink.DefaultDrawingAttributes.Color = Colors.Green;
                    break;
            }
        }

        private void Mode_Checked(object sender, RoutedEventArgs e)
        {
            switch(((RadioButton)sender).Content.ToString() )
            {
                case "ink":
                    ink.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select":
                    ink.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "erase":
                    ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "erase by stroke":
                    ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void Shape_Check(object sender, RoutedEventArgs e)
        {
            switch( ( (RadioButton)sender).Content.ToString() )
            {
                case "ellipse":
                    ink.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;
                case "rectangle":
                    ink.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    break;
            }
        }

        private void Size_Checked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content.ToString())
            {
                case "small":
                    ink.DefaultDrawingAttributes.Height = 3;
                    ink.DefaultDrawingAttributes.Width = 3;
                    break;
                case "normal":
                    ink.DefaultDrawingAttributes.Height = 6;
                    ink.DefaultDrawingAttributes.Width = 6;
                    break;
                case "large":
                    ink.DefaultDrawingAttributes.Height = 15;
                    ink.DefaultDrawingAttributes.Width = 15;
                    break;
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            ink.Strokes.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "drawing";
            dlg.DefaultExt = ".isf"; 
            dlg.Filter = "Ink Serialized Format (.isf)|*.isf";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    ink.Strokes.Save(fs);
                }

                MessageBox.Show("File saved successfully!");
            }
        }

        private void Cpoe_Click(object sender, RoutedEventArgs e)
        {
            if (ink.GetSelectedStrokes().Count > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ink.GetSelectedStrokes().Save(ms);
                    Clipboard.SetData("InkStrokes", ms.ToArray());
                }
                MessageBox.Show("Selected content copied to clipboard.");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void Past_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsData("InkStrokes"))
            {
                byte[] data = (byte[])Clipboard.GetData("InkStrokes");
                using (MemoryStream ms = new MemoryStream(data))
                {
                    StrokeCollection strokes = new StrokeCollection(ms);
                    ink.Strokes.Add(strokes);
                }
                MessageBox.Show("Content pasted successfully.");
            }
            else
            {
                MessageBox.Show("No content available to paste.");
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Drawing";
            dlg.Filter = "Ink Serialized Format (.isf)|*.isf"; 

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    StrokeCollection strokes = new StrokeCollection(fs);
                    ink.Strokes.Clear(); 
                    ink.Strokes.Add(strokes);
                }

                MessageBox.Show("Content loaded successfully.");
            }
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            if (ink.GetSelectedStrokes().Count > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ink.GetSelectedStrokes().Save(ms);
                    Clipboard.SetData("InkStrokes", ms.ToArray());
                }
                ink.Strokes.Remove(ink.GetSelectedStrokes());
                MessageBox.Show("Selected content cut to clipboard.");
            }
            else
            {
                MessageBox.Show("No strokes selected to cut.");
            }
        }

    }
}