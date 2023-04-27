namespace DreamsFashionApp.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name;
        
        public string Password;
        public string PhoneNumber;
        public string Email;
        public string Address;
        
        public decimal Wallet;
        public string Role;
        public User(int id,string name, string password, string phoneNumber, string email, string address,decimal wallet, string role,bool isDeleted) : base(id,isDeleted)
        {
            Id = id;
            Name = name;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Wallet = wallet;
            Role = role;
            IsDeleted = isDeleted;
            
        }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Password}\t{PhoneNumber}\t{Email}\t{Address}\t{Wallet}\t{Role}\t{IsDeleted}";
        }

        public static User ToUser(string model)
        {
            var asd = model.Split('\t');
            int id = int.Parse(asd[0]);
            string name = asd[1];
            string password = asd[2];
            string phoneNumber = asd[3];
            string email = asd[4];
            string address = asd[5];
            decimal wallet = decimal.Parse(asd[6]);
            string role = asd[7];
            bool isDeleted = bool.Parse(asd[8]);

           return new User(id, name, password, phoneNumber, email, address, wallet, role, isDeleted);
        }
    }
}