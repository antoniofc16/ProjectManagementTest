using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.Models
{
    public class TaskStatus
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

        public string GetColor()
        {
            switch (Description)
            {
                case "Pendiente":
                    return "indianred";
                case "En Progreso":
                    return "cornflowerblue";
                case "Completado":
                    return "palegreen";
                default:
                    return "lightgray";
            }
        }
    }
}
