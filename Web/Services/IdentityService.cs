using Coffee.Infrastructure.Interfaces;

namespace Web.Services
{
    public class IdentityService : IIdentityContext
	{
		public IdentityService()
		{
		}

        public string GetUID()
        {
            return Guid.NewGuid().ToString();
        }

        public string GetUserIdentity()
        {
            return Guid.NewGuid().ToString();
        }

        public string GetUserName()
        {
            return "hanhhn";
        }
    }
}

