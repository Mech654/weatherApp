# WeatherApp

WeatherApp is an application that allows users to view the weather of different locations around the world.

## Software Used

- **WPF Library**: Utilized from the .NET framework for the GUI.
- **Weather API**: Integrated from [OpenWeatherMap](https://openweathermap.org/).
- **JSONfy**: Used for handling JSON data.
- **SQLite**: Used for local database management, from the [Microsoft.Data.Sqlite library](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/).

## Features

- **Real-time Weather Data**: Get the latest weather information for any location.
- **Search History**: View your past searches.
- **User-friendly Interface**: Easy to navigate and use.

## Example

### Overview
![weatherApp](https://github.com/Mech654/Resources/blob/main/WeatherApp-overview.png) <!-- Replace with actual image src -->

### Combobox/SearchBox
![weatherApp](https://github.com/Mech654/Resources/blob/main/Combobox.png)

The combobox retrieves its data from a .db file created and updated using SQLite.


# Technical Details

## SQl
Everything related to SQL can be find here, a .txt file could be used alternativly for the database but just wanted to try it out.
[Code Snippet](https://github.com/Mech654/weatherApp/blob/master/Vejr-app3/SQlite.cs)


## Graphical User Interface
[Code Snippet](https://github.com/Mech654/weatherApp/blob/master/Vejr-app3/MainWindow.xaml)


## Fetching Data from the API

To fetch data from the OpenWeatherMap API, I use the following code:

[Code Snippet](https://github.com/Mech654/weatherApp/blob/master/Vejr-app3/API.cs#L25)

This method handles making the API request and processing the response. It takes a City name as input and outputs the data from the API call in form of variables(Temp, Temp(min/max), WeatherDescription), though there are some unutilized data.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements.

### Possible Improvements:
- A function that updates the widgets every minute.
- Fixing the dynamically changing background video.
- Any other interesting ideas!
