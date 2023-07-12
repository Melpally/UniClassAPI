using Microsoft.EntityFrameworkCore;
using UniClass.Models;

namespace UniClass.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Student>(s => 
            {
                s.HasData(new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Malika Temurova",
                    Funding = Funding.Scholarship,
                    DateOfBirth = DateTime.Today,
                    MajorId = new Guid("9d34ba28-9a0d-4e02-8f17-04c3c31a3d5c")
                });
                s.HasData(new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Mavluda Asalxodjaeva",
                    Funding = Funding.SelfFinanced,
                    DateOfBirth = new DateTime(1979, 12, 13),
                    MajorId = new Guid("4912c961-39d9-4ba1-b035-523e700280c0")
                });
                s.HasData(new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Munisa Rizaeva",
                    Funding = Funding.SelfFinanced,
                    DateOfBirth = new DateTime(1980, 11, 24),
                    MajorId = new Guid("4912c961-39d9-4ba1-b035-523e700280c0")
                });
                s.HasData(new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Sitora Tulyaganova",
                    Funding = Funding.GovernmentGrant,
                    DateOfBirth = new DateTime(1981, 03, 12),
                    MajorId = new Guid("33977982-bbe3-44ed-89e4-00cad7e6f6ed")
                });

            });
            _builder.Entity<Major>(m => 
            {
                m.HasData(new Major
                {
                    Id = new Guid("9d34ba28-9a0d-4e02-8f17-04c3c31a3d5c"),
                    Name = "Business Information Systems"
                });
                m.HasData(new Major
                {
                    Id = new Guid("4912c961-39d9-4ba1-b035-523e700280c0"),
                    Name = "Business Management"
                });
                m.HasData(new Major
                {
                    Id = new Guid("33977982-bbe3-44ed-89e4-00cad7e6f6ed"),
                    Name = "Commercial Law"
                });

            });
        }

    }

}