using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Syntax;
using System.Web.Http.Dependencies;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
 

namespace WebApi.Ninject
{
    public class NinjectRegistration:NinjectModule
    {
        public override void Load()
        {
            Bind<IProgrammerService>().To<ProgrammerService>();
            Bind<ISkillService>().To<SkillService>();
            Bind<IWorkExperienceService>().To<WorkExperienceService>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("Default connection");
            Bind<IEducationService>().To<EducationService>();
        }
    }
}