using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;



namespace vejr_app3
{
    public class MediaControl
    {
        private MediaElement _mediaElement;

        public MediaControl(MediaElement mediaElement)
        {
            _mediaElement = mediaElement;
        }
        public void SetWidth(double width)
        {
            _mediaElement.Width = width;
        }

        public void SetHeight(double height)
        {
            _mediaElement.Height = height;
        }


        public void Raining()
        {
            // Construct the path to the media file
            string sourceOG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources2\Rain.mp4");
            sourceOG = Path.GetFullPath(sourceOG);

            try
            {
                // Check if the file exists
                if (File.Exists(sourceOG))
                {
                    // Set the media source with UriKind.RelativeOrAbsolute
                    _mediaElement.Source = new Uri(sourceOG, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            _mediaElement.Play();
        }

        // Repeat similar changes for Sun(), Snow(), and Thunder() methods
        public void Sun()
        {
            string sourceOG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources2\Sun.mp4");
            sourceOG = Path.GetFullPath(sourceOG);

            try
            {
                if (File.Exists(sourceOG))
                {
                    _mediaElement.Source = new Uri(sourceOG, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            _mediaElement.Play();
        }

        public void Snow()
        {
            string sourceOG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources2\Snow.mp4");
            sourceOG = Path.GetFullPath(sourceOG);

            try
            {
                if (File.Exists(sourceOG))
                {
                    _mediaElement.Source = new Uri(sourceOG, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            _mediaElement.Play();
        }

        public void Thunder()
        {
            string sourceOG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources2\Thunder.mp4");
            sourceOG = Path.GetFullPath(sourceOG);

            try
            {
                if (File.Exists(sourceOG))
                {
                    _mediaElement.Source = new Uri(sourceOG, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            _mediaElement.Play();
        }
    }
}
