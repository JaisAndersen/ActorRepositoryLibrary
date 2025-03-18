using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ActorRepositoryLibrary
{
    public class ActorsRepositoryList : IActorsRepository
    {
        private List<Actor> actors = new();
        private int nextId = 1;

        public IEnumerable<Actor> GetActors(int? birthYearBefore = null, int? birthYearAfter = null, string? nameIncludes = null, string? sortBy = null)
        {
            IEnumerable<Actor> result = new List<Actor>(actors);
            if (birthYearBefore != null)
            {
                result = result.Where(a => a.BirthYear < birthYearBefore);
            }
            if (birthYearAfter != null)
            {
                result = result.Where(a => a.BirthYear > birthYearAfter);
            }
            if (nameIncludes != null)
            {
                result = result.Where(m => m.Name.Contains(nameIncludes, StringComparison.OrdinalIgnoreCase));
            }

            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "name":
                    case "name_asc":
                        result = result.OrderBy(m => m.Name);
                        break;
                    case "name_desc":
                        result = result.OrderByDescending(m => m.Name);
                        break;
                    case "birthYear":
                    case "birthYear_asc":
                        result = result.OrderBy(m => m.BirthYear);
                        break;
                    case "birthYear_desc":
                        result = result.OrderByDescending(m => m.BirthYear);
                        break;
                    default:
                        break;
                }
            }
            return result;

        }
        public Actor Add(Actor actor)
        {
            if (actor == null)
                throw new ArgumentNullException("actor must not be null");

            actor.Id = nextId++;
            actors.Add(actor);
            return actor;
        }
        public Actor? GetActorById(int id)
        {
            return actors.Find(actors => actors.Id == id);
        }
        public Actor Delete(int id)
        {
            Actor? actor = GetActorById(id);
            if (actor == null)
            {
                throw new ArgumentNullException("Actor not found, id " + id);
            }
            actors.Remove(actor);
            return actor;
        }
        public Actor Update(int id, Actor newData)
        {
            Actor? actor = GetActorById(id);
            if (actor == null)
            {
                throw new ArgumentNullException("Actor not found, id " + id);
            }
            actor.Name = newData.Name;
            actor.BirthYear = newData.BirthYear;
            return actor;
        }

    }
}
