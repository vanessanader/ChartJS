using ChartJS.Models;
using ChartJS.Models.Datasets;

namespace ChartJS.Services.TemplateWriter
{
    public interface IJSTemplateWriter
    {
        void OverwriteTemplate<T>(Chart<T> chart) where T : Dataset;
	}
}
