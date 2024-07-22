namespace FullStackTest.Services.ViewModels
{
    public class SaveTaskRequest
    {
        public Guid? TaskId { get; set; }
        public Guid ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid StatusId { get; set; }
        public string SavedBy { get; set; }
    }
}
