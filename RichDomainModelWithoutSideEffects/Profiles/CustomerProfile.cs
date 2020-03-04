using AutoMapper;

using RichDomainModelWithoutSideEffects.Dto;
using RichDomainModelWithoutSideEffects.Models;

namespace RichDomainModelWithoutSideEffects.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ConstructUsing(c => new Customer(c.Name, c.Language.Name));
                //.IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
