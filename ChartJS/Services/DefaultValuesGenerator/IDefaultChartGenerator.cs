using ChartJS.Models;
using ChartJS.Models.Datasets;

namespace ChartJS.Services.DefaultValuesGenerator
{
    public interface IDefaultChartGenerator
    {
        Chart<LineDataset> GenerateLineChart();

        Chart<RadarDataset> GenerateRadarChart();

        Chart<DoughnutDataset> GenerateDoughnutChart();

        Chart<DoughnutDataset> GeneratePieChart();

        Chart<BarDataset> GenerateBarChart();

        Chart<BarDataset> GenerateHorizontalBarChart();

        Chart<BubbleDataset> GenerateBubbleChart();
    }
}
