using Tourist_Platform.Models;

namespace Tourist_Platform.Services
{
    public interface ILoginServices
    {
        public AdminLogic checkAdminLogin(string? accNo, string? pinCode);
        public UserAccount checkUserAccount(string? accNo, string? pinCode);
        /*List<AdminLogic> showAll();
        AdminLogic showOne(string? accNo);*/
       /* void createAdmin(AdminLogic newAcc);
        void updateAdmin(AdminLogic editAcc);
        void deleteAdmin(string? accNo);*/
    }
}
