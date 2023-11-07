using ePreschool.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class ChildDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GUID { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityOfBirthId { get; set; }
        public CityDto CityOfBirth { get; set; }
        public int CountryOfBirthId { get; set; }
        public CountryDto CountryOfBirth { get; set; }
        public int FamilyMembers { get; set; }
        public string Adress { get; set; }
        public int PreschoolId { get; set; }
        public PreschoolDto Preschool { get; set; }
        public int BusinessUnitId { get; set; }
        public BusinessUnitDto BusinessUnit { get; set; }
        public int AlternativeBusinessUnitId { get; set; }
        public BusinessUnitDto AlternativeBusinessUnit { get; set; }
        public int ProgramId { get; set; }
        public WorkingProgramDto Program { get; set; }
        public ChildDevelopmentStatus ChildDevelopmentStatus { get; set; }
        public DiagnosticProcedure? DiagnosticProcedure { get; set; }
        public bool Rehabilitation { get; set; }
        public string SpecificHealthNeeds { get; set; }
        public string PreviousPreschool { get; set; }
        public string Siblings { get; set; }
    }
}
