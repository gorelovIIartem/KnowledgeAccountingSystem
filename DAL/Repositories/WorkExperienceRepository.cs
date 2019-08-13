using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class WorkExperienceRepository:IRepository<WorkExperience, int>
    {
        private KnowledgeAccountingSystemDBContext db;
        public WorkExperienceRepository(KnowledgeAccountingSystemDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<WorkExperience> GetAll()
        {
            return db.WorkExperiences;
        }
        public WorkExperience Get(int id)
        {
            return db.WorkExperiences.Find(id);
        }
        public void Update(WorkExperience workExperience)
        {
            var LE = db.WorkExperiences.Local.FirstOrDefault(x => x.Id == workExperience.Id);
            if (LE != null)
                db.Entry(LE).State = EntityState.Detached;
            db.Entry(workExperience).State = EntityState.Modified;

        }
        public void Insert(WorkExperience workExperience)
        {
            db.WorkExperiences.Add(workExperience);
        }
        public void Delete(int id)
        {
            WorkExperience workExperience = db.WorkExperiences.Find(id);
            if (workExperience != null)
                db.WorkExperiences.Remove(workExperience);
        }
    }
}
