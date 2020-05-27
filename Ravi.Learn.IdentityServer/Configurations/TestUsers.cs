// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ravi.Learn.IdentityServer.Configurations
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{SubjectId = "ae24c6f7-44af-4079-b1c5-f8b6caaa3a30", Username = "alice", Password = "alice",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim(JwtClaimTypes.Role, "FreeUser"),
                    new Claim("country","Germany"),
                    new Claim("subscription", "FreeUser")
                }
            },
            new TestUser{SubjectId = "b4150c1f-8ba0-4aa7-9f8f-ffb3fbd92367", Username = "bob", Password = "bob",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Two Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Belgium' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "anywhere"),
                    new Claim(JwtClaimTypes.Role, "PaidUser"),
                    new Claim("country","Belgium"),
                    new Claim("subscription", "PaidUser")
                }
            },
            new TestUser{SubjectId = "b9d6ba2b-f15a-4e04-9bb0-7104d189f69c", Username = "Frank", Password = "password",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Frank Underwood"),
                    new Claim(JwtClaimTypes.GivenName, "Frank"),
                    new Claim(JwtClaimTypes.FamilyName, "Underwood"),
                    new Claim(JwtClaimTypes.Email, "funderwood@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://frankunderwood.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': '123 Main Street', 'locality': 'Aldie', 'postal_code': 20101, 'country': 'USA' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim(JwtClaimTypes.Role,"FreeUser"),
                    new Claim("country","USA"),
                    new Claim("subscription", "FreeUser")
                }
            },
            new TestUser{SubjectId = "9e5c49d9-ebb7-461c-9f9e-7785db816302", Username = "Claire", Password = "password",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Claire Underwood"),
                    new Claim(JwtClaimTypes.GivenName, "Claire"),
                    new Claim(JwtClaimTypes.FamilyName, "Underwood"),
                    new Claim(JwtClaimTypes.Email, "cunderwoord@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://claireunderwood.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': '234 South street', 'locality': 'Fairfax', 'postal_code': 20011, 'country': 'USA' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "nowhere"),
                    new Claim(JwtClaimTypes.Role, "PaidUser"),
                    new Claim("country","USA"),
                    new Claim("subscription", "PaidUser")
                }
            }
        };
    }
}