using MediatR;

namespace Coffee.Domain.Interfaces
{
    public interface IQuery : IRequest
	{
	}

    public interface IQuery<TReponse> : IRequest<TReponse>
    {
    }
}

