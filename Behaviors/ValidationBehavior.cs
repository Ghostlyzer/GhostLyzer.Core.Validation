using FluentValidation;
using GhostLyzer.Core.Validation.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GhostLyzer.Core.Validation.Behaviors
{
    /// <summary>
    /// Represents a behavior that validates requests in the application pipeline.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request to validate.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private IValidator<TRequest> _validator;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class with a specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider used to get services.</param>
        public ValidationBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Handles a request in the application pipeline.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <param name="next">The next handler in the pipeline.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>The response from the next handler in the pipeline.</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _validator = _serviceProvider.GetService<IValidator<TRequest>>();
            if (_validator is null)
            {
                return await next();
            }

            await _validator.HandleValidationAsync(request);

            return await next();
        }
    }
}
