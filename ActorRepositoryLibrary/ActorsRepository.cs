﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ActorRepositoryLibrary
{
    public class ActorsRepository
    {
        private List<Actor> actors = new();
        private int nextId = 1;

        public List<Actor> GetActors()
        {
            return new List<Actor>(actors);
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
