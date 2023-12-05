using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace HW9_Anim
{
    public partial class MainWindow : Window
    {
        private readonly Random rnd = new Random();
        private readonly DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            DoubleAnimation animX = new DoubleAnimation();
            animX.From = 0;
            animX.To = 450;
            animX.Duration = new Duration(TimeSpan.FromSeconds(2));
            animX.RepeatBehavior = RepeatBehavior.Forever;
            animX.AutoReverse = true;
            TranslateTransform translateTransform = new TranslateTransform();
            square.RenderTransform = translateTransform;
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animX);

            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, e) =>
            {
                byte[] colorBytes = new byte[4];
                rnd.NextBytes(colorBytes);
                Color randomColor = Color.FromArgb(colorBytes[0], colorBytes[1], colorBytes[2], colorBytes[3]);

                if (randomColor != Colors.Black)
                {
                    square.Fill = new SolidColorBrush(randomColor);
                }
            };
            timer.Start();
        }
    }
}