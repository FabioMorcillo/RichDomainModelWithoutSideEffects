using System.Collections.Generic;

using RichDomainModelWithoutSideEffects.Models.Base;

namespace RichDomainModelWithoutSideEffects.Models
{
    public class Language : ValueObject
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        private Language(string code, string name)
        {
            Code = code.ToUpper();
            Name = name.ToUpper();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
            yield return Name;
        }

        public static Result<Language> Create(string code, string name)
        {
            var results = Result.Combine(
                code.ValidateNotEmptyString(nameof(code)),
                name.ValidateNotEmptyString(nameof(name)));

            if (results.IsFailure)
                return Result.Fail<Language>(results.Error);

            var language = new Language(code, name);

            return Result.Ok(language);
        }
    }
}
