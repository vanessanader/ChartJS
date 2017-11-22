using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Models.Options.DoughnutChart;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders.ChartBuilders
{
    public class PieChartBuilder : DoughnutChartBuilder
    {
        public PieChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, Data<DoughnutDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter, data)
        {
            chart = defaultChartGenerator.GeneratePieChart();
            chartOptions = (DoughnutChartOptions)chart.Options;
			chart.Data = data;
		}

        public override Chart<DoughnutDataset> BuildChart()
        {
            chart.Options = chartOptions;

			var errors = new List<string>();

			chartValidator.IsValid(chart, out errors);
			jsTemplateWriter.OverwriteTemplate(chart);

			return chart;
        }
    }
}
