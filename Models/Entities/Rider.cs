namespace DreamsFashionApp.Models.Entities
{
    public class Rider : BaseEntity
    {
        public int UserId;
        public Rider(int id, int userId, bool isDeleted) : base(id, isDeleted)
        {
            Id = id;
            UserId = userId;
            IsDeleted = isDeleted;
        }

        public static Rider ToRider(string portrait)
        {
            var port = portrait.Split("\t");
            int id = int.Parse(port[0]);
            int userId = int.Parse(port[1]);
            bool isDeleted = bool.Parse(port[2]);
            
            return new Rider(id, userId, isDeleted);


        }

         public override string ToString()
        {
            return $"{Id}\t{UserId}\t{IsDeleted}";
        }
    }
}