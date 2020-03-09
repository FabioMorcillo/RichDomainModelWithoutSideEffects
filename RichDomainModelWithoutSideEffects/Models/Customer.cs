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
                ValidateName(name),
                ValidateLanguage(language));

            if (resultCombine.IsFailure)
                return Result.Fail<Customer>(resultCombine.Error);

            var customer = new Customer(name, language);

            return Result.Ok(customer);
        }

        public Result SetLanguage(Language language)
        {
            var languageValidation = ValidateLanguage(language);

            if (languageValidation.IsFailure)
                return languageValidation;

            Language = language;

            return Result.Ok();
        }

        private static Result ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Fail<Customer>("Must include a name.");

            return Result.Ok();
        }

        private static Result ValidateLanguage(Language language)
        {
            if (language == null)
                return Result.Fail("Must include a language.");

            return Result.Ok();
        }
    }
}
