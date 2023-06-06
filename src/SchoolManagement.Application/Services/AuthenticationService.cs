﻿
using SchoolManagement.Application.Common.Interfaces.Authentication;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // 1. Validate the user exists

            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with the given email does not exist.");
            }

            // 2. Validate the password is correct
            if (user.Password!=password)
            {
                throw new Exception("Invalid password");
            }
            // 3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate the user doesn't exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with the given email already exist.");
            }

            // 2.Create user (genrate unique ID)& Persist to DB

            var user = new User { FirstName=firstName, LastName=lastName, Email = email, Password = password };

            _userRepository.AddUser(user);

            //3. Create JWT Token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
