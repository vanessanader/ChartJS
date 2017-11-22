using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Services.Builders.ChartBuilders;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.Utility;
using ChartJS.Services.Validators;
using static ChartJS.Services.Builders.DataBuilders.ChartJS.Services.Builders.DoughnutDataStepsBuilder;

namespace ChartJS.Services.Builders.DataBuilders
{
	namespace ChartJS.Services.Builders
	{
		public class DoughnutDataStepsBuilder
		{
			readonly IRandomColorGenerator randomColorGenerator;
            bool IsPie;

			public DoughnutDataStepsBuilder(bool isPie = false)
			{
				randomColorGenerator = new RandomColorGenerator();
                IsPie = isPie;
			}

			public ICreateDoughnutDataBuilderStep StartBuildingChartData()
			{
                if (IsPie)
                {
                    return new DoughnutDataBuilder(randomColorGenerator, true);
                }

                return new DoughnutDataBuilder(randomColorGenerator);
			}

			public interface ICreateDoughnutDataBuilderStep
			{
				ISetDoughnutDataLabelsStep SetDataLabels(string[] dataLabels);
			}

			public interface ISetDoughnutDataLabelsStep
			{
                DoughnutDataBuilder AddDataset(int[] value, string label);
			}
		}
	}

    public class DoughnutDataBuilder : ICreateDoughnutDataBuilderStep, ISetDoughnutDataLabelsStep
    {
        protected Data<DoughnutDataset> data;
		protected int index = -1;
		protected readonly IRandomColorGenerator randomColorGenerator;
        readonly bool IsPie;
        string[] baseColorArray;

        public DoughnutDataBuilder (IRandomColorGenerator randomColorGenerator, bool isPie = false)
        {
            this.randomColorGenerator = randomColorGenerator;
            IsPie = isPie;

            data = new Data<DoughnutDataset>
			{
                Datasets = new List<DoughnutDataset>()
			};
        }

        public ISetDoughnutDataLabelsStep SetDataLabels(string[] dataLabels)
        {
            data.Labels = dataLabels;

            return this;       
        }

        public DoughnutDataBuilder AddDataset(int[] value, string label)
        {
			data.Datasets.Add(new DoughnutDataset());


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

				for (var i = 0; i < baseColorArray.Length; i++)
				{
					data.Datasets[0].BackgroundColor[i] = baseColorArray[0];
					data.Datasets[index].BackgroundColor[i] = baseColorArray[index];
				}
			}

			data.Datasets[index].Label = label;

			return this;
        }

		/// <summary>
		/// The fill color of the arcs in the dataset.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public DoughnutDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// The border color of the arcs in the dataset.
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public DoughnutDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// The border width of the arcs in the dataset.
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public DoughnutDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// The fill colour of the arcs when hovered.
		/// </summary>
		/// <returns>The hover background color.</returns>
		/// <param name="hoverBackgroundColor">Hover background color.</param>
		public DoughnutDataBuilder SetHoverBackgroundColor(string [] hoverBackgroundColor)
        {
            data.Datasets[index].HoverBackgroundColor = hoverBackgroundColor;

            return this;
        }

		/// <summary>
		/// The stroke colour of the arcs when hovered.
		/// </summary>
		/// <returns>The hover border color.</returns>
		/// <param name="hoverBorderColor">Hover border color.</param>
		public DoughnutDataBuilder SetHoverBorderColor(string[] hoverBorderColor)
        {
            data.Datasets[index].HoverBorderColor = hoverBorderColor;

            return this;
        }

		/// <summary>
		/// The stroke width of the arcs when hovered.
		/// </summary>
		/// <returns>The hover border width.</returns>
		/// <param name="hoverBorderWidth">Hover border width.</param>
		public DoughnutDataBuilder SetHoverBorderWidth(int[] hoverBorderWidth)
        {
            data.Datasets[index].HoverBorderWidth = hoverBorderWidth;

            return this;
        }

        public DoughnutChartBuilder CreateDataAndStartBuildingChart()
        {
			var chartValidator = new ChartValidator();

			var jsTemplateWriter = new JSTemplateWriter();

			var defaultChartGenerator = new DefaultChartGenerator();

            if(IsPie)
            {
                return new PieChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
            }

            return new DoughnutChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
        }
    }
}
