using System;
using ValidatorsComparison.Api.Models;

namespace ValidatorsComparison.Api.Validators;

public interface IVehicleCustomValidator: IValidator<Vehicle>
{ }

public class VehicleCustomValidator : IVehicleCustomValidator
{
    private const string _mustBeProvidedErrorMessage = "must be provided";

    public ValidationResult Validate(Vehicle data)
    {
        var validationResult = new ValidationResult();

        if (string.IsNullOrWhiteSpace(data.Id))
        {
            validationResult.AddError(nameof(Vehicle.Id), _mustBeProvidedErrorMessage);
        }

        if (string.IsNullOrWhiteSpace(data.Make))
        {
            validationResult.AddError(nameof(Vehicle.Make), _mustBeProvidedErrorMessage);
        }

        if (string.IsNullOrWhiteSpace(data.Model))
        {
            validationResult.AddError(nameof(Vehicle.Model), _mustBeProvidedErrorMessage);
        }

        if (data.RegistrationDate > DateTime.Now)
        {
            validationResult.AddError(nameof(Vehicle.RegistrationDate), "must not be a future date");
        }

        if (!string.IsNullOrEmpty(data.Description) && data?.Description?.Length > 500)
        {
            validationResult.AddError(nameof(Vehicle.Description), "must not be more than 500 characters");
        }

        if (data.HorsePower < 0 || data.HorsePower > 1000)
        {
            validationResult.AddError(nameof(Vehicle.HorsePower), "must be a number between 0 and 100");
        }

        if (data.Milleage < 0)
        {
            validationResult.AddError(nameof(Vehicle.Milleage), "must be a positive number");
        }

        if (data.IsDamaged is null)
        {
            validationResult.AddError(nameof(Vehicle.IsDamaged), _mustBeProvidedErrorMessage);
        }

        return validationResult;
    }
}
