using System.Collections.Generic;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Services.DefaultValuesGenerator;
using ChartJS.Services.TemplateWriter;
using ChartJS.Services.Utility;
using ChartJS.Services.Validators;

namespace ChartJS.Services.Builders.DataBuilders
{
    public abstract class DataBuilder <TBuilder, TDataset> 
        where TBuilder : DataBuilder<TBuilder, TDataset>
        where TDataset : Dataset
    {
		protected abstract TBuilder BuilderInstance { get; }
        protected Data<TDataset> data;
        protected int index = -1;
        protected readonly IRandomColorGenerator randomColorGenerator;
		protected readonly IChartValidator chartValidator;
		protected readonly IJSTemplateWriter jsTemplateWriter;
		protected readonly IDefaultChartGenerator defaultChartGenerator;

		protected DataBuilder(IRandomColorGenerator randomColorGenerator)
        {
            this.randomColorGenerator = randomColorGenerator;

            randomColorGenerator = new RandomColorGenerator();
            chartValidator = new ChartValidator();
            jsTemplateWriter = new JSTemplateWriter();
            defaultChartGenerator = new DefaultChartGenerator();
            data = new Data<TDataset>
            {
                Datasets = new List<TDataset>()
            };
		}

        public TBuilder SetBackgroundColor(string[] backgroundColor)
        {
            data.Datasets[index].BackgroundColor = backgroundColor;

            return BuilderInstance;
        }

        public TBuilder SetBorderColor(string[] borderColor)
        {
            data.Datasets[index].BorderColor = borderColor;

            return BuilderInstance;
        }

        public TBuilder SetBorderWidth(int[] borderWidth)
        {
            data.Datasets[index].BorderWidth = borderWidth;

            return BuilderInstance;
        }
    }
}
