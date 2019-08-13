using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using DAL.Entities;
namespace DAL.EF
{
    public class KnowledgeAccountingSystemDBInitializer:DropCreateDatabaseIfModelChanges<KnowledgeAccountingSystemDBContext>
    {
        protected override void Seed(KnowledgeAccountingSystemDBContext context)
        {
            #region AddRoles
            List<string> roles = new List<string> { "user", "administrator" };
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(context);
            var roleManager = new RoleManager<ApplicationRole>(roleStore);
            foreach(string roleName in roles)
            {
                var role = new ApplicationRole { Name = roleName };
                roleManager.Create(role);
            }
            #endregion

            #region CreateRoles
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser administrator = new ApplicationUser { UserName = "gorelovIIartem", Email = "gorelov.artemiu@gmail.com", Id = "123" };
            userManager.Create(administrator, "123456");
            userManager.AddToRole(administrator.Id, "administrator");

            ApplicationUser user = new ApplicationUser { UserName = "rte34", Email = "rte34@gmail.com",Id = "1" };
            userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, "user");

            user = new ApplicationUser { UserName = "rte35", Email = "rte35@gmail.com", Id = "2" };
            userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, "user");

            user = new ApplicationUser { UserName = "rte36", Email = "rte36@gmail.com", Id = "3" };
            userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, "user");

            user = new ApplicationUser { UserName = "rte37", Email = "rte37@gmail.com", Id = "4" };
            userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, "user");

            user = new ApplicationUser { UserName = "rte38", Email = "rte38@gmail.com", Id = "5" };
            userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, "user");


            #endregion

            #region Create Programmer
            List<Programmer> programmers = new List<Programmer>
            {
                new Programmer{Id = "1", FullName = "Ivanov Bogdan", Age = 20, WorkEmail = "ivanov@gmail.com", PhoneNumber = "0632011055", Address = "Kyiv, Akademika Yangelya str, 5" },
                new Programmer{Id = "2", FullName = "Strilec Yura", Age = 22, WorkEmail = "strilec@gmail.com", PhoneNumber = "0734563232", Address = "Kyiv, Akademika Yangelya str, 6" },
                new Programmer{Id = "3", FullName = "Ivanov Petro", Age = 22, WorkEmail = "Petynya@gmail.com", PhoneNumber = "0936748672", Address = "Kyiv, Akademika Yangelya str, 1" }
            };
            foreach (Programmer programmer in programmers)
                context.Programmers.Add(programmer);
            #endregion

            #region Create project
            List<Project> projects = new List<Project>
            {
                new Project{ Name = "EFAPP", StartDate = new DateTime(2019,7,20),DeadLine = new DateTime(2019, 8,20),Reference="https://EFAPP.com/", Description = "Create application using EF", Status = "In procces", ProgrammerId="1"},
                 new Project
                {
                    Name = "TelegramX", StartDate= new DateTime(2019,6,18), DeadLine= new DateTime(2019,10,1), FinishDate=new DateTime(2109,9,28), Reference = "https://telegram.org/", Description="I designed the personal file panel for the mobile version of the application.", ProgrammerId = "2", Status="Complete"
                },
                new Project
                {
                    Name = "Smart House", StartDate = new DateTime(2109,3,12),DeadLine=new DateTime(2019,5,23), Reference = "http://www.smarthouse.ua/ru/", Description="Developed an automatic alarm system.", ProgrammerId = "2",Status = "In procces"
                },
                new Project
                {
                    Name = "Help Desk Operations", StartDate = new DateTime(2018,4,16), DeadLine= new DateTime(2019,5,16), FinishDate = new DateTime(2019,4,12), Reference = "https://telegram.org/", Description="Developed project architecture.", ProgrammerId = "2",Status = "Complete"
                },
                new Project
                {
                    Name = "Doctor Antivirus", StartDate = new DateTime(2018,7,16),DeadLine=new DateTime(2019,8,16), FinishDate = new DateTime(2019,5,13), Reference = "https://www.drweb.ru/", Description="Set up a payment system.", ProgrammerId = "2", Status="Complete"
                }
               
            };
            foreach (Project project in projects)
                context.Projects.Add(project);
            #endregion

            #region Create WorkExperience
            List<WorkExperience> workExperiences = new List<WorkExperience>
            {
                new WorkExperience{Company = "EPAM",Position = ".Net developer", EntryDate=new DateTime(2018,1,23), CloseDate = new DateTime(2019,1,23), ProgrammerId = "1"},
                new WorkExperience{Company = "Microsoft", Position = ".Net developer", EntryDate = new DateTime(2018,4,2), CloseDate = new DateTime(2019,4,2), ProgrammerId ="2" }
            };
            foreach (WorkExperience workExperience in workExperiences)
                context.WorkExperiences.Add(workExperience);
            #endregion

            #region Create education
            List<Education> educations = new List<Education>
            {
                new Education{Name = "KPI",EntryDate = new DateTime(2016,9,1), ProgrammerId ="1" },
                new Education{Name = "NAY",EntryDate = new DateTime(2015,9,1), CloseDate = new DateTime(2019,5,31), ProgrammerId = "2"},
                new Education{Name = "Ykraina",EntryDate = new DateTime(2016,9,1), CloseDate = new DateTime(2020,5,31), ProgrammerId = "3"},
              //  new Education{Name = "Agrarka",EntryDate = new DateTime(2015,9,1), CloseDate = new DateTime(2019,5,31), ProgrammerId = "4"},
               // new Education{Name = "KNTY",EntryDate = new DateTime(2015,9,1), CloseDate = new DateTime(2019,5,31), ProgrammerId = "5"}
            };
            foreach (Education education in educations)
                context.Educations.Add(education);
            #endregion

            #region Create Programmer Skills
            List<ProgrammerSkill> programmerSkills = new List<ProgrammerSkill>
            {
                 new ProgrammerSkill{ProgrammerId = "1", SkillId = 1, ProgrammerSkillLevel = 20},
                new ProgrammerSkill{ProgrammerId = "1", SkillId = 2, ProgrammerSkillLevel = 50},
                new ProgrammerSkill{ProgrammerId = "2", SkillId = 1, ProgrammerSkillLevel = 70},
                new ProgrammerSkill{ProgrammerId = "2", SkillId = 2, ProgrammerSkillLevel = 100},
                new ProgrammerSkill{ProgrammerId = "2", SkillId = 3, ProgrammerSkillLevel = 45},
                new ProgrammerSkill{ProgrammerId = "3", SkillId = 4, ProgrammerSkillLevel = 45},
                new ProgrammerSkill{ProgrammerId = "3", SkillId = 1, ProgrammerSkillLevel = 60},
                new ProgrammerSkill{ProgrammerId = "3", SkillId = 7, ProgrammerSkillLevel = 100},
                new ProgrammerSkill{ProgrammerId = "2", SkillId = 6, ProgrammerSkillLevel = 100},
                new ProgrammerSkill{ProgrammerId = "1", SkillId = 5, ProgrammerSkillLevel = 20},
                new ProgrammerSkill{ProgrammerId = "3", SkillId = 8, ProgrammerSkillLevel = 70},
                new ProgrammerSkill{ProgrammerId = "3", SkillId = 9, ProgrammerSkillLevel = 80},
                new ProgrammerSkill{ProgrammerId = "1", SkillId = 10, ProgrammerSkillLevel = 70}
            };
            foreach (ProgrammerSkill programmerSkill in programmerSkills)
                context.ProgrammerSkills.Add(programmerSkill);
            #endregion

            #region Create Skill
            List<Skill> skills = new List<Skill>
            {
                new Skill{ Name = "C#", Description = "Language", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[0], programmerSkills[2], programmerSkills[6]} },
                new Skill{ Name = "Java", Description = "Language", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[1], programmerSkills[3] } },
                new Skill{ Name = "SQL", Description = "Writing of queries", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[4]}},
                new Skill{ Name = "HTML CSS", Description = "Creating front of cites", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[5]} },
                new Skill{ Name = "Python", Description = "Language", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[9]}},
                new Skill{ Name = "PHP", Description = "Language", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[8]}},
                new Skill{ Name = "GO", Description = "Language", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[7]}},
                new Skill{ Name = "Native Javascript", Description = "Language", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[10]}},
                new Skill{ Name = "Angular", Description = "TS framework", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[11]}},
                new Skill{ Name = "React", Description = "JS framework", ProgrammerSkills = new List<ProgrammerSkill>{ programmerSkills[12]}}
            };
            foreach (Skill skill in skills)
                context.Skills.Add(skill);
            #endregion
        }
    }
}
