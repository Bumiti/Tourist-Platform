using Tourist_Platform.Models;

namespace Tourist_Platform.Services
{
    public class LoginServices : ILoginServices
    {
        private TouristDbContext _context;
        public LoginServices (TouristDbContext context)
        {
            _context = context;
        }
        public AdminLogic checkAdminLogin(string? accNo, string? pinCode)
        {
            AdminLogic admin = _context.AdminLogics.SingleOrDefault(c=>c.AdminUsername.Equals(accNo));
            if (admin != null)
            {
                if (admin.Password.Equals(pinCode))
                {
                    return admin;
                }
                else
                {
                    return null;
                }
            } else
            {
                return null;
            }
        }
        public UserAccount checkUserAccount(string? accNo, string? pinCode)
        {
            UserAccount user = _context.UserAccounts.SingleOrDefault(c => c.Phone.Equals(accNo)||c.NIC.Equals(accNo));
            if (user != null)
            {
                if (user.Password.Equals(pinCode))
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
