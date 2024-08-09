using Coffee.Exceptions;

namespace Coffee.Domain.Exceptions
{
    public class RecordNotFoundException : InformationException
	{
		public RecordNotFoundException() : base("Record not found. Please check the input and try again.")
		{
		}

        public RecordNotFoundException(string message) : base(message)
        {
        }
    }
}

