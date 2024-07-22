namespace FullStackTest.Client.Commons
{
    public static class ProjectManagementCommons
    {
        public class TaskStatuses
        {
            public static Guid Pending = Guid.Parse("62607148-7DDE-483C-8B53-41533D516451"); 
            public static Guid InProcess = Guid.Parse("62607148-7DDE-483C-8B53-41533D516452"); 
            public static Guid Completed = Guid.Parse("62607148-7DDE-483C-8B53-41533D516453"); 
        }

        public class UserRoles
        {
            public static Guid Admin = Guid.Parse("62607148-7DDE-483C-8B53-41533D516441"); 
            public static Guid Consumer = Guid.Parse("62607148-7DDE-483C-8B53-41533D516442"); 
        }
    }
}
