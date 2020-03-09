using AutoMapper;

using RichDomainModelWithoutSideEffects.Dto;
using RichDomainModelWithoutSideEffects.Models;
using RichDomainModelWithoutSideEffects.Profiles;

namespace RichDomainModelWithoutSideEffects
{
    class Program
    {
        static void Main(string[] args)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerProfile());
                mc.AllowNullCollections = true;
            });

            var mapper = mappingConfig.CreateMapper();

            var customerDto = new CustomerDto
            {
                Name = "Fabio Morcillo do Nascimento",
                Language = new LanguageDto
                {
                    Code = "en",
                    Name = "English"
                }
            };

            var customer = mapper.Map<Customer>(customerDto);
        }
    }
}
