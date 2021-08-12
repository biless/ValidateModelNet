using Newtonsoft.Json;

namespace ValidateWebApi.Model
{
    public class DeepModel
    {
        [JsonProperty("require_models")]
        public RequireModel[] RequireModels { get; set; }
    }
}