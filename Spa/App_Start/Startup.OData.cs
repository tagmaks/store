using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using Spa.Dtos;
using Spa.Entities;
using Spa.Infrastructure;

namespace Spa
{
    public partial class Startup
    {
        private void ConfigureOData(HttpConfiguration httpConfig)
        {
            httpConfig.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "OData",
                model: GenerateEdmModel()
                );

            httpConfig.AddODataQueryFilter();
        }

        private IEdmModel GenerateEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<CustomUserClaim>("Claims");
            builder.EntitySet<User>("Users");
            builder.EntitySet<UserDto>("UsersDto");
            builder.EntitySet<CustomerGroup>("CustomerGroups");
            builder.EntitySet<OfferList>("OfferLists");
            builder.EntitySet<Offer>("Offers");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<Ratio>("Ratios");

            return builder.GetEdmModel();
        }
    }
}