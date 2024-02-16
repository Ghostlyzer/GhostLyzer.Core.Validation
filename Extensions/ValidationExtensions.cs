using FluentValidation;

namespace GhostLyzer.Core.Validation.Extensions
{
    /// <summary>
    /// Provides extension methods for validation operations.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates a request and throws an exception if the validation fails.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to validate.</typeparam>
        /// <param name="validator">The validator to use for the validation.</param>
        /// <param name="request">The request to validate.</param>
        /// <exception cref="Exception">Thrown when the validation fails.</exception>
        public static async Task HandleValidationAsync<TRequest>(this IValidator<TRequest> validator, TRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
