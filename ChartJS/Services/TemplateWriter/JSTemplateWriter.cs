using System.Collections.Generic;
using System.IO;
using ChartJS.Models;
using ChartJS.Models.Datasets;
using ChartJS.Services.JsonConverters;
using ChartJS.Services.TemplateWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ChartJS.Services
{
    public class JSTemplateWriter : IJSTemplateWriter
    {
		const string Outfile = @"/Users/iskandarchacra/Desktop/Desktop2/Bdeir_Project/js/main.js";
        readonly string jsTemplate = ChartJS.Properties.Resources.jsTemplate;
        public string overWrittenTemplate = ChartJS.Properties.Resources.jsTemplate;

        public void OverwriteTemplate<T>(Chart<T> chart) where T :Dataset
        {
            overWrittenTemplate = overWrittenTemplate.Replace("{animation}", chart.Animation.ToString());

			var chartJson = JsonConvert.SerializeObject
            (
                chart,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter(),
                        new ChartJsonConverter<T>()
                    },
					NullValueHandling = NullValueHandling.Ignore
				}
			);

            overWrittenTemplate = overWrittenTemplate.Replace("{chart}", chartJson);
			File.WriteAllText(Outfile, overWrittenTemplate);
        }
	}
}
