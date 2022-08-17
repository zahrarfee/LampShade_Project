using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Chart;
using _01_LampshadeQuery.Contracts.Product;
using Newtonsoft.Json;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductApplication _productApplication;
        private readonly IProductQuery _productQuery;
        private readonly IChartQuery _chartQuery;
        public Chart DoughnutDataSet { get; set; }
        public List<Chart> BarLineDataSet { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IProductApplication productApplication, IProductQuery productQuery, IChartQuery chartQuery)
        {
            _logger = logger;
            _productApplication = productApplication;
            _productQuery = productQuery;
            _chartQuery = chartQuery;
        }

        public void OnGet()
        {
            var query = _chartQuery.GetProductForChart(27);
            var name = query.Name;
            var dates = query.Prices;

            BarLineDataSet = new List<Chart>
            {
                

            new Chart
                {
                    Label = name,
                    //Data = new List<int> {100, 200, 250, 170, 50},
                    Data=dates,
                    BackgroundColor = new[] {"#ffcdb2"},
                    BorderColor = "#b5838d"
                },
                //new Chart
                //{
                //    Label = "Samsung",
                //    Data = new List<int> {200, 300, 350, 270, 100},
                //    BackgroundColor = new[] {"#ffc8dd"},
                //    BorderColor = "#ffafcc"
                //},
                //new Chart
                //{
                //    Label = "Total",
                //    Data = new List<int> {300, 500, 600, 440, 150},
                //    BackgroundColor = new[] {"#0077b6"},
                //    BorderColor = "#023e8a"
                //},
            };
            //DoughnutDataSet = new Chart
            //{
            //    Label = "Apple",
            //    Data = new List<int> { 100, 200, 250, 170, 50 },
            //    BorderColor = "#ffcdb2",
            //    BackgroundColor = new[] { "#b5838d", "#ffd166", "#7f4f24", "#ef233c", "#003049" }
            //};

        }
        public class Chart
        {

            [JsonProperty(PropertyName = "label")]
            public string Label { get; set; }
            [JsonProperty(PropertyName = "data")]
            public List<double> Data { get; set; }
            [JsonProperty(PropertyName = "backgroundColor")]
            public string[] BackgroundColor { get; set; }
            [JsonProperty(PropertyName = "borderColor")]
            public string BorderColor { get; set; }
        }
    }
}
