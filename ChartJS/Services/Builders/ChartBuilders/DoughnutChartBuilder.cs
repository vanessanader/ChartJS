using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Models.Options.DoughnutChart;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders
{
    public class DoughnutChartBuilder : ChartBuilder<DoughnutChartBuilder, DoughnutDataset>
    {
		public static DoughnutChartOptions chartOptions;

        protected override DoughnutChartBuilder BuilderInstance => this;

        public DoughnutChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, Data<DoughnutDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            chart = defaultChartGenerator.GenerateDoughnutChart();
            chartOptions = (DoughnutChartOptions)chart.Options;
            chart.Data = data;
        }

        public DoughnutChartBuilder SetCutoutPercentage(int cutoutPercentage)
        {
            chartOptions.CutoutPercentage = cutoutPercentage;

            return this;
        }

        public DoughnutChartBuilder SetRotation(double rotation)
        {
            chartOptions.Rotation = rotation;

            return this;
        }

        public DoughnutChartBuilder SetCircumference(double circumference)
        {
            chartOptions.Circumference = circumference;

            return this;
        }

        public DoughnutChartBuilder SetAnimateRotation(bool animateRotation)
        {
            chartOptions.Animation.AnimateRotate = animateRotation;

            return this;
        }

        public DoughnutChartBuilder SetAnimateScale(bool animateScale)
        {
            chartOptions.Animation.AnimateScale = animateScale;

            return this;
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
