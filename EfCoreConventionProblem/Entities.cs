namespace EfCoreConventionProblem;

public class MainEntity
{
    public Guid Id { get; set; }
    public OwnedEntity OwnedEntity { get; set; }
}

public class OtherEntity
{
    public Guid Id { get; set; }

    public List<OwnedEntity> OwnedEntities { get; set; }
}

public class OwnedEntity
{
    public decimal Number { get; set; }
}
