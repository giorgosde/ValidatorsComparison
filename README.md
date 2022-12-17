## ValidatorsComparison
This is a quick comparison between custom implementation for validation and
`FluentValidation`. Both practices are considered as alternatives to model validation
([validation attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0))

#### Brief
We apply the same validation rules to a `Vehicle` model. We confirm through unit tests that
both approaches return the same results. *Note: The project contains no endpoints.*

#### Outcome
`FluentValidation` brings a bunch of benefits including cleaner codebase, readability,
consistency and also speeds up the development.

#### Stack:
- .NET 6
- FluentValidation
- XUnit
- FluentAssertions
