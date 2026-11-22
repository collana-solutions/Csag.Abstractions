namespace Csag.Abstractions.Tests
{
    using Csag.Abstractions.Security;
    using Csag.Abstractions.Tests.Implementations.Security;
    using Microsoft.Extensions.DependencyInjection;
    using Neolution.Extensions.DependencyInjection.Abstractions;

    /// <inheritdoc />
    public class CompositionRoot : BootstrappedCompositionRoot
    {
        /// <inheritdoc />
        public override void Configure(IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        }
    }
}
