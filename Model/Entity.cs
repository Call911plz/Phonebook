// Purely using an entity base class in case of fancy virtual/abstract
// functions. If not, probably removing.
public class Entity
{
    public int Id { get; set; }

    public override string? ToString()
    {
        return base.ToString();
    }
}