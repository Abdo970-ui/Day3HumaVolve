using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class GetByIdProductQuery : IRequest<Product>
    {
        public int id { get; set; }
    }
}
