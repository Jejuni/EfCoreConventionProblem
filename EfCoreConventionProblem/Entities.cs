namespace EfCoreConventionProblem;

public class MainEntity
{
    public Guid Id { get; set; }
    public OwnedEntity OwnedEntity { get; set; }
}

public class OtherEntity
{
    public Guid Id { get; set; }

    public SecondLevelOwnedEntity SecondLevelOwnedEntity { get; set; }
}

public class OwnedEntity
{
    public List<SecondLevelOwnedEntity> SecondLevelOwnedEntities { get; set; }
}

public class SecondLevelOwnedEntity
{
    public decimal Number { get; set; }
}