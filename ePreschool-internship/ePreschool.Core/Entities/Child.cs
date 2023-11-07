using ePreschool.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Entities
{
    public class Child : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GUID { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityOfBirthId { get; set; }
        public City CityOfBirth { get; set; }
        public int CountryOfBirthId { get; set; }
        public Country CountryOfBirth { get; set; }
        public int FamilyMembers { get; set; }
        public string Adress { get; set; }
        public int PreschoolId { get; set; }
        public Preschool Preschool { get; set; }
        public int BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public int AlternativeBusinessUnitId { get; set; }
        public BusinessUnit AlternativeBusinessUnit { get; set; }
        public int ProgramId { get; set; }
        public WorkingProgram Program { get; set; }
        public ChildDevelopmentStatus ChildDevelopmentStatus { get; set; }
        public DiagnosticProcedure? DiagnosticProcedure { get; set; }
        public bool Rehabilitation { get; set; } = false;
        public string SpecificHealthNeeds { get; set; }
        public string PreviousPreschool { get; set; }
        public string Siblings { get; set; }
    }
}
