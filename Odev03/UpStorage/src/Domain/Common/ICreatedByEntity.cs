namespace Domain.Common
{
    public interface ICreatedByEntity
    {
        DateTimeOffset CreatedOn { get; set; }
      public string? CreatedByUserId { get; set; }
    }
}
