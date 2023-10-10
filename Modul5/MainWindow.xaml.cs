using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Modul5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double originalImageWidth;
        private double originalImageHeight;

        // Обработчик события для выбора изображения
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.png, *.jpg)|*.png;*.jpg|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;

                // Загрузка выбранного изображения и отображение его на элементе ImageControl
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                ImageControl.Source = bitmap;

                // Сохранение исходных размеров изображения
                originalImageWidth = bitmap.PixelWidth;
                originalImageHeight = bitmap.PixelHeight;
            }
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double zoomFactor = ZoomSlider.Value;

            // Установка нового масштаба изображения
            ScaleTransform scaleTransform = new ScaleTransform(zoomFactor, zoomFactor);
            ImageControl.LayoutTransform = scaleTransform;
        }
    }
}
