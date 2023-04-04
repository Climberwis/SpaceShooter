using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpaceShooter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageBrush playerBrush;

        public MainWindow()
        {
            InitializeComponent();
            playerBrush = new ImageBrush();
            playerBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/player-0.bmp"));
            DrawPlayer();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
        }

        private void DrawPlayer()
        {
            var player = new Rectangle
            {
                Height = 59,
                Width = 70
            };
            player.Fill = playerBrush;
            Canvas.SetLeft(player, 100);
            Canvas.SetBottom(player, 60);
            MyCanvas.Children.Add(player);
        }
    }
}
