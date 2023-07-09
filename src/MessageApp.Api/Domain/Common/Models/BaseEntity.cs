namespace MessageApp.Api.Domain.Common.Models
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; protected set; }
    }
}
