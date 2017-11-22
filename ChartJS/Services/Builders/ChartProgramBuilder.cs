using ChartJS.Services.Builders.DataBuilders.ChartJS.Services.Builders;

namespace ChartJS.Services.Builders
{
    public static class ChartProgramBuilder
    {
        public static BarDataStepsBuilder CreateBarChart()
        {
            return new BarDataStepsBuilder();
        }

        public static BarDataStepsBuilder CreateHorizontalBarChart()
        {
            return new BarDataStepsBuilder(true);
		}

        public static DoughnutDataStepsBuilder CreatePieChart()
        {
            return new DoughnutDataStepsBuilder(true);
        }

        public static DoughnutDataStepsBuilder CreateDoughnutChart()
        {
            return new DoughnutDataStepsBuilder();
        }

        public static LineDataStepsBuilder CreateLineChart()
        {
            return new LineDataStepsBuilder();
        }

        public static RadarDataStepsBuilder CreateRadarChart()
        {
            return new RadarDataStepsBuilder();
        }

        public static BubbleDataStepsBuilder CreateBubbleChart()
        {
            return new BubbleDataStepsBuilder();
        }
    }
}
