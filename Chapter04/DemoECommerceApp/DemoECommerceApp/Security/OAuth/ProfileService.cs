using DemoECommerceApp.Models;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DemoECommerceApp.Security.OAuth
{
    public class ProfileService : IProfileService
    {
        private readonly FlixOneStoreContext _context;

        public ProfileService(FlixOneStoreContext context)
        {
            _context = context;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext profileContext)
        {
            try
            {
                if (!string.IsNullOrEmpty(profileContext.Subject.Identity.Name))
                {
                    var customer = await _context.Customers
                        .SingleOrDefaultAsync(m => m.Email == profileContext.Subject.Identity.Name);

                    if (customer != null)
                    {
                        var claims = ResourceOwnerPasswordValidator.GetUserClaims(customer);

                        profileContext.IssuedClaims = claims.Where(
                            x => profileContext.RequestedClaimTypes.Contains(x.Type)).ToList();
                    }
                }
                else
                {
                    var customerId = profileContext.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

                    if (!string.IsNullOrEmpty(customerId.Value))
                    {
                        var customer = await _context.Customers
                            .SingleOrDefaultAsync(u => u.Id == Guid.Parse(customerId.Value));
                        
                        if (customer != null)
                        {
                            var claims = ResourceOwnerPasswordValidator.GetUserClaims(customer);

                            profileContext.IssuedClaims = claims.Where(x => profileContext.RequestedClaimTypes.Contains(x.Type)).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                var customerId = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Id);

                if (!string.IsNullOrEmpty(customerId.Value))
                {
                    var customer = await _context.Customers.SingleOrDefaultAsync
                        (m => m.Id == Guid.Parse(customerId.Value));

                    // One IsActive field may be there on DB. You can use that value here.
                    // I hard coded true.
                    context.IsActive = customer != null;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}