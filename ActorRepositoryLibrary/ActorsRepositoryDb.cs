using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            IQueryable<Actor> query = context.Actors.ToList().AsQueryable();
            if (birthYearBefore != null)
            {
                query = query.Where(a => a.BirthYear < birthYearBefore);
            }
            if (birthYearAfter != null)
            {
                query = query.Where(a => a.BirthYear > birthYearAfter);
            }
            if (nameIncludes != null)
            {
                query = query.Where(m => m.Name.Contains(nameIncludes));
            }

            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "name":
                    case "name_asc":
                        query = query.OrderBy(m => m.Name);
                        break;
                    case "name_desc":
                        query = query.OrderByDescending(m => m.Name);
                        break;
                    case "birthYear":
                    case "birthYear_asc":
                        query = query.OrderBy(m => m.BirthYear);
                        break;
                    case "birthYear_desc":
                        query = query.OrderByDescending(m => m.BirthYear);
                        break;
                    default:
                        break;
                }
            }
            return query;
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

