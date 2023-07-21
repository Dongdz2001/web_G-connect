// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // client credentials flow client                
                new Client
                {
                    ClientId = "VPKHCN",
                    ClientName = "Phần mềm phục vụ quản lý các nhiệm vụ thuộc các chương trình KH&CN",
                    ClientSecrets={ new Secret("Q2jGsMahbmcgdHLDrG5oIGtob2EgaOG7jWMgdsOgIGPDtG5nIG5naOG7hyBxdeG7kWMgZ2lh".Sha256()) },
                    AllowedGrantTypes = {
                        GrantType.ResourceOwnerPassword,
                        GrantType.AuthorizationCode,
                        GrantType.ClientCredentials,
                        GrantType.DeviceFlow
                    },
                    RequirePkce = false,
                    RequireClientSecret = true,
                    AllowOfflineAccess=true,
                    RefreshTokenUsage=TokenUsage.OneTimeOnly,
                    UpdateAccessTokenClaimsOnRefresh=true,
                    RedirectUris =
                    {
                        "http://localhost:3000/oauth-callback",
                    },

                    PostLogoutRedirectUris = { "http://localhost:3000/logout" },
                    AllowedCorsOrigins = { "http://localhost:3000" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api"}
                }
            };
    }
}
