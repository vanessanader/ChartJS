using ChartJS.Models.Options;
using ChartJS.Models.Datasets;

namespace ChartJS.Models
{
    public class Chart<TDataset> where TDataset : Dataset
    {
        public AnimationType Animation { get; set; }

		public ChartType Type { get; set; }

        public Data<TDataset> Data{ get; set; } 

        public Option Options { get; set; }
    }
}
