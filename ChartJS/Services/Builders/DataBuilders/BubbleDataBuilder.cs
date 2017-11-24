using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Services.Utility;
using ChartJSLib;

namespace ChartJS.Services.Builders.DataBuilders
{
    using global::ChartJS.Services.DefaultValuesGenerator;
    using global::ChartJS.Services.TemplateWriter;
    using global::ChartJS.Services.Validators;
    using static global::ChartJS.Services.Builders.DataBuilders.ChartJS.Services.Builders.BubbleDataStepsBuilder;

    namespace ChartJS.Services.Builders{

        public class BubbleDataStepsBuilder
        {
            readonly IRandomColorGenerator randomColorGenerator;
            readonly IChartValidator chartValidator;
            readonly IJSTemplateWriter jsTemplateWriter;
            readonly IDefaultChartGenerator defaultChartGenerator;

            public BubbleDataStepsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator)
            {
                this.randomColorGenerator = randomColorGenerator;
                this.chartValidator = chartValidator;
                this.jsTemplateWriter = jsTemplateWriter;
                this.defaultChartGenerator = defaultChartGenerator;
            }

            public ICreateBubbleDataBuilderStep StartBuildingChartData()
            {
                return new BubbleDataBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
            }

            public interface ICreateBubbleDataBuilderStep
            {
                ISetBubbleDataLabelsStep SetDataLabels(string[] dataLabels);
            }

            public interface ISetBubbleDataLabelsStep
            {
                BubbleDataBuilder AddDataset(List<BubblePoint> pointList, string label);
            }
        }
    }

    public class BubbleDataBuilder : ICreateBubbleDataBuilderStep, ISetBubbleDataLabelsStep
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IJSTemplateWriter jsTemplateWriter;
        readonly IDefaultChartGenerator defaultChartGenerator;
        protected Data<BubbleDataset> data;
		protected int index = -1;

		public BubbleDataBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJSTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.jsTemplateWriter = jsTemplateWriter;
            this.defaultChartGenerator = defaultChartGenerator;

            data = new Data<BubbleDataset>
			{
                Datasets = new List<BubbleDataset>()
			};
        }

		public ISetBubbleDataLabelsStep SetDataLabels(string[] dataLabels)
		{
			data.Labels = dataLabels;

			return this;
		}

        public BubbleDataBuilder AddDataset(List<BubblePoint> pointList, string label)
        {
            data.Datasets.Add(new BubbleDataset
            {
                HoverBorderWidth = 1,
                HoverRadius = 4,
                HitRadius = 1,
                PointStyle = PointStyleType.circle,
                Radius = 3
             });

			index++;
			data.Datasets[index].Data = pointList;
			data.Datasets[index].BackgroundColor = randomColorGenerator.GenerateColorsForBubblePointList(pointList);
			data.Datasets[index].Label = label;

			return this;        
        }

		/// <summary>
		/// Sets the bubble background color.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public BubbleDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// Sets the bubble border color.
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public BubbleDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// Sets the bubble border width (in pixels).
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public BubbleDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// Sets the bubble background color when hovered.
		/// </summary>
		/// <returns>The hover background color.</returns>
		/// <param name="hoverBackgroundColor">Hover background color.</param>
		public BubbleDataBuilder SetHoverBackgroundColor(string hoverBackgroundColor)
        {
            data.Datasets[index].HoverBackgroundColor = hoverBackgroundColor;

            return this;
        }

		/// <summary>
		/// Sets the bubble border color when hovered.
		/// </summary>
		/// <returns>The hover border color.</returns>
		/// <param name="hoverBorderColor">Hover border color.</param>
		public BubbleDataBuilder SetHoverBorderColor(string hoverBorderColor)
        {
            data.Datasets[index].HoverBorderColor = hoverBorderColor;

            return this;
        }

		/// <summary>
		/// Sets the bubble border width when hovered (in pixels).
		/// </summary>
		/// <returns>The hover border width.</returns>
		/// <param name="hoverBorderWidth">Hover border width.</param>
		public BubbleDataBuilder SetHoverBorderWidth(int hoverBorderWidth)
        {
            data.Datasets[index].HoverBorderWidth = hoverBorderWidth;

            return this;
        }

		/// <summary>
		/// Sets the bubble additional radius when hovered (in pixels).
        /// </summary>
		/// <returns>The hover radius.</returns>
		/// <param name="hoverRadius">Hover radius.</param>
		public BubbleDataBuilder SetHoverRadius(int hoverRadius)
        {
            data.Datasets[index].HoverRadius = hoverRadius;

            return this;
        }

		/// <summary>
		/// Sets the bubble additional radius for hit detection (in pixels).
		/// </summary>
		/// <returns>The hit radius.</returns>
		/// <param name="hitRadius">Hit radius.</param>
		public BubbleDataBuilder SetHitRadius(int hitRadius)
        {
            data.Datasets[index].HitRadius = hitRadius;

            return this;
        }

		/// <summary>
		/// Sets the bubble shape style.
		/// </summary>
		/// <returns>The point style.</returns>
		/// <param name="pointStyle">Point style.</param>
		public BubbleDataBuilder SetPointStyle(PointStyleType pointStyle)
        {
            data.Datasets[index].PointStyle = pointStyle;

            return this;
        }

        /// <summary>
        /// Sets the bubble radius.
        /// </summary>
        /// <returns>The radius.</returns>
        /// <param name="radius">Radius.</param>
        public BubbleDataBuilder SetRadius(int radius)
        {
            data.Datasets[index].Radius = radius;

            return this;
        }

        public BubbleChartBuilder CreateDataAndStartBuildingChart()
        {
			return new BubbleChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
        }
    }
}
