using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Services.Builders;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Utility;
using ChartJS.Services.Validators;
using ChartJSLib;

namespace ChartJS
{
    public class SampleChartJsProgram
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IJSTemplateWriter jsTemplateWriter;
        readonly IDefaultChartGenerator defaultChartGenerator;

        public SampleChartJsProgram(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.jsTemplateWriter = jsTemplateWriter;
            this.defaultChartGenerator = defaultChartGenerator;
        }

        public Chart<BarDataset> MultiDatasetBarChart()
        {
            return ChartProgramBuilder
                .CreateBarChart()
                .StartBuildingChartData()
                .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
                .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
                .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
                .CreateDataAndStartBuildingChart()
                .BuildChart();
        }

		public Chart<BarDataset> BarChart()
		{
			return ChartProgramBuilder
				.CreateBarChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
                .SetOffsetGridLines(false)
				.BuildChart();
		}

		public Chart<BarDataset> MultiDatasetHorizontalBarChart()
		{
			return ChartProgramBuilder
				.CreateHorizontalBarChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
				.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

		public Chart<BarDataset> HorizontalBarChart()
		{
			return ChartProgramBuilder
				.CreateHorizontalBarChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<LineDataset> MultiDatasetLineChart()
		{
			return ChartProgramBuilder
                .CreateLineChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                .SetFill(true)
				.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
                .SetFill(true)
				.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<LineDataset> LineChart()
		{
			return ChartProgramBuilder
				.CreateLineChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                .SetFill(true)
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<RadarDataset> MultiDatasetRadarChart()
		{
			return ChartProgramBuilder
                .CreateRadarChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                .SetFill(true)
				.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
                .SetFill(true)
				.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
                .SetFill(true)
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<RadarDataset> RadarChart()
		{
			return ChartProgramBuilder
                .CreateRadarChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                .SetFill(true)
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> MultiDatasetDoughnutChart()
		{
			return ChartProgramBuilder
                .CreateDoughnutChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
				.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> DoughnutChart()
		{
			return ChartProgramBuilder
                .CreateDoughnutChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> MultiDatasetPieChart()
		{
			return ChartProgramBuilder
                .CreatePieChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
				.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> PieChart()
		{
			return ChartProgramBuilder
                .CreatePieChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<BubbleDataset> BubbleChart()
        {		
			return ChartProgramBuilder
                .CreateBubbleChart()
				.StartBuildingChartData()
				.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
                .AddDataset(new List<BubblePoint> 
                { 
                    new BubblePoint
                    {
        				R= 4,
        			    X = 20, 
                        Y = 30
        			},
                    new BubblePoint
                    {
                        R = 4,
                        X = 15,
                        Y = 15
                    },
                    new BubblePoint
                    {
                        R = 4,
                        X = 10,
                        Y = 10
                    }
                }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
        }

        public Chart<BubbleDataset> MultiDatasetBubbleChart()
        {
            return ChartProgramBuilder
                .CreateBubbleChart()
                .StartBuildingChartData()
                .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
                .AddDataset(new List<BubblePoint>
                {
                    new BubblePoint
                    {
                        R= 4,
                        X = 20,
                        Y = 30
					},
					new BubblePoint
					{
						R = 1,
						X = 4,
						Y = 23
					},
					new BubblePoint
					{
						R = 8,
						X = 9,
						Y = 26
					}
                }, "First Dataset")
                .AddDataset(new List<BubblePoint>
                {
                    new BubblePoint
                    {
                        R = 5,
                        X= 15,
                        Y = 15
					},
					new BubblePoint
					{
						R = 5,
						X = 85,
						Y = 15
					},
					new BubblePoint
					{
						R = 4,
						X = 45,
						Y = 52
					}
                }, "Second Dataset")
                    .AddDataset(new List<BubblePoint>
                {
                    new BubblePoint()
                    {
                        R = 9,
                        X = 5,
                        Y = 10
					},
					new BubblePoint
					{
						R = 4,
						X = 66,
						Y = 41
					},
					new BubblePoint
					{
						R = 4,
						X = 33,
						Y = 4
					}
                }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}
    }
}

