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
    public class ProjectRepository:IRepository<Project, int>
    {
        private KnowledgeAccountingSystemDBContext db;

        public ProjectRepository(KnowledgeAccountingSystemDBContext context)
        {
            db = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }
        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }
        public void Delete(int id)
        {
            Project project = db.Projects.Find(id);
            if (project != null)
                db.Projects.Remove(project);
        }
        public void Insert(Project project)
        {
            db.Projects.Add(project);
        }
        public void Update(Project project)
        {
            var LE = db.Projects.Local.FirstOrDefault(x => x.Id == project.Id);
            if (LE != null)
                db.Entry(LE).State = EntityState.Detached;
            db.Entry(project).State = EntityState.Modified;
        }

    }
}
