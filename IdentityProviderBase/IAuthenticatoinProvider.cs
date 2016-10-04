using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderBase
{
    /// <summary>
    /// IAuthenticatoinProvider defines the main functionality needed to implement an identity data provider
    /// </summary>
    public interface IAuthenticatoinProvider
    {
        /// <summary>
        /// Issues the token for which is used to identify the if the user is logged in. This token is added as an ecnrypted cookie.
        /// </summary>
        /// <param name="user">User being logged in</param>
        /// <returns>Generated token</returns>
        string IssueAuthenticationToken(User user);
        /// <summary>
        /// Get the user by giving unique identity useed by underline login mechanism.
        /// </summary>
        /// <param name="identity">Unique identity</param>
        /// <returns></returns>
        User GetUserByIdentity(string identity);
        /// <summary>
        /// Get the groups that given user belongs into.
        /// </summary>
        /// <param name="identity">Identity of the user</param>
        /// <returns>User's groups</returns>
        IList<UserGroup> GetUserGroups(string identity);
        /// <summary>
        /// Authenticate the user.
        /// </summary>
        /// <param name="identity">Unique identity</param>
        /// <param name="password">Password</param>
        /// <returns>If user is valid</returns>
        bool ValidateUser(string identity, string password);
        /// <summary>
        /// Find users by giving a query.
        /// </summary>
        /// <param name="keyword">Searching keyword</param>
        /// <returns>Matching users</returns>
        IList<User> Search(string keyword);
        /// <summary>
        /// Update the centerlized login system as user has been logged in.
        /// </summary>
        /// <param name="user">Login User</param>
        /// <param name="token">Authentication token</param>
        void RecordUserLogin(User user,string token);
        void LogSignInEvent(User user);
        void LogResourceAccess(User user,string resourceUri);
        /// <summary>
        /// Get the authenticated user by giving authentication token.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Login User. Returns null if user is not logged in.</returns>
        User GetAuthenticatedUserByToken(string token);
        /// <summary>
        /// Remove user session from centerlized login system. This functionality is used to log out the user.
        /// </summary>
        /// <param name="token"></param>
        void KillLoginSession(string token);
    }
}
