using ChartJS.Services.Builders.DataBuilders.ChartJS.Services.Builders;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Utility;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders
{
    public class ChartProgramBuilder
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IJSTemplateWriter jsTemplateWriter;
        readonly IDefaultChartGenerator defaultChartGenerator;

        public ChartProgramBuilder(string javascriptFile)
        {
            randomColorGenerator = new RandomColorGenerator();
            chartValidator = new ChartValidator();
            jsTemplateWriter = new JSTemplateWriter(javascriptFile);
            defaultChartGenerator = new DefaultChartGenerator();
        }

        public BarDataStepsBuilder CreateBarChart()
        {
            return new BarDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
        }

        public BarDataStepsBuilder CreateHorizontalBarChart()
        {
            return new BarDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator, true);
		}

        public DoughnutDataStepsBuilder CreatePieChart()
        {
            return new DoughnutDataStepsBuilder(true);
        }

        public DoughnutDataStepsBuilder CreateDoughnutChart()
        {
            return new DoughnutDataStepsBuilder();
        }

        public LineDataStepsBuilder CreateLineChart()
        {
            return new LineDataStepsBuilder();
        }

        public RadarDataStepsBuilder CreateRadarChart()
        {
            return new RadarDataStepsBuilder();
        }

        public BubbleDataStepsBuilder CreateBubbleChart()
        {
            return new BubbleDataStepsBuilder();
        }
    }
}
