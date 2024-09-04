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
    }
}