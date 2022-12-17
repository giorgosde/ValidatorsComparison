using System.Collections.Generic;
using System.Linq;

namespace ValidatorsComparison.Api.Validators;

public class Error
{
    public string Message { get; set; }
}

public class Warning
{
    public string Message { get; set; }
}

public class ValidationResult
{
    public bool IsValid { get; }
    public List<Error> Errors { get; } = new();
    public List<Warning> Warnings { get; } = new();

    public ValidationResult(bool isValid = true)
    {
        IsValid = isValid;
    }

    public ValidationResult(IEnumerable<Error> errors)
    {
        Errors.AddRange(errors);
        IsValid = !Errors.Any();
    }
}

public interface IValidator<TData>
{
    ValidationResult Validate(TData data);
}

public static class ValidationExtensions
{
    public static void AddError(this ValidationResult validationResult, string fieldName, string message)
    {
        validationResult.Errors.Add(new Error { Message = $"{fieldName} {message}" });
    }

    public static void AddWarning(this ValidationResult validationResult, string fieldName, string message)
    {
        validationResult.Warnings.Add(new Warning { Message = $"{fieldName} {message}" });
    }
}
