namespace FullStackTest.Client.Services
{
    public class ComponentService
    {
        public event Action<bool> LoadingTrigger;

        public void IsLoading(bool isLoading)
        {
            this.LoadingTrigger.Invoke(isLoading);
        }
    }
}
