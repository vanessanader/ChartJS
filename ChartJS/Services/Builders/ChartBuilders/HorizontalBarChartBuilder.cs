using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Models.Options.BarChart;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders.ChartBuilders
{
    public class HorizontalBarChartBuilder : BarChartBuilder
    {
        public HorizontalBarChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, Data<BarDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter, data)
        {
			chart = defaultChartGenerator.GenerateHorizontalBarChart();
			chartOptions = (BarChartOptions)chart.Options;
			chart.Data = data;
		}

        public override Chart<BarDataset> BuildChart()
        {
			var errors = new List<string>();

			chartValidator.IsValid(chart, out errors);
			jsTemplateWriter.OverwriteTemplate(chart);

			return chart;
        }
    }
}
