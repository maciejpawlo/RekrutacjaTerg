using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RekrutacjaTerg.Application.Common.DTOs;
using RekrutacjaTerg.Application.Common.Extensions;
using RekrutacjaTerg.Domain.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaTerg.Application.Handlers.Queries
{
    public class GetProductsQuery : IRequest<PagedList<ProductDTO>>
    {
        public PageSettings PageSettings { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedList<ProductDTO>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<PagedList<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = productRepository.GetAll()
                .AsNoTracking()
                .ConditionalWhere(!string.IsNullOrEmpty(request.Name), x => x.Name == request.Name)
                .ConditionalWhere(!string.IsNullOrEmpty(request.Code), x => x.Code == request.Code)
                .ConditionalWhere(request.MaxPrice != null, x => x.Price <= request.MaxPrice)
                .ConditionalWhere(request.MinPrice != null, x => x.Price >= request.MinPrice)
                .ProjectTo<ProductDTO>(mapper.ConfigurationProvider);

            var result = await PagedList<ProductDTO>.CreateAsync(query, request.PageSettings.PageNumber, request.PageSettings.PageSize);
            return result;
        }
    }
}
