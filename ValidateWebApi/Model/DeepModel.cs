using Newtonsoft.Json;

namespace ValidateWebApi.Model
{
    public class DeepModel
    {
        [JsonProperty("require_models")]
        public RequireModel[] RequireModels { get; set; }
        
        
        /// <summary>
        /// 
        /// </summary>
        public int A { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool B { get; set; }
    }
}