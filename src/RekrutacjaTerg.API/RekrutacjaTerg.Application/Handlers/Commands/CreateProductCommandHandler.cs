using MediatR;
using RekrutacjaTerg.Domain.Entieties;
using System.ComponentModel.DataAnnotations;

namespace RekrutacjaTerg.Application.Handlers.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [Required]
        public required string Code { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        [Range(1, (double) decimal.MaxValue, ErrorMessage = "Value must be bigger than 0")]
        public required decimal Price { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = Product.Create(request.Code, request.Name, request.Price);
            await productRepository.Add(newProduct);
            await productRepository.SaveChanges();
            return newProduct.Id;
        }
    }
}
