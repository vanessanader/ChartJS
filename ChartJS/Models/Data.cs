using System.Collections.Generic;
using ChartJS.Models.Datasets;

namespace ChartJS.Models
{
    public class Data <TDataset> where TDataset : Dataset
    {
        public string[] Labels { get; set; }

        public List<TDataset> Datasets { get; set; }
    }
}
