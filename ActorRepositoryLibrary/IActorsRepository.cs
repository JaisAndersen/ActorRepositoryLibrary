
namespace ActorRepositoryLibrary
{
    public interface IActorsRepository
    {
        Actor Add(Actor actor);
        Actor Delete(int id);
        Actor? GetActorById(int id);
        IEnumerable<Actor> GetActors(int? birthYearBefore = null, int? birthYearAfter = null, string? nameIncludes = null, string? sortBy = null);
        Actor Update(int id, Actor newData);
    }
}