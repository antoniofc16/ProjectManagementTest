using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public abstract class ResponseModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
