using CFSAspnetCoreService.Data.Repositories.Contracts;
using CFSAspnetCoreService.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace AspnetCoreServiceTest
{
    public class EmployeesRepositoryTest: IDisposable
    {
        // Initialize setup
        public EmployeesRepositoryTest()
        {
            // create some mock employees to play with
            IList<Employees> emps = new List<Employees>
                {
                    new Employees { Id = 1, DepartmentId = 1, FirstName = "Sagar", LastName = "Patil" },
                    new Employees { Id = 2, DepartmentId = 1, FirstName = "Anil", LastName = "Patil" },
                    new Employees { Id = 3, DepartmentId = 2, FirstName = "Nilam", LastName = "Jadhav" }
                };

            // Mock the Employees Repository using Moq
            Mock<IEmployeeRepository> mockEmpRepo = new Mock<IEmployeeRepository>();

            // Return all the Employees
            mockEmpRepo.Setup(mr => mr.GetAll()).Returns(emps);

            // Find first Employee
            //mockEmpRepo.Setup(mr => mr.GetFirstEmployee()).Returns(emps.Where);
        }

        // Post cleaup
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        [Fact]
        // Same output without varying inputs to test method
        public void Get_FirstEmployee_VerifyMethodExecution()
        {
            //Arrange
            Mock<IEmployeeRepository> empRepo = new Mock<IEmployeeRepository>();
            //Act
            empRepo.Object.GetFirstEmployee();
            //Assert
            empRepo.Verify(x => x.GetFirstEmployee(), Times.Once());
        }

        [Fact]
        // Same output without varying inputs to test method
        public void Get_RecentEmployee_VerifyMethodExecution()
        {
            //Arrange
            Mock<IEmployeeRepository> empRepo = new Mock<IEmployeeRepository>();
            //Act
            empRepo.Object.GetRecentEmployee();
            //Assert
            empRepo.Verify(x => x.GetRecentEmployee(), Times.Once());
        }
    }
}
