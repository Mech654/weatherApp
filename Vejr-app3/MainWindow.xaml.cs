using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using vejr_app3;

namespace Vejr_app3  // 3.3
{
    public partial class MainWindow : Window
    {
        private MediaControl _mediaControl;
        private bool firsttime = true;
        private List<string> Citys = new List<string>();

        Dictionary<string, bool> widgetDict = new Dictionary<string, bool>
        {
            { "Widget1", false },
            { "Widget2", false },
            { "Widget3", false },
            { "Widget4", false },
            { "Widget5", false }
        };

        private readonly Dictionary<string, ImageSource> imageSources;

        public MainWindow()
        {
            InitializeComponent();
            _mediaControl = new MediaControl(videocool);
            settingsforvideo();
            SQlite.InitializeDatabase();
            SQlite.getData();
            putDataInCombobox();

            // Initialize imageSources with relative paths
            imageSources = new Dictionary<string, ImageSource>
            {
                { "Rain", new BitmapImage(new Uri("Resources2/Rain.png", UriKind.Relative)) },
                { "Snow", new BitmapImage(new Uri("Resources2/Snow.png", UriKind.Relative)) },
                { "Thunder", new BitmapImage(new Uri("Resources2/Thunder.png", UriKind.Relative)) },
                { "Sun", new BitmapImage(new Uri("Resources2/Sun.png", UriKind.Relative)) },
                { "Unknown", new BitmapImage(new Uri("Resources2/Bad.png", UriKind.Relative)) }
            };
        }

        public void SelectCity(object sender, SelectionChangedEventArgs e)
        {
            if (SearchBox.SelectedItem != null)
            {
                var selectedCity = SearchBox.SelectedItem.ToString();
                SearchBox.Text = selectedCity;
                MessageBox.Show($"You selected: {selectedCity}");
                dosomething(selectedCity);
            }
        }

        public void putDataInCombobox()
        {
            if (firsttime)
            {
                foreach (string item in SQlite.data)
                {
                    SearchBox.Items.Add(item);
                }
                firsttime = false;
            }
        }

        private void settingsforvideo()
        {
            _mediaControl.SetWidth(1000);
            _mediaControl.SetHeight(1000);
            _mediaControl.Raining();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchBox.Text;
            dosomething(searchText);
        }

        public async void dosomething(string searchText)
        {
            API weather = new API(searchText);
            await weather.GetWeatherData();

            if (weather.Valid && !string.IsNullOrEmpty(searchText))
            {
                Citys.Add(searchText);
                string weatherCondition = weather.WeatherType;

                if (!widgetDict["Widget1"])
                {
                    TextBlock cityText = (TextBlock)Widget1.FindName("City1");
                    TextBlock citytemp = (TextBlock)Widget1.FindName("Temp1");
                    Image cityImage = (Image)Widget1.FindName("Image1");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";

                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        cityImage.Source = null;
                    }

                    widgetDict["Widget1"] = true;
                    ChangeVideo(weatherCondition);
                }
                else if (!widgetDict["Widget2"])
                {
                    TextBlock cityText = (TextBlock)Widget2.FindName("City2");
                    TextBlock citytemp = (TextBlock)Widget2.FindName("Temp2");
                    Image cityImage = (Image)Widget2.FindName("Image2");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";

                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        cityImage.Source = null;
                    }

                    widgetDict["Widget2"] = true;
                    ChangeVideo(weatherCondition);
                }
                else if (!widgetDict["Widget3"])
                {
                    TextBlock cityText = (TextBlock)Widget3.FindName("City3");
                    TextBlock citytemp = (TextBlock)Widget3.FindName("Temp3");
                    Image cityImage = (Image)Widget3.FindName("Image3");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";

                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        cityImage.Source = null;
                    }

                    widgetDict["Widget3"] = true;
                    ChangeVideo(weatherCondition);
                }
                else if (!widgetDict["Widget4"])
                {
                    TextBlock cityText = (TextBlock)Widget4.FindName("City4");
                    TextBlock citytemp = (TextBlock)Widget4.FindName("Temp4");
                    Image cityImage = (Image)Widget4.FindName("Image4");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";

                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        cityImage.Source = null;
                    }

                    widgetDict["Widget4"] = true;
                    ChangeVideo(weatherCondition);
                }
                else
                {
                    TextBlock cityText = (TextBlock)Widget5.FindName("City5");
                    TextBlock citytemp = (TextBlock)Widget5.FindName("Temp5");
                    Image cityImage = (Image)Widget5.FindName("Image5");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";

                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        cityImage.Source = null;
                    }
                }

                ChangeVideo(weatherCondition);

                // Check if the city is already in the database before adding it
                if (!SQlite.data.Contains(searchText))
                {
                    SearchBox.Items.Insert(0, searchText);
                    SQlite.InsertSearchHistory(searchText);
                }
            }
        }

        private void ChangeVideo(string weathertype)
        {
            if (weathertype == "Sun")
            {
                _mediaControl.Sun();
            }
            else if (weathertype == "Snow")
            {
                _mediaControl.Snow();
            }
            else if (weathertype == "Rain")
            {
                _mediaControl.Raining();
            }
            else if (weathertype == "Thunder")
            {
                _mediaControl.Thunder();
            }
        }

        public void Save_all(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                File.WriteAllText(filePath, "CityNames\n");

                foreach (string cityname in Citys)
                {
                    File.AppendAllText(filePath, cityname + "\n");
                }

                MessageBox.Show("Saved");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        public void Load(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string cityname in lines)
                {
                    if (cityname != "CityNames")
                    {
                        dosomething(cityname);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}