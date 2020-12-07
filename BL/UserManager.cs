using System;
using System.Collections.Generic;
using System.Data;
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

        public int verifyUser(String userName) {
            DAOUser dao = new DAOUser();
            return dao.verifyUser(userName);
        }

        public DataTable loadUsersNames() {
            DAOUser dao = new DAOUser();
            return dao.loadUsersName();
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

        public void UserModifyInvoiceClient(string userName, Int64 invoiceNumber)
        {
            DAOUser dao = new DAOUser();
            dao.UserModifyInvoiceClient(userName, invoiceNumber);

        }

        public void UserModifyInvoiceSupplier(string userName, string invoiceNumber)
        {
            DAOUser dao = new DAOUser();
            dao.UserModifyInvoiceSupplier(userName, invoiceNumber);

        }


    }
}
