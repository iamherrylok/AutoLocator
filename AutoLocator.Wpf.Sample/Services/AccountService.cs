namespace AutoLocator.Wpf.Sample.Services
{
    public class AccountService
    {
        public AccountService()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
    }
}
