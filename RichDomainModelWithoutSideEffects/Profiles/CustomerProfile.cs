using AutoMapper;

using RichDomainModelWithoutSideEffects.Dto;
using RichDomainModelWithoutSideEffects.Models;

namespace RichDomainModelWithoutSideEffects.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<LanguageDto, Language>()
                .ConstructUsing(l => Language.Create(l.Code, l.Name));
                //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<CustomerDto, Customer>()
                .ConstructUsing((c, ctx) =>
                    Customer.Create(
                        c.Name,
                        ctx.Mapper.Map<Language>(c.Language)));
        }
    }
}