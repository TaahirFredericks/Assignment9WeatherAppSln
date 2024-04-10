using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assignment9WeatherApp;


namespace Assignment9WeatherApp
{
    public partial class MainPage : ContentPage
    {

        private int _temp;

        public int Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged();
            }
        }

        private double _wind;
        public double Wind
        {
            get { return _wind; }
            set
            {
                _wind = value;
                OnPropertyChanged();
            }
        }

        private int _humidity;
        public int Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        private int _pressure;

        public int Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                OnPropertyChanged();
            }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        private int _clouds;
        public int Clouds
        {
            get { return _clouds; }
            set
            {
                _clouds = value;
                OnPropertyChanged();
            }
        }

        private string _weatherdescription;
        public string WeatherDescription
        {
            get { return _weatherdescription; }
            set
            {
                _weatherdescription = value;
                OnPropertyChanged();
            }
        }

        private int _dateAndTime;
        public int DateAndTime
        {
            get { return _dateAndTime; }
            set
            {
                _dateAndTime = value;
                OnPropertyChanged();

            }
        }


        private string _sunrise;

        public string Sunrise
        {
            get { return _sunrise; }
            set
            {
                _sunrise = value;
                OnPropertyChanged();
            }
        }

        private string _sunset;

        public string Sunset
        {
            get { return _sunset; }
            set
            {
                _sunset = value;
                OnPropertyChanged();
            }
        }

        private string dateModified;
        public string DateModified
        {
            get => dateModified;
            set
            {
                dateModified = value;
                OnPropertyChanged();
            }
        }

        private GPS _gpsmodule;


        private string _currentWeather;

        /* public string CurrentWeather
         {
             get { return _currentWeather; }
             set
             {
                 _currentWeather = value;
                 OnPropertyChanged();
             }
         }*/

        RestService _restService;
        private GPS _gpsService;
        private HttpClient httpClient;
        private WeatherData _weatherdata;
        public WeatherData WeatherData { get { return _weatherdata; } set { _weatherdata = value;OnPropertyChanged(); } }

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            _gpsService = new GPS();
            httpClient = new HttpClient();
            _weatherdata = new WeatherData();
            BindingContext = this;
        }


        public async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                 WeatherData = await
                    _restService.
                    GetWeatherData(GenerateRequestURL(Constants.OpenWeatherMapEndpoint));

                Temp = (int)Math.Round(WeatherData.Main.Temperature);

                DateTimeOffset dtOffset = DateTimeOffset.FromUnixTimeSeconds(WeatherData.Sys.Sunrise);
                Sunrise = dtOffset.UtcDateTime.ToString();

                dtOffset = DateTimeOffset.FromUnixTimeSeconds(WeatherData.Sys.Sunset);
                Sunset = dtOffset.UtcDateTime.ToString();

                dtOffset = DateTimeOffset.FromUnixTimeSeconds(WeatherData.Dt);
                DateModified = dtOffset.UtcDateTime.ToString();
            }
        }

        string GenerateRequestURL(string endPoint)
        {
            string requestUri = endPoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
