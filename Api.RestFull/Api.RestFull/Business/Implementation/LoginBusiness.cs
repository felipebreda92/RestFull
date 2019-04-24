using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Api.RestFull.Model;
using Api.RestFull.Repository;
using Api.RestFull.Security.Configuration;

namespace Api.RestFull.Business.Implementation
{
    public class LoginBusiness : ILoginBusiness
    {
        private IUserRepository _repository;
        private SigninConfigurations _signinConfigurations;
        private TokenConfigurations _tokenConfigurations;

        public LoginBusiness(IUserRepository repository, SigninConfigurations signinConfigurations, TokenConfigurations tokenConfigurations)
        {
            _repository = repository;
            _signinConfigurations = signinConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public object FindByLogin(User user)
        {
            bool credetialsIsValid = false;

            if (user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credetialsIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.AccessKey);

                if (credetialsIsValid)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                            new GenericIdentity(user.Login, "Login"),
                            new[]
                            {
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                            }
                        );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token);
                }
                else
                {
                    return ExceptionObject();
                }
            }
            return null;
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token; 
        }

        private object ExceptionObject()
        {
            return new
            {
                authenticated = false,
                message = "Autentcaçao falhou"

            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
