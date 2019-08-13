using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using OfficeOpenXml.Style;
using AutoMapper;
using System.Drawing;
using OfficeOpenXml.Table;
using OfficeOpenXml;

namespace BLL.Services
{
    public class ProgrammerService:IProgrammerService
    {
        IUnitOfWork DataBase { get; set; }
        public ProgrammerService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }
        public IEnumerable<ProgrammerDTO> GetProgrammersBySkill(int? idSkill, int knowledgeLevel)
        {
            if (knowledgeLevel < 0 || knowledgeLevel > 100)
                throw new ValidationException("Invalid Value", "Level");
            if (idSkill != null)
                if(DataBase.Skills.Get(idSkill.Value)==null)
                    throw new ValidationException("Incorrect skill`s Id. Try some more", "Id");
            IEnumerable<string> programmersId = new List<string>();
            if (idSkill != null)
                programmersId = DataBase.ProgrammerSkills.GetAll().Where(x => x.ProgrammerSkillLevel >= knowledgeLevel).Select(y => y.ProgrammerId).ToList();
            IEnumerable<Programmer> programmers = DataBase.Programmers.GetAll().Where(x => programmersId.Contains(x.Id));
            return Mapper.Map<IEnumerable<Programmer>, IEnumerable<ProgrammerDTO>>(programmers);
        }
        public ProgrammerDTO Get(string id)
        {
            if (id == null)
                throw new ValidationException("Incorrect programmer`s Id. Try some more", "Id");
            var programmer = DataBase.Programmers.Get(id);
            if (programmer == null)
                throw new ValidationException("No information about this programmer. Try some more", "Id");
            return Mapper.Map<Programmer, ProgrammerDTO>(programmer);
        }
        public void Update(string userId, ProgrammerDTO programmerDTO)
        {
            if (programmerDTO == null)
                throw new ValidationException("No information about this programmer. Try some more", "Id");
            if (userId == null)
                throw new ValidationException("Programmer and User Id does not match", "Id");
            DataBase.Programmers.Update(Mapper.Map<ProgrammerDTO, Programmer>(programmerDTO));
            DataBase.Save();
        }
        public byte[] GenerateReport(List<ProgrammerDTO> programmers)
        {
            ExcelFill fill;
            Border border;
            if (programmers == null)
                throw new ValidationException("No information about this programmer", "Id");
            int firstRow = 1;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add("Programmers Excel Report");
                ExcelRange excelRange = sheet.Cells[$"A{firstRow}:F{programmers.Count() + firstRow}"];
                excelPackage.Workbook.Properties.Author = "Manager";
                excelPackage.Workbook.Properties.Title = "Thumb";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                excelRange.Style.Font.Bold = true;
                excelRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                excelRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = excelRange.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = excelRange.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                excelRange = sheet.Cells["A1"];
                excelRange.Value = "Full Name";
                excelRange = sheet.Cells["B1"];
                excelRange.Value = "Age";
                excelRange = sheet.Cells["C1"];
                excelRange.Value = "Work Email";
                excelRange = sheet.Cells["D1"];
                excelRange.Value = "Phone number";
                excelRange = sheet.Cells["E1"];
                excelRange.Value = "Addres";

                for(int i = firstRow+1;i<=programmers.Count()+1;i++)
                {
                    excelRange = sheet.Cells[$"A{i}"];
                    excelRange.Value = programmers[i - (firstRow + 1)].FullName;
                    excelRange = sheet.Cells[$"B{i}"];
                    excelRange.Value = programmers[i - (firstRow + 1)].Age;
                    excelRange = sheet.Cells[$"C{i}"];
                    excelRange.Value = programmers[i - (firstRow + 1)].WorkEmail;
                    excelRange = sheet.Cells[$"D{i}"];
                    excelRange.Value = programmers[i - (firstRow + 1)].PhoneNumber;
                    excelRange = sheet.Cells[$"E{i}"];
                    excelRange.Value = programmers[i - (firstRow + 1)].Addres;
                }
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                return excelPackage.GetAsByteArray();
            }
        }
    }
}
