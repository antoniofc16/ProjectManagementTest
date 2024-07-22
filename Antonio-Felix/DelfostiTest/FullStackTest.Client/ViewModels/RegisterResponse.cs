using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public class RegisterResponse : ResponseModel
    {
        [JsonPropertyName("isSuccessful")]
        public bool IsSuccessful { get; set; }
    }
}
