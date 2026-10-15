using Azure.Core;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class GetByIdProductHandel : IRequestHandler<GetByIdProductQuery, Product>
    {
        private readonly ApplicationDbContext _context;

        public GetByIdProductHandel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(i => i.Id == request.id);
            return Task.FromResult(product);
        }
    }
}
