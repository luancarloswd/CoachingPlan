
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure;

using CoachingPlan.Resources.Messages;
using System;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoachingPlan.Domain.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace CoachingPlan.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        readonly private IUsuarioRepository _repository;
       // readonly private ApplicationUserManager _userManager;
        public UsuarioService(IUsuarioRepository repository)
        {
           // _userManager = userManager;
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

        public Usuario Login(string email, string password, bool remeberme)
        {
           throw new NotImplementedException();
        }

        public void Register(string email, string userName, string password)
        {
            
            _repository.Create(new Usuario());

            //if (!result.Succeeded)
            //{
            //    foreach (string erro in result.Errors )
            //    {
            //        throw new Exception(erro);
            //    }
            //}

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
