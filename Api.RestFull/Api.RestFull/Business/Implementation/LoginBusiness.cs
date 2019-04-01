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

            if (user != null && string.IsNullOrWhiteSpace(user.Login))
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
                                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString(user.Login)),
                            }
                        );

                    return SuccessObject(createDate, expirationDate, token);
                }
                else
                {
                    return ExceptionObject();
                }


            }
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
