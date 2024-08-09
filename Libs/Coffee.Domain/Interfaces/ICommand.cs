using MediatR;

namespace Coffee.Domain.Interfaces
{
    public interface ICommand : IRequest
	{
	}

    public interface ICommand<TReponse> : IRequest<TReponse>
    {
    }
}

