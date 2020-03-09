namespace RichDomainModelWithoutSideEffects.Models.Base
{
    public static class ValidateResult
    {
        public static Result ValidateNotEmptyString(this string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail($"Must include a {propertyName}.");

            return Result.Ok();
        }

        public static Result ValidateNotNull(this object value, string propertyName)
        {
            if (value == null)
                return Result.Fail($"Must include a {propertyName}.");

            return Result.Ok();
        }
    }
}
