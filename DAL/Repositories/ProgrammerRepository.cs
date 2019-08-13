using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.EF;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ProgrammerRepository:IRepository<Programmer, string>
    {
        private KnowledgeAccountingSystemDBContext db;

        public ProgrammerRepository(KnowledgeAccountingSystemDBContext context)
        {
            db = context;
        }

        public void Delete(string id)
        {
            Programmer programmer = db.Programmers.Find(id);
            if (programmer != null)
                db.Programmers.Remove(programmer);
        }
        public void Update(Programmer programmer)
        {
            var LE = db.Programmers.Local.FirstOrDefault(x => x.Id == programmer.Id);
            if(LE !=null)
            {
                db.Entry(LE).State = EntityState.Detached;
            }
            db.Entry(programmer).State = EntityState.Modified;

        }
        public Programmer Get(string id)
        {
            return db.Programmers.Find(id);
        }
        public IEnumerable<Programmer> GetAll()
        {
            return db.Programmers;
        }
        public void Insert(Programmer programmer)
        {
            db.Programmers.Add(programmer);
        }
    }
}
