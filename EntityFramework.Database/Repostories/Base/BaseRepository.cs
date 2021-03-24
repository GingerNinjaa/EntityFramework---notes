using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Database.Repostories.Base
{
    //klasa abstrakcyjna która przyjmuje Entity jako tabele z bazydanych
    public abstract class BaseRepository<Entity> where Entity : class
    {
        //zmienna przechowująca bazedanych
        protected EntityFrameworkDbContext _dbContext;

        //referencja do tabelki 
        protected abstract DbSet<Entity> DbSet { get;  }

        //konstruktor który wymusza wrzucenie dbContext jako parametr
        public BaseRepository(EntityFrameworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
