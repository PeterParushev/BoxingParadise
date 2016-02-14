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
            return new BoxingParadiseContext().Boxers.ToList();
        }

        public void Persist(Boxer boxer)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            context.Boxers.Add(boxer);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            context.Boxers.Remove(context.Boxers.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }
    }
}