using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

namespace AuthenticationInActions.src
{
    // There is an authentication system that works with authentication tokens.
    // For each session, the user will receive a new authentication token
    // that will expire timeToLive seconds after the currentTime.If the
    // token is renewed, the expiry time will be extended to expire
    // timeToLive seconds after the (potentially different) currentTime.
    //
    // Implement the AuthenticationManager class:
    //   AuthenticationManager(int timeToLive) constructs the AuthenticationManager and
    //   sets the timeToLive.
    //   generate(string tokenId, int currentTime) generates a new token with the
    //   given tokenId at the given currentTime in seconds.
    //   renew(string tokenId, int currentTime) renews the unexpired token with the
    //   given tokenId at the given currentTime in seconds.If there are no unexpired
    //   tokens with the given tokenId, the request is ignored, and nothing happens.
    //   countUnexpiredTokens(int currentTime) returns the number of
    //   unexpired tokens at the given currentTime.
    //
    //   Note that if a token expires at time t, and another action happens on
    //   time t(renew or countUnexpiredTokens), the expiration takes place
    //   before the other actions.
    //
    // LeetCode: 1797. Design Authentication Manager
    //
    public class AuthenticationManager
    {
        private readonly Dictionary<string, int> dict = new Dictionary<string, int>();
        private readonly int timeToLive;

        public AuthenticationManager(int timeToLive)
        {
            this.timeToLive = timeToLive;
        }

        public void Generate(string tokenId, int currentTime)
        {
            dict[tokenId] = currentTime + this.timeToLive;
        }

        public void Renew(string tokenId, int currentTime)
        {
            if (dict.TryGetValue(tokenId, out var expireTime) && expireTime > currentTime)
            {
                dict[tokenId] = currentTime + this.timeToLive;
            }
        }

        public int CountUnexpiredTokens(int currentTime)
        {
            int unexpired = dict.Count;

            foreach (var (tokenId, expireTime) in dict)
            {
                if (expireTime <= currentTime)
                {
                    dict.Remove(tokenId);
                    unexpired--;
                }
            }

            return unexpired;
        }
    }
}
