
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure;
using CoachingPlan.Infraestructure.Identity;
using CoachingPlan.Resources.Messages;
using System;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoachingPlan.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        readonly private IUsuarioRepository _repository;
        readonly private ApplicationSignInManager _signInManager;
        readonly private ApplicationUserManager _userManager;
        public UsuarioService(IUsuarioRepository repository, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = _userManager ?? userManager;
            _signInManager = _signInManager ?? signInManager;
            _repository = repository;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Usuario GetByEmail(string email)
        {
            Usuario user = _repository.GetOneByEmail(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }
        public bool ConfirmEmail(string userId, string code)
        {
            throw new NotImplementedException();
        }

        public bool ExternalLogin(string provider, string returnUrl)
        {
            throw new NotImplementedException();
        }

        public bool ExternalLoginCallback(string returnUrl)
        {
            throw new NotImplementedException();
        }

        public bool ExternalLoginConfirmation(string email, Guid id)
        {
            throw new NotImplementedException();
        }

        public string ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuario> GetAll()
        {
            return _repository.GetAll();
        }

        public Usuario GetOne(string id)
        {
            return _repository.GetOne(id);
        }

        public void LogOff()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Login(string email, string password, bool remeberme)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, remeberme, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    var usuario = GetByEmail(email);
                    return usuario;
                case SignInStatus.LockedOut:
                    throw new Exception(Errors.LockedOut);
                case SignInStatus.RequiresVerification:
                    throw new Exception(Errors.RequiresVerification);
                case SignInStatus.Failure:
                    throw new Exception(Errors.Failure);
                default:
                    throw new Exception(Errors.Failure);
            }
        }

        public void Register(string email, string userName, string password)
        {

            Usuario user = new Usuario();
            user.Email = "luancarloshs@gmail.com";
            user.EmailConfirmed = false;
            user.PasswordHash = "AFPHuiThUBqwGJbE8do6y+plFs7i7k0fWMx+uupaC12/+zJ242roQYqnGC45Tl4J1A==";
            user.SecurityStamp = "909a8cfe-bd6b-40e0-a588-cefe4b607be4";
            user.PhoneNumberConfirmed = false;
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string email, string code, string password, string confirmPassword)
        {
            throw new NotImplementedException();
        }

        public bool SendCode(string returnUrl, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        public bool VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            throw new NotImplementedException();
        }
    }
}
