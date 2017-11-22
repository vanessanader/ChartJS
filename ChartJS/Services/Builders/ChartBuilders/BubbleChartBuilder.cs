using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders
{
    public class BubbleChartBuilder : ChartBuilder<BubbleChartBuilder, BubbleDataset>
    {
        protected override BubbleChartBuilder BuilderInstance => this;

        public BubbleChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, Data<BubbleDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            chart = defaultChartGenerator.GenerateBubbleChart();
            chart.Data = data;
        }

        public override Chart<BubbleDataset> BuildChart()
        {
            var errors = new List<string>(); 

            chartValidator.IsValid(chart,out errors);
			jsTemplateWriter.OverwriteTemplate(chart);

			return chart;
        }
    }
}
