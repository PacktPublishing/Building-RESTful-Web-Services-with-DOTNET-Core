using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace DemoECommerceApp.Security.OAuth
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(
                    "FlixOneStore.ReadAccess",
                    "FlixOneStore API", 
                    new List<string> {
                        JwtClaimTypes.Id,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.GivenName,
                        JwtClaimTypes.FamilyName
                    }
                ),

                new ApiResource("FlixOneStore.FullAccess", "FlixOneStore API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "HTML Page Client",
                    ClientId = "htmlClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secretpassword".Sha256())
                    },

                    AllowedScopes = { "FlixOneStore.ReadAccess" }
                }
            };
        }

        // This method can be used to test the api quickly without database.
        //public static List<TestUser> GetUsers()
        //{
        //    return new List<TestUser>
        //    {
        //        new TestUser
        //        {
        //            Username = "bob",
        //            Password = "secret",
        //            SubjectId = "1",

        //            Claims = new[]
        //            {
        //                new Claim(ClaimTypes.GivenName, "Bob")
        //            }
        //        }
        //    };
        //}
    }
}
