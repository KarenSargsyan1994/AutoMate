using FluentValidation;
using MediatR;

namespace Automate.Application.Behaviours
{
    public sealed class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators) => _validators=validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(c => c!=null)
                .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertName, errorMessage) => new
                {
                    Key = propertName,
                    Values = errorMessage.Distinct().ToArray()
                })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                // todo  add this Exception. throw new ValidationException(errorsDictionary);
                throw new ValidationException(string.Empty);
            }

            return await next();
        }
    }
}
