using DiscriminatorExample.Data;
using DiscriminatorExample.Models;

namespace DiscriminatorExample.Services
{
    public class StaffService
    {
        private readonly SchoolDbContext _dbContext;
        public StaffService(SchoolDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public void AddStaff()
        {
                var teacher = new Teacher
                {
                    Name = "John Doe",
                    HireDate = DateTime.Now,
                    Subject = "Mathematics"
                };
                _dbContext.Staff.Add(teacher);

                var administrator = new Administrator
                {
                    Name = "Jane Smith",
                    HireDate = DateTime.Now,
                    Department = "Administration"
                };
                _dbContext.Staff.Add(administrator);

                _dbContext.SaveChanges();
        }

        public List<Staff> GetStaff()
        {
                var allStaff = _dbContext.Staff.ToList();
                //foreach (var staff in allStaff)
                //{
                //    if (staff is Teacher)
                //    {
                //        var teacher = staff as Teacher;
                //        Console.WriteLine($"Teacher: {teacher.Name}, Subject: {teacher.Subject}");
                //    }
                //    else if (staff is Administrator)
                //    {
                //        var administrator = staff as Administrator;
                //        Console.WriteLine($"Administrator: {administrator.Name}, Department: {administrator.Department}");
                //    }
                //}
                return allStaff;
        }
    }
}
