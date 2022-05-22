namespace MyWebShop.Domain.Base;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreateDate { get; set; }
    DateTime UpdateDate { get; set; }
    DateTime? DeleteDate { get; set; }
    bool IsDeleted { get; set; }
}