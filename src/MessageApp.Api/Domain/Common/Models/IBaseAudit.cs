namespace MessageApp.Api.Domain.Common.Models
{
    public interface IBaseAudit
    {
        public DateTime CreatedDate { get;set; }
    }
}
