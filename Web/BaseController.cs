using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [ApiController]
	public class BaseController : ControllerBase
	{
		protected readonly IMediator _mediator;

		public BaseController(IMediator mediator)
		{
			_mediator = mediator;
		}
	}
}

