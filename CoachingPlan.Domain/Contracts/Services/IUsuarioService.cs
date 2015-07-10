using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IUsuarioService : IDisposable
    {
        Usuario GetOne(string id);
        Usuario GetByEmail(string email);
        void Remove(string id);
        ICollection<Usuario> GetAll();
        void Register(string email, string userName, string password);
        Usuario Login(string email, string password, bool remeberme);
        bool VerifyCode(string provider, string returnUrl, bool rememberMe);
        bool ConfirmEmail(string userId, string code);
        string ForgotPassword(string email);
        string ResetPassword(string email, string code, string password, string confirmPassword);
        bool ExternalLogin(string provider, string returnUrl);
        bool SendCode(string returnUrl, bool rememberMe);
        bool ExternalLoginCallback(string returnUrl);
        bool ExternalLoginConfirmation(string email, Guid id);
        void LogOff();

    }
}
