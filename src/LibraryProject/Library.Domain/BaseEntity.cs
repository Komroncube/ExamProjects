namespace Library.Domain;
public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; protected set; }
    public virtual void UpdateEntity()
    {
        UpdatedDate = DateTime.Now;
    }

}
