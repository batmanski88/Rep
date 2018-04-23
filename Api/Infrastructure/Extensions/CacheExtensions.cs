using System;
using Api.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtViewModel jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtViewModel GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtViewModel>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}