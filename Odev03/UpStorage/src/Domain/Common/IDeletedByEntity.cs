

namespace Domain.Common
{
    public interface IDeletedByEntity
    {
         DateTimeOffset? ModifiedOn { get; set; }
        public string DeletedByUserId { get; set; }
        bool IsDeleted { get; set; }
    }
}
