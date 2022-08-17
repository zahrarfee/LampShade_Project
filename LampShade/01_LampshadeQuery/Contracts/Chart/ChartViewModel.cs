using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ShopManagement.Application.Contracts.Product;

namespace _01_LampshadeQuery.Contracts.Chart
{
    public class ChartViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "prices")]
        public List<double> Prices { get; set; }

        public List<ChartItemViewModel> Products;
    }
}
