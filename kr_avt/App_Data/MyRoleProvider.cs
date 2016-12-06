using kr_avt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


    public class MyRoleProvider : RoleProvider
    {

        public static bool Role(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя 
            using (BDEntities _db = new BDEntities())
            {
                // Получаем пользователя 
                User user = (from u in _db.User
                                 where u.Login == username
                                 select u).FirstOrDefault();
                if (user != null)
                {
                    // получаем роль 
                    var role = _db.Role.Find(user.IDRole);

                    //сравниваем 
                    if (role.NameRole.Equals(roleName))
                    {
                        outputResult = true;
                    }
                }
            }
            return outputResult; 
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя 
            using (BDEntities _db = new BDEntities())
            {
                // Получаем пользователя 
                User user = (from u in _db.User
                                 where u.Login == username
                                 select u).FirstOrDefault();
                if (user != null)
                {
                    // получаем роль 
                    var role = user.Role;

                    //сравниваем 
                    if (role != null && role.NameRole == roleName)
                    {
                        outputResult = true;
                    }
                }
            }
            return outputResult; 
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
