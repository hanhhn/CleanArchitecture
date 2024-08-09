namespace Coffee.Exceptions
{
    public class ValidationException : InformationException
	{
        private const string DEFAULT_MSG = "One or more validation failures have occurred.";

        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base(DEFAULT_MSG)
		{
            Errors = new Dictionary<string, string[]>();
        }

		public ValidationException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IDictionary<string, string[]> errors) : base(DEFAULT_MSG)
        {
            Errors = errors;
        }
    }
}

