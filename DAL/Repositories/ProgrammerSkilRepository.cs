using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Data.Entity;


namespace DAL.Repositories
{
    public class ProgrammerSkilRepository:IProgrammerSkillRepository
    {
        private KnowledgeAccountingSystemDBContext db;
        public ProgrammerSkilRepository(KnowledgeAccountingSystemDBContext context)
        {
            db = context;
        }

        public IEnumerable<ProgrammerSkill> GetAll()
        {
            return db.ProgrammerSkills;
        }
        public ProgrammerSkill Get(string idProgrammer, int idSkill)
        {
            return db.ProgrammerSkills.SingleOrDefault(x => x.ProgrammerId == idProgrammer && x.SkillId == idSkill); 
        }

        public void Delete(string idProgrammer, int idSkill)
        {
            ProgrammerSkill programmerSkill = db.ProgrammerSkills.SingleOrDefault(x => x.ProgrammerId == idProgrammer && x.SkillId == idSkill);
            if (programmerSkill != null)
                db.ProgrammerSkills.Remove(programmerSkill);
        }
        public void Insert(ProgrammerSkill programmerSkill)
        {
            db.ProgrammerSkills.Add(programmerSkill);
        }
        public void Update(ProgrammerSkill programmerSkill)
        {
            var localEntity = db.ProgrammerSkills.Local.FirstOrDefault(x => x.ProgrammerId == programmerSkill.ProgrammerId && x.SkillId == programmerSkill.SkillId);
            if (localEntity != null)
            {
                db.Entry(localEntity).State = EntityState.Detached;
            }
            db.Entry(programmerSkill).State = EntityState.Modified;
        }





    }
}
