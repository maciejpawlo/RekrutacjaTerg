using AutoMapper;
using RekrutacjaTerg.Application.Common.DTOs;
using RekrutacjaTerg.Domain.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaTerg.Application.Common.MappingProfiles
{
    internal class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
