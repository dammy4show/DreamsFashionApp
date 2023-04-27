namespace DreamsFashionApp.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id;
        public bool IsDeleted;

        protected BaseEntity(int id, bool isDeleted)
        {
            Id = id;
            IsDeleted = isDeleted;
        }
    }
}