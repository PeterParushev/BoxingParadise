using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Repositories
{
    public class BoxerRepository : IBoxerRepository
    {
        public IList<Boxer> GetBoxers()
        {
            return new DatabaseContext().Boxers.ToList();
        }

        public void Persist(Boxer boxer)
        {
            DatabaseContext context = new DatabaseContext();
            context.Boxers.Add(boxer);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            DatabaseContext context = new DatabaseContext();
            context.Boxers.Remove(context.Boxers.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }
    }
}