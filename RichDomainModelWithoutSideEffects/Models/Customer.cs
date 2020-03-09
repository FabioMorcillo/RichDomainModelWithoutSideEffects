using System;

using RichDomainModelWithoutSideEffects.Models.Base;

namespace RichDomainModelWithoutSideEffects.Models
{
    public partial class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Language Language { get; private set; }

        private Customer(string name, Language language)
        {
            Id = Guid.NewGuid();

            Name = name;
            Language = language;
        }

        public static Result<Customer> Create(string name, Language language)
        {
            var resultCombine = Result.Combine(
                name.ValidateNotEmptyString(nameof(name)),
                language.ValidateNotNull(nameof(language)));

            if (resultCombine.IsFailure)
                return Result.Fail<Customer>(resultCombine.Error);

            var customer = new Customer(name, language);

            return Result.Ok(customer);
        }

        public Result SetLanguage(Language language)
        {
            var languageValidation = language.ValidateNotNull(nameof(language));

            if (languageValidation.IsFailure)
                return languageValidation;

            Language = language;

            return Result.Ok();
        }
    }
}
