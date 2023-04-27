namespace DreamsFashionApp.Menu.Interface
{
    public interface IAdminMenu
    {
         public void AdminMain();
         public void UploadProduct();
          public void ViewAllRiders();
         
          public void ViewAllCustomers();
          public void ViewAllProducts();
          public void DisableCustomer();
          public void DeleteProduct();
          public void DeleteRider();
          public void LogOut();
    }
}