using AIDreamDecoder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Yeni bir kullanıcı oluşturur.
        /// </summary>
        /// <param name="firstName">Kullanıcının adı.</param>
        /// <param name="lastName">Kullanıcının soyadı.</param>
        /// <param name="email">Kullanıcının e-posta adresi.</param>
        /// <param name="password">Kullanıcının şifresi.</param>
        /// <returns>Oluşturulan kullanıcı.</returns>
        Task<User> RegisterUserAsync(string firstName, string lastName, string email, string password);

        /// <summary>
        /// Kullanıcının giriş yapmasını sağlar.
        /// </summary>
        /// <param name="email">Kullanıcının e-posta adresi.</param>
        /// <param name="password">Kullanıcının şifresi.</param>
        /// <returns>Kullanıcı bilgisi.</returns>
        Task<User> AuthenticateUserAsync(string email, string password);

        /// <summary>
        /// Kullanıcının kimlik bilgilerine göre verilerini alır.
        /// </summary>
        /// <param name="userId">Kullanıcının kimliği.</param>
        /// <returns>Kullanıcı bilgisi.</returns>
        Task<User> GetUserByIdAsync(int userId);

        /// <summary>
        /// Kullanıcıyı sistemden siler.
        /// </summary>
        /// <param name="userId">Kullanıcının kimliği.</param>
        Task DeleteUserAsync(int userId);

        //Kullanıcı oluşturma, giriş yapma, bilgileri alma ve silme gibi temel yönetim işlemlerini kapsar.
       //RegisterUserAsync ve AuthenticateUserAsync ile kullanıcı işlemleri güvenli hale getirilir.
    }
}
