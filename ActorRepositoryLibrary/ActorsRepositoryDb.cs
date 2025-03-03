using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLibrary
{
    public class ActorsRepositoryDb : IActorsRepository
    {
        private readonly ActorsDbContext context;

        public ActorsRepositoryDb(ActorsDbContext dbContext)
        {
            context = dbContext;
        }
        public Actor Add(Actor actor)
        {
            context.Actors.Add(actor);
            context.SaveChanges();
            return actor;
        }

        public Actor Delete(int id)
        {
            Actor? actor = GetActorById(id);
            if (actor is null)
            {
                return null;
            }
            context.Actors.Remove(actor);
            context.SaveChanges();
            return actor;
        }

        public Actor? GetActorById(int id)
        {
            return context.Actors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Actor> GetActors(int? birthYearBefore = null, int? birthYearAfter = null, string? nameIncludes = null, string? sortBy = null)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor newData)
        {
            Actor? actorToUpdate = GetActorById(id);
            if (actorToUpdate == null) return null;
            actorToUpdate.Name = newData.Name;
            actorToUpdate.BirthYear = newData.BirthYear;
            context.SaveChanges();
            return actorToUpdate;
        }
    }
}

