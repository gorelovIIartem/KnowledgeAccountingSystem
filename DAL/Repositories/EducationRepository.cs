using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Data.Entity;
using DAL.Entities;
using DAL.EF;

namespace DAL.Repositories
{
    public class EducationRepository:IRepository<Education, int>
    {
        private KnowledgeAccountingSystemDBContext db;
        public EducationRepository(KnowledgeAccountingSystemDBContext context)
        {
            db = context;
        }

        public Education Get(int id)
        {
            return db.Educations.Find(id);
        }
        public IEnumerable<Education> GetAll()
        {
            return db.Educations;
        }
        public void Delete(int id)
        {
            Education education = db.Educations.Find(id);
            if(education!=null)
            {
                db.Educations.Remove(education);
            }
        }
        public void Insert(Education education)
        {
            db.Educations.Add(education);
        }
        public void Update(Education education)
        {
            var LE = db.Educations.Local.FirstOrDefault(x => x.Id == education.Id);
            if(LE!=null)
            {
                db.Entry(LE).State = EntityState.Detached;
            }
            db.Entry(education).State = EntityState.Modified;
        }
    }
}
