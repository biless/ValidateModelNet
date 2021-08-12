using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ValidateWebApi.Model
{
    public class RequireModel
    {
        [JsonProperty("a")] 
        [Range(0, 1,ErrorMessage = "中文错误")]
        public int A { get; set; }
    }
}