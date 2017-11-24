using ChartJS;
using ChartJS.Services;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.Utility;
using ChartJS.Services.Validators;

namespace ChartJSLib
{
	public class Launcher
	{
       	public static void Main()
		{
			var defaultChartGenerator = new DefaultChartGenerator();

			var randomColorGenerator = new RandomColorGenerator();

			var chartValidator = new ChartValidator();

			var jsTemplateWriter = new JSTemplateWriter(@"/Users/iskandarchacra/Desktop/chartjssample/js/main.js");

            var chartJsProgram = new SampleChartJsProgram(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);

			//chartJsProgram.BarChart();
			//chartJsProgram.MultiDatasetBarChart();

            //chartJsProgram.PieChart(); NO X Y AXES
            //chartJsProgram.MultiDatasetPieChart();

            //chartJsProgram.LineChart();
            //chartJsProgram.MultiDatasetLineChart();

            //chartJsProgram.RadarChart(); NO X Y AXES
            chartJsProgram.MultiDatasetRadarChart();

            //chartJsProgram.BubbleChart();
            //chartJsProgram.MultiDatasetBubbleChart();

            //chartJsProgram.DoughnutChart(); NO X Y AXES
            //chartJsProgram.MultiDatasetDoughnutChart();

            //chartJsProgram.HorizontalBarChart();
            //chartJsProgram.MultiDatasetHorizontalBarChart();
       	}
	}
}
