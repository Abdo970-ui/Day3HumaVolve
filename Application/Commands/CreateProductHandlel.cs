using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateProductHandlel : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductHandlel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new CreateProductCommand
            {
                Name = request.Name,
                Salary = request.Salary,
            };
            _context.Add(product);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
