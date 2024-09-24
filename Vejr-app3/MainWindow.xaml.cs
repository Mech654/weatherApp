using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using vejr_app3;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlTypes;
using Microsoft.Win32;
using System.Windows.Markup;
using System.Data.OleDb;

namespace Vejr_app3
{
    public partial class MainWindow : Window
    {
        private MediaControl _mediaControl;

        Dictionary<string, bool> widgetDict = new Dictionary<string, bool>
        {
            { "Widget1", false },
            { "Widget2", false },
            { "Widget3", false },
            { "Widget4", false },
            { "Widget5", false }
        };

        private readonly Dictionary<string, ImageSource> imageSources = new Dictionary<string, ImageSource>
        {
            { "Rain", new BitmapImage(new Uri("pack://application:,,,/Resources2/Rain.png")) },
            { "Snow", new BitmapImage(new Uri("pack://application:,,,/Resources2/Snow.png")) },
            { "Thunder", new BitmapImage(new Uri("pack://application:,,,/Resources2/Thunder.png")) },
            { "Sun", new BitmapImage(new Uri("pack://application:,,,/Resources2/Sun.png")) },
            { "Unknown", new BitmapImage(new Uri("pack://application:,,,/Resources2/Bad.png")) }
        };


        List<string> Citys = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            _mediaControl = new MediaControl(videocool);
            settingsforvideo();
            SQlite.InitializeDatabase();
            SQlite.getData(); // Fetch data from the database
            putDataInCombobox();
            
        }

        

        public void SelectCity(object sender, SelectionChangedEventArgs e)
        {
            if (SearchBox.SelectedItem != null)
            {
                var selectedCity = SearchBox.SelectedItem.ToString();
                // Here you can set the ComboBox's text to the selected city, or perform any other logic
                SearchBox.Text = selectedCity;
                MessageBox.Show($"You selected: {selectedCity}");
                dosomething(selectedCity);
               
            }
        }
        public void putDataInCombobox()
        {
            
            if (firsttime == true)
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


        public bool firsttime = true;
        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            string searchText = SearchBox.Text;
            


            dosomething(searchText);

        }

        public async void dosomething(string searchText)
        {
           
            // Instantiate the Weather object with the desired city
            API weather = new API(searchText);

            // Call the method to fetch weather data
            await weather.GetWeatherData();

            if (weather.Valid == true && searchText != "")
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
                    Image cityImage = (Image)Widget1.FindName("Image2");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";
                    widgetDict["Widget2"] = true;

                    // Set the image source based on the weather condition
                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        // Optionally, handle cases where the condition isn't in the dictionary
                        cityImage.Source = null; // Or set a default image
                    }
                    ChangeVideo(weatherCondition);
                }
                else if (!widgetDict["Widget3"])
                {
                    TextBlock cityText = (TextBlock)Widget3.FindName("City3");
                    TextBlock citytemp = (TextBlock)Widget3.FindName("Temp3");
                    Image cityImage = (Image)Widget1.FindName("Image3");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";
                    widgetDict["Widget3"] = true;

                    // Set the image source based on the weather condition
                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        // Optionally, handle cases where the condition isn't in the dictionary
                        cityImage.Source = null; // Or set a default image
                    }
                    ChangeVideo(weatherCondition);
                }
                else if (!widgetDict["Widget4"])
                {
                    TextBlock cityText = (TextBlock)Widget4.FindName("City4");
                    TextBlock citytemp = (TextBlock)Widget4.FindName("Temp4");
                    Image cityImage = (Image)Widget1.FindName("Image4");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";
                    widgetDict["Widget4"] = true;

                    // Set the image source based on the weather condition
                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        // Optionally, handle cases where the condition isn't in the dictionary
                        cityImage.Source = null; // Or set a default image
                    }
                    ChangeVideo(weatherCondition);
                }
                else
                {
                    TextBlock cityText = (TextBlock)Widget5.FindName("City5");
                    TextBlock citytemp = (TextBlock)Widget5.FindName("Temp5");
                    Image cityImage = (Image)Widget1.FindName("Image5");
                    cityText.Text = searchText;
                    citytemp.Text = $"{weather.Temp}°C";
                    


                    // Set the image source based on the weather condition
                    if (imageSources.ContainsKey(weatherCondition))
                    {
                        cityImage.Source = imageSources[weatherCondition];
                    }
                    else
                    {
                        // Optionally, handle cases where the condition isn't in the dictionary
                        cityImage.Source = null; // Or set a default image
                    }

                }
                ChangeVideo(weatherCondition);

                //SearchBox.Text = "";
                SearchBox.Items.Insert(0, searchText);
                SQlite.InsertSearchHistory(searchText);


            }
        }

        private void ChangeVideo(string weathertpye)
        {
            if (weathertpye == "Sun")
            {
                _mediaControl.Sun();
            }
            if (weathertpye == "Snow")
            {
                _mediaControl.Snow();
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
                // Now you can use filePath to read/write the file
            }

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                File.WriteAllText(filePath, "CityNames\n"); // Clear the file and give title

                foreach (string cityname in Citys)
                {
                    File.AppendAllText(filePath, cityname + "\n"); // Append each city name with a newline
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
                // Now you can use filePath to read/write the file
            }

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string cityname in lines)
                {
                    if (cityname == "CityNames")
                    {
                        continue;
                    }
                    else
                    {
                        dosomething(cityname);
                    }
                }
                MessageBox.Show("Done");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

    }
}
