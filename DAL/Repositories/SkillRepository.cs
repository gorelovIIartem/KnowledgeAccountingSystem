using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class SkillRepository : IRepository<Skill, int>
    {
        private KnowledgeAccountingSystemDBContext db;

        public SkillRepository(KnowledgeAccountingSystemDBContext context)
        {
            db = context;
        }

        public IEnumerable<Skill> GetAll()
        {
            return db.Skills;
        }
        public Skill Get(int id)
        {
            return db.Skills.Find(id);
        }
        public void Update(Skill skill)
        {
            var LE = db.Skills.Local.FirstOrDefault(x => x.Id == skill.Id);
            if (LE != null)
            {
                db.Entry(LE).State = EntityState.Detached;
            }
            db.Entry(skill).State = EntityState.Modified;
        }
        public void Insert(Skill skill)
        {
            db.Skills.Add(skill);
        }
        public void Delete(int id)
        {
            Skill skill = db.Skills.Find(id);
            if (skill != null)
                db.Skills.Remove(skill);
        }
    }
}
