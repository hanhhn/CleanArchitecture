using Coffee.Domain.Interfaces;
using Coffee.Exceptions;
using Coffee.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Coffee.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
        where TContext : DbContext
    {
        private readonly DbContext _context;
        private readonly IIdentityContext _identityContext;
        private readonly IMediator _mediator;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<TContext>();
            _identityContext = serviceProvider.GetRequiredService<IIdentityContext>();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        //public UnitOfWork(TContext context, IIdentityContext identity, IMediator mediator)
        //{
        //    _context = context;
        //    _identityContext = identity;
        //    _mediator = mediator;
        //}

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            DetectChanges();
            await DispatchDomainEvents();

            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InformationException("Unable to update or delete. The record modified by another user. Try again!");
            }
        }

        public int SaveChanges()
        {
            DetectChanges();
            DispatchDomainEvents().GetAwaiter().GetResult();

            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InformationException("Unable to update or delete. The record modified by another user. Try again!");
            }
        }

        private void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
            if (_context.ChangeTracker.HasChanges())
            {
                foreach (var dbEntity in _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
                {
                    if (dbEntity.Entity is not IAuditableEntity entity)
                        continue;

                    var user = _identityContext.GetUserIdentity() ?? "system";
                    if (dbEntity.State == EntityState.Added)
                    {
                        entity.SetCreatedBy(user);
                        continue;
                    }

                    if (dbEntity.State == EntityState.Modified)
                    {
                        entity.SetUpdatedBy(user);
                    }
                }
            }
        }

        public async Task DispatchDomainEvents()
        {
            if (_context == null) return;

            var entities = _context.ChangeTracker
                .Entries<IAggregateRoot>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            if (entities.Any())
            {
                entities.ToList().ForEach(e => e.ClearDomainEvents());
                foreach (var @event in domainEvents) await _mediator.Publish(@event);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

