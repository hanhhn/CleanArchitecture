namespace Coffee.Exceptions
{
    public class InformationException : Exception
	{
		public InformationException() : base()
		{
		}

		public InformationException(string message) : base(message)
        {
        }

        public InformationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

