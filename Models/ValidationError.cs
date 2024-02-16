namespace GhostLyzer.Core.Validation.Models
{
    /// <summary>
    /// Represents a validation error in the application.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError"/> class with a specified field and message.
        /// </summary>
        /// <param name="field">The field where the validation error occurred.</param>
        /// <param name="message">The message that describes the validation error.</param>
        public ValidationError(string field, string message)
        {
            Field = field;
            Message = message;

        }

        /// <summary>
        /// Gets the field where the validation error occurred.
        /// </summary>
        public string Field { get; }

        /// <summary>
        /// Gets the message that describes the validation error.
        /// </summary>
        public string Message { get; }
    }
}
