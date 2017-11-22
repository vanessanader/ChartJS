using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Models.Options.BarChart;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders
{
    public class BarChartBuilder : ChartBuilder<BarChartBuilder, BarDataset>
    {
        public static BarChartOptions chartOptions;

        protected override BarChartBuilder BuilderInstance => this;

        public BarChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, Data<BarDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            chart = defaultChartGenerator.GenerateBarChart();
			chartOptions = (BarChartOptions)chart.Options;
			chart.Data = data;
		}

        /// <summary>
        /// Bar charts can be configured into stacked bar charts by changing the settings on the X and Y axes to enable stacking. 
        /// Stacked bar charts can be used to show how one data series is made up of a number of smaller pieces.
        /// </summary>
        /// <returns>The is stacked.</returns>
        /// <param name="stacked">If set to <c>true</c> stacked.</param>
        public BarChartBuilder SetIsStacked(bool stacked)
        {
            chart.Options.Scales.XAxes[0].Stacked = stacked;
            chart.Options.Scales.YAxes[0].Stacked = stacked;

            return this;
        }

		/// <summary>
		/// Percent (0-1) of the available width each bar should be within the category width. 
        /// 1.0 will take the whole category width and put the bars right next to each other.
		/// </summary>
		/// <returns>The bar percentage.</returns>
		/// <param name="barPercentage">Bar percentage.</param>
		public BarChartBuilder SetBarPercentage(double barPercentage)
        {
            chartOptions.BarPercentage = barPercentage;

            return this;
        }

		/// <summary>
		/// Percent (0-1) of the available width each category should be within the sample width. 
		/// </summary>
		/// <returns>The category percentage.</returns>
		/// <param name="categoryPercentage">Category percentage.</param>
		public BarChartBuilder SetCategoryPercentage(double categoryPercentage)
        {
            chartOptions.CategoryPercentage = categoryPercentage;

            return this;
        }

		/// <summary>
		/// Manually set width of each bar in pixels. 
        ///  If not set, the base sample widths are calculated automatically so that they take the full available widths without overlap. 
        /// Then, the bars are sized using barPercentage and categoryPercentage.
		/// </summary>
		/// <returns>The bar thickness.</returns>
		/// <param name="barThickness">Bar thickness.</param>
		public BarChartBuilder SetBarThickness(double barThickness)
        {
            chartOptions.BarThickness = barThickness;

            return this;
        }

		/// <summary>
		/// Set this to ensure that bars are not sized thicker than this.
		/// </summary>
		/// <returns>The max bar thickness.</returns>
		/// <param name="maxBarThickness">Max bar thickness.</param>
		public BarChartBuilder SetMaxBarThickness(double maxBarThickness)
        {
            chartOptions.MaxBarThickness = maxBarThickness;

            return this;
        }

		/// <summary>
		/// If true, the bars for a particular data point fall between the grid lines. 
        /// The grid line will move to the left by one half of the tick interval. 
        /// If false, the grid line will go right down the middle of the bars. 
		/// </summary>
		/// <returns>The offset grid lines.</returns>
		/// <param name="offsetGridLines">If set to <c>true</c> offset grid lines.</param>
		public BarChartBuilder SetOffsetGridLines (bool offsetGridLines)
        {
            chartOptions.GridLines.OffsetGridLines = offsetGridLines;

            return this;
        }

        public override Chart<BarDataset> BuildChart()
        {
			chart.Options = chartOptions;

            var errors = new List<string>();

			chartValidator.IsValid(chart, out errors);
            jsTemplateWriter.OverwriteTemplate(chart);

            return chart;
        }
    }
}
