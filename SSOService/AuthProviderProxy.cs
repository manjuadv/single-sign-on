using IdentityProvider.InMemoryDatabase;
using IdentityProvider.LDAP;
using IdentityProvider.XmlDb;
using IdentityProviderBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SSOService
{
    public static class AuthProviderProxy
    {
        public static AuthenticationFactory GetAuthProvider()
        {
            
            IAuthenticatoinProvider provider;
            if (GetAuthProviderType() == AuthenticationProviderType.IN_MEMORY)
            {
                provider = new InMemoryDbAuthenticationProvider();
            }
            else if (GetAuthProviderType() == AuthenticationProviderType.XmlDb)
            {
                provider = new XmlDbAuthenticationProvider();
            }
            else if (GetAuthProviderType() == AuthenticationProviderType.LDAP)
            {
                provider = new LdapAuthenticationProvider();
            }
            else
            {
                provider = new InMemoryDbAuthenticationProvider();
            }
            return new AuthenticationFactory(provider);
        }
        /// <summary>
        /// This method decide which authentication mechanism (LDAP, Database, etc) based on some logic
        /// </summary>
        /// <returns></returns>
        private static AuthenticationProviderType GetAuthProviderType()
        {

            string authenticationProvider = ConfigurationManager.AppSettings["authenticationProvider"];
            switch (authenticationProvider)
            {
                case "ldap":
                    return AuthenticationProviderType.LDAP;
                case "InMemory":
                    return AuthenticationProviderType.IN_MEMORY;
                case "xmlDb":
                    return AuthenticationProviderType.XmlDb;
                default:
                    return AuthenticationProviderType.IN_MEMORY;
            }            
        }

    }
    
    enum AuthenticationProviderType
    {
        IN_MEMORY,
        LDAP,
        XmlDb
    }
}