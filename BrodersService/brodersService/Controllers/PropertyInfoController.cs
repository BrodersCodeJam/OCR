using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using brodersService.DataObjects;
using brodersService.Models;

namespace brodersService.Controllers
{
    public class PropertyInfoController : TableController<PropertyInfo>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            brodersContext context = new brodersContext();
            DomainManager = new EntityDomainManager<PropertyInfo>(context, Request, Services);
        }

        // GET tables/PropertyInfo
        public IQueryable<PropertyInfo> GetAllPropertyInfo()
        {
            return Query(); 
        }

        // GET tables/PropertyInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PropertyInfo> GetPropertyInfo(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PropertyInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PropertyInfo> PatchPropertyInfo(string id, Delta<PropertyInfo> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PropertyInfo
        public async Task<IHttpActionResult> PostPropertyInfo(PropertyInfo item)
        {
            PropertyInfo current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PropertyInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePropertyInfo(string id)
        {
             return DeleteAsync(id);
        }

    }
}