using App.Business;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerHost.Quickstart.UI
{
    public static class IdentityExtensions
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        {

            builder.AddProfileService<CustomProfileService>();
            builder.Services.AddAppLibrary();

            builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

            return builder;
        }

    }

}
