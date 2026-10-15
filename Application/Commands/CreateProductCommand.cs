using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
