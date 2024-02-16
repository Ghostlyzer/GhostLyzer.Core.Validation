using FluentValidation.Results;
using System.Net;
using System.Text.Json;

namespace GhostLyzer.Core.Validation.Models
{
    /// <summary>
    /// Represents the result of a validation operation.
    /// </summary>
    public class ValidationResultModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultModel"/> class with a specified validation result.
        /// </summary>
        /// <param name="validationResult">The result of the validation operation.</param>
        public ValidationResultModel(ValidationResult validationResult = null)
        {
            Errors = validationResult.Errors
                .Select(error => new ValidationError(error.PropertyName, error.ErrorMessage))
                .ToList();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Gets or sets the status code of the validation result.
        /// </summary>
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;

        /// <summary>
        /// Gets or sets the message of the validation result.
        /// </summary>
        public string Message { get; set; } = "Validation Failed.";

        /// <summary>
        /// Gets the list of validation errors.
        /// </summary>
        public List<ValidationError> Errors { get; }
    }
}
