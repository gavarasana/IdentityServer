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
            new TestUser{SubjectId = "AE24C6F7-44AF-4079-B1C5-F8B6CAAA3A30", Username = "alice", Password = "alice", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "B4150C1F-8BA0-4AA7-9F8F-FFB3FBD92367", Username = "bob", Password = "bob", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Two Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "anywhere")
                }
            },
            new TestUser{SubjectId = "B9D6BA2B-F15A-4E04-9BB0-7104D189F69C", Username = "Frank", Password = "password",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Frank Underwood"),
                    new Claim(JwtClaimTypes.GivenName, "Frank"),
                    new Claim(JwtClaimTypes.FamilyName, "Underwood"),
                    new Claim(JwtClaimTypes.Email, "funderwood@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://frankunderwood.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': '123 Main Street', 'locality': 'Aldie', 'postal_code': 20101, 'country': 'USA' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "9E5C49D9-EBB7-461C-9F9E-7785DB816302", Username = "Claire", Password = "password",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Claire Underwood"),
                    new Claim(JwtClaimTypes.GivenName, "Claire"),
                    new Claim(JwtClaimTypes.FamilyName, "Underwood"),
                    new Claim(JwtClaimTypes.Email, "cunderwoord@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://claireunderwood.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': '234 South street', 'locality': 'Fairfax', 'postal_code': 20011, 'country': 'USA' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "nowhere")
                }
            }
        };
    }
}