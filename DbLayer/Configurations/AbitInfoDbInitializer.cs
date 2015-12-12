using System.Collections.Generic;
using System.Data.Entity;
using DbLayer.Models;

namespace DbLayer.Configurations
{
     public class AbitInfoDbInitializer : DropCreateDatabaseAlways<AbitInfoDbContext>
    //public class AbitInfoDBInitializer: DropCreateDatabaseIfModelChanges<AbitInfoDbContext>
    {
         protected override void Seed(AbitInfoDbContext context)
         {
             var roles = new List<AspNetRole>
             {
                 new AspNetRole {Id = "1", Name = "admin", State = EntityState.Added},
                 new AspNetRole {Id = "2", Name = "user", State = EntityState.Added}
             };
             roles.ForEach(r => context.AspNetRoles.Add(r));
             context.SaveChanges();

             var universities = new List<University>
             {
                 new University()
                 {
                     Id = 1,
                     Name = "Львівський національний університет імені Івана Франка",
                     State = EntityState.Added
                 },
                 new University()
                 {
                     Id = 2,
                     Name = "Київський національний університет імені Тараса Шевченка",
                     State = EntityState.Added
                 }
             };
             universities.ForEach(u => context.Universities.Add(u));
             context.SaveChanges();

             var faculties = new List<Faculty>
             {
                 new Faculty()
                 {
                     Id = 1,
                     Name = "Факультет прикладної математики та інформатики",
                     UniversityId = 1,
                     State = EntityState.Added
                 },
                 new Faculty()
                 {
                     Id = 2,
                     Name = "Механіко-математичний факультет",
                     UniversityId = 1,
                     State = EntityState.Added
                 },
                 new Faculty() 
                 {
                     Id = 3,
                     Name = "Факультет кібернетики",
                     UniversityId = 2,
                     State = EntityState.Added
                 }
             };
             faculties.ForEach(f => context.Faculties.Add(f));
             context.SaveChanges();

             var specialities = new List<Speciality>()
             {
                 new Speciality()
                 {
                     Id = 1,
                     Name = "Системний аналіз",
                     FacultyId = 1,
                     LicencedVolume = 60,
                     StateOrder = 40,
                     Type = (int) SpecialityType.Bachelor,
                     State = EntityState.Added
                 }
             };
             specialities.ForEach(s => context.Specialities.Add(s));
             context.SaveChanges();
         }
    }
}
