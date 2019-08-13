using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Configurations;
using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Repositories;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using AutoMapper;
using BLL;
namespace TestDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutomapperConfiguration>());
            string connectionString= @"Data Source=DESKTOP-795FDLM\SQLEXPRESS;Initial catalog = KnowledgeAccountingSystemDataBase;Integrated Security=True";
            TestClass test = new TestClass(connectionString);





            //ProjectDTO projectDTO = new ProjectDTO()
            //{
            //    Id = 1,
            //    Name = "Clean room",
            //    StartDate = new DateTime(2017, 5, 13),
            //    DeadLine = new DateTime(2018, 5, 13),
            //    FinishDate = new DateTime(2018, 1, 12),
            //    Status = "Complete",
            //    Description = "Clean room with the help of vinuk",
            //    Reference = "https://idi_nahui.com/",
            //    ProgrammerId = "2"
            //};
            //ProjectService projectService = new ProjectService(test.UnitOfWork);
            //projectService.Delete(1);
            //projectService.Delete(6);

            //SkillDTO SkillDTO = new SkillDTO()
            //{
            //    Id = 1,
            //    Name = "C#",
            //    Description = " Programming language"
            //};

            //SkillService skillService = new SkillService(test.UnitOfWork);
            //skillService.Insert(SkillDTO);


            //WorkExperienceService workExperienceService = new WorkExperienceService(test.UnitOfWork);
            //WorkExperienceDTO workExperienceDTO = new WorkExperienceDTO()
            //{
            //    Id = 2,
            //    Company = "Google",
            //    Position = "Java Developer",
            //    EntryDate = new DateTime(2017, 2, 4),
            //    CloseDate = new DateTime(2018, 3, 5),
            //    ProgrammerId = "2"
            //};


            //workExperienceService.Update(2, workExperienceDTO);


            //EducationDTO educationDTO = new EducationDTO()
            //{
            //    Id =1,
            //    Name = "zalypa konska",
            //    EntryDate = new DateTime(2016, 9, 1),
            //    CloseDate = new DateTime(2020, 5, 31),
            //    Notes = "klasno ychivsya",
            //    ProgrammerId = "1"
            //};

            //EducationService educationService = new EducationService(test.UnitOfWork);
            //educationService.Update(1,educationDTO);

            ProgrammerDTO programmerDTO = new ProgrammerDTO()
            {
                Id = "1",
                FullName = "Шаромига",
                Age = 50,
                WorkEmail = "eby_sobak@gmail.com",
                Addres = "r,fdlvmlvmls;mv",
                PhoneNumber = "ne dolzhno ebat"
            };

           

            //EducationService educationService = new EducationService(test.UnitOfWork);
            //var x = educationService.GetEducationByProgrammerId("1");
            //foreach (var item in x)
            //    Console.WriteLine(item.Name);

           
            //ProjectService projectService = new ProjectService(test.UnitOfWork);
            //var x = projectService.GetProjectByProgrammerId("1");
            //foreach (var item in x)
            //    Console.WriteLine(item.Name);



            //foreach(var items in programmers)
            //{
            //    Console.WriteLine(items.Id + " | " + items.FullName);
            //}

            //var educations = test.UnitOfWork.Educations.GetAll();
            //foreach (var items in educations)
            //    Console.WriteLine(items.Id + " | " + items.Name);

            //Project project = new Project()
            //{
            //    Id=1,
            //    Name = "EFApplication",
            //    Status = "Complete",
            //    Reference = "https://EFApplication.com/",
            //    Description = "Create application using EF",
            //    ProgrammerId = "1"


            //};
            //test.UnitOfWork.Projects.Update(project);
            //test.UnitOfWork.Save();




        }
    }
}
