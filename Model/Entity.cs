// Purely using an entity base class in case of fancy virtual/abstract
// functions. If not, probably removing.
class Entity (int id)
{
    public int Id => id;
}