using System;
using Coffee.Infrastructure.EntityFrameworkCore.Interfaces;
using Domain.Entities.PostAggregate;

namespace Core.Interfaces.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
    }
}

