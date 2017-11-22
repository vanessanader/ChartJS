using ChartJS.Models.Datasets;
using ChartJS.Services.Builders.ChartBuilders;
using ChartJS.Services.Utility;

namespace ChartJS.Services.Builders.DataBuilders
{
    using System.Collections.Generic;
    using global::ChartJS.Models;
    using global::ChartJS.Services.DefaultValuesGenerator;
    using global::ChartJS.Services.Validators;
    using static global::ChartJS.Services.Builders.DataBuilders.ChartJS.Services.Builders.BarDataStepsBuilder;

    namespace ChartJS.Services.Builders
	{
		public class BarDataStepsBuilder
		{
			readonly IRandomColorGenerator randomColorGenerator;
            bool IsHorizontal;

			public BarDataStepsBuilder(bool isHorizontal = false)
			{
				randomColorGenerator = new RandomColorGenerator();
                IsHorizontal = isHorizontal;
			}

			public ICreateBarDataBuilderStep StartBuildingChartData()
			{
                if (IsHorizontal)
                {
                    return new BarDataBuilder(randomColorGenerator, true);
                }

				return new BarDataBuilder(randomColorGenerator);
			}

			public interface ICreateBarDataBuilderStep
			{
                ISetDataLabelsStep SetDataLabels(string[] dataLabels);
			}

			public interface ISetDataLabelsStep
			{
                BarDataBuilder AddDataset(int[] value, string label);
			}
        }
	}

    public class BarDataBuilder : ICreateBarDataBuilderStep, ISetDataLabelsStep
    {
        protected Data<BarDataset> data;
		protected int index = -1;
		protected readonly IRandomColorGenerator randomColorGenerator;
        readonly bool IsHorizontal;
        string[] baseColorArray;

		public BarDataBuilder(IRandomColorGenerator randomColorGenerator, bool isHorizontal = false)
        {
            this.randomColorGenerator = randomColorGenerator;
            IsHorizontal = isHorizontal;

            data = new Data<BarDataset>
			{
                Datasets = new List<BarDataset>()
			};
        }

        public ISetDataLabelsStep SetDataLabels(string[] dataLabels)
        {
            data.Labels = dataLabels;

            return this;
        }

		public BarDataBuilder AddDataset(int[] value, string label)
		{
			data.Datasets.Add(new BarDataset());

			index++;
			data.Datasets[index].Data = value;

			if (index == 0)
			{
				data.Datasets[0].BackgroundColor = randomColorGenerator.GenerateColorsForPointList(value);

                baseColorArray = new string[data.Labels.Length];

                for (var i = 0; i < baseColorArray.Length; i++)
                {
                    baseColorArray[i] = data.Datasets[0].BackgroundColor[i];
                }
			}

			else
			{
                data.Datasets[index].BackgroundColor = new string[data.Labels.Length];

                for (var i = 0; i < baseColorArray.Length; i++ )
                {
                    data.Datasets[0].BackgroundColor[i] = baseColorArray[0];
                    data.Datasets[index].BackgroundColor[i] = baseColorArray[index];
                }
			}

			data.Datasets[index].Label = label;

			return this;
		}

		/// <summary>
		/// The fill color of the bar.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public BarDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// The color of the bar border. 
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public BarDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// The stroke width of the bar in pixels.
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public BarDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// Which edge to skip drawing the border for.
		/// </summary>
		/// <returns>The border skipped.</returns>
		/// <param name="borderSkipped">Border skipped.</param>
		    public BarDataBuilder SetBorderSkipped(string borderSkipped)
        {
            data.Datasets[index].BorderSkipped = borderSkipped;

            return this;
        }

		/// <summary>
		/// The fill colour of the bars when hovered.
		/// </summary>
		/// <returns>The hover background color.</returns>
		/// <param name="hoverBackgroundColor">Hover background color.</param>
		public BarDataBuilder SetHoverBackgroundColor(string [] hoverBackgroundColor)
        {
            data.Datasets[index].HoverBackgroundColor = hoverBackgroundColor;

            return this;    
        }

		/// <summary>
		/// The stroke colour of the bars when hovered.
		/// </summary>
		/// <returns>The hover border color.</returns>
		/// <param name="hoverBorderColor">Hover border color.</param>
		public BarDataBuilder SetHoverBorderColor(string [] hoverBorderColor)
        {
            data.Datasets[index].HoverBorderColor = hoverBorderColor;

            return this;
        }

		/// <summary>
		/// The stroke width of the bars when hovered.
		/// </summary>
		/// <returns>The hover border width.</returns>
		/// <param name="hoverBorderWidth">Hover border width.</param>
		public BarDataBuilder SetHoverBorderWidth(int [] hoverBorderWidth)
        {
            data.Datasets[index].HoverBorderWidth = hoverBorderWidth;

            return this;
        }

        public BarChartBuilder CreateDataAndStartBuildingChart()
        {
            var chartValidator = new ChartValidator();

            var jsTemplateWriter = new JSTemplateWriter();

            var defaultChartGenerator = new DefaultChartGenerator();

            if (IsHorizontal)
            {
                return new HorizontalBarChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
            }

            return new BarChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
        }
    }
}
