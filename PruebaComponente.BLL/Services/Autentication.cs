using PruebaComponente.BLL.DTO;
using PruebaComponente.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponente.BLL.Services
{
    public class Autentication
    {
        public static LoginDTO Login(string userName)
        {
            try
            {
                LoginDTO loginDTO = new LoginDTO();

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    loginDTO = (from u in db.UsuarioApi
                                where u.UserName == userName
                                select new LoginDTO
                                {
                                    UserName = u.UserName,
                                    Password = u.Password
                                }).FirstOrDefault();
                }

                return loginDTO;
            }
            catch (Exception ex)
             {
                return null;
            }
        }
    }
}
