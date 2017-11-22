using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Models.Options.RadarChart;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders
{
    public class RadarChartBuilder : ChartBuilder<RadarChartBuilder, RadarDataset>
    {
		public static RadarOptionsScale radarScale;

        protected override RadarChartBuilder BuilderInstance => this;

        public RadarChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, Data<RadarDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            chart = defaultChartGenerator.GenerateRadarChart();
            radarScale = (RadarOptionsScale)chart.Options.Scales;
			chart.Data = data;
		}

        /// <summary>
        /// Sets whether the scale is displayed
        /// </summary>
        /// <returns>The scale display.</returns>
        /// <param name="display">If set to <c>true</c> display.</param>
        public RadarChartBuilder SetScaleDisplay(bool display)
        {
            radarScale.Display = display;
            chart.Options.Scales.XAxes[0].Display = display;   

            return this;
        }

        public override Chart<RadarDataset> BuildChart()
        {
			chart.Options.Scales = radarScale;
			var errors = new List<string>();

			chartValidator.IsValid(chart, out errors);
			jsTemplateWriter.OverwriteTemplate(chart);

			return chart;
        }
    }
}
