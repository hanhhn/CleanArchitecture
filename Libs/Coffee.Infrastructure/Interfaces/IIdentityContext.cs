namespace Coffee.Infrastructure.Interfaces
{
    public interface IIdentityContext
    {
        string GetUID();
        string GetUserIdentity();
        string GetUserName();
    }
}

