using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SE.WebApp.MVC.Extensions
{
    public interface IUser
    {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }

    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _acessor;

        public AspNetUser(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public string Name => throw new NotImplementedException();

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_acessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _acessor.HttpContext.User.GetUserEmail() : "";
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _acessor.HttpContext.User.GetUserToken() : "";
        }

        public bool EstaAutenticado()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _acessor.HttpContext.User.Claims;
        }

        public bool PossuiRole(string role)
        {
            return _acessor.HttpContext.User.IsInRole(role);
        }

        public HttpContext ObterHttpContext()
        {
            return _acessor.HttpContext;
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(message: nameof(principal));
            }

            var claim = principal.FindFirst(type: "sub");
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(message: nameof(principal));
            }

            var claim = principal.FindFirst(type: "email");
            return claim?.Value;
        }

        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(message: nameof(principal));
            }

            var claim = principal.FindFirst(type: "JWT");
            return claim?.Value;
        }
    }
}
