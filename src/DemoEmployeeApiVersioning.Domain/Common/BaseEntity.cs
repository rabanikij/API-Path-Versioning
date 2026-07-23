namespace DemoEmployeeApiVersioning.Domain.Common;


public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public DateTime CreatedDate { get; protected set; }

    public DateTime? ModifiedDate { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();

        CreatedDate = DateTime.UtcNow;
    }

    public void UpdateModifiedDate()
    {
        ModifiedDate = DateTime.UtcNow;
    }
}