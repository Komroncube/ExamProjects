namespace Library.Domain;
public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; private set; }
    public virtual void UpdateEntity()
    {
        UpdatedDate = DateTime.Now;
    }
}
