namespace DreamsFashionApp.Models.Entities
{
    public class Admin : BaseEntity
    {
        public int UserId;
        public Admin(int id, int userId,  bool isDeleted) : base(id, isDeleted)
        {
            Id = id;
            UserId = userId;
            IsDeleted = isDeleted;
        }
        public  static Admin ToAdmin(string portrait)
        {
            var port = portrait.Split("\t");
            int id = int.Parse(port[0]);
            int userId = int.Parse(port[1]);
            bool isDeleted = bool.Parse(port[2]);
            
            return new Admin(id, userId, isDeleted);


        }

         public override string ToString()
        {
            return $"{Id}\t{UserId}\t{IsDeleted}";
        }
    }
}