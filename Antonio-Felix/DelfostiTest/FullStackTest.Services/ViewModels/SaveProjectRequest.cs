namespace FullStackTest.Services.ViewModels
{
    public class SaveProjectRequest
    {
        public Guid? ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string SavedBy { get; set; }
    }
}
