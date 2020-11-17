using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DOM;

namespace BL
{
    public class UserManager
    {
        public Boolean insertUser(User u) {
            DAOUser dao = new DAOUser();
            return dao.insertUser(u);
        }

        public Boolean updateUser(User u) {
            DAOUser dao = new DAOUser();
            return dao.updateUser(u);
        }

        public Boolean deleteUser(User u) {
            DAOUser dao = new DAOUser();
            return dao.deleteUser(u);
        }

        public User loadUserByUserName(String username) {
            DAOUser dao = new DAOUser();
            return dao.loadUserByUserName(username);
        }

        public bool ValidateUser(string userName, string password)
        {
            DAOUser daoUser = new DAOUser();
            return daoUser.ValidateUser(userName, password);
        }

        public List<User> loadUsers() {
            DAOUser dao = new DAOUser();
            return dao.loadUsers();
        }




    }
}
