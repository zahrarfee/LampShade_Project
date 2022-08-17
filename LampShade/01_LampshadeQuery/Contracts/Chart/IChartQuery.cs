using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.Chart
{
    public interface IChartQuery
    {
        ChartViewModel GetProductForChart(long categoryId);
    }
}
