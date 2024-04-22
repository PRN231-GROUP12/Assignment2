using FluentValidation.Results;

namespace PRN231_Group12.Assignment2.Service.Common.Exceptions;

public class RequestValidationException : Exception
{
    public List<ValidationFailure>? Errors { get; init; }

    public RequestValidationException(List<ValidationFailure>? errors) : base("User input validation failed!")
    {
        Errors = errors;
    }
}