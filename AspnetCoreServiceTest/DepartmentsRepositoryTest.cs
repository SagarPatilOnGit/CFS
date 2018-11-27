using CFSAspnetCoreService.Data.Repositories.Contracts;
using CFSAspnetCoreService.Models;
using Moq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace AspnetCoreServiceTest
{
    public class DepartmentsRepositoryTest
    {
        [Fact]
        //same output without varying inputs to test method
        public void Get_FirstDepartment_VerifyMethodExecution()
        {
            //Arrange
            Mock<IDepartmentRepository> deptRepo = new Mock<IDepartmentRepository>();
            //Act
            deptRepo.Object.GetFirstDepartment();
            //Assert
            deptRepo.Verify(x => x.GetFirstDepartment());
        }

        [Fact]
        //same output without varying inputs to test method
        public void Get_RecentDepartment_VerifyMethodExecution()
        {
            //Arrange
            Mock<IDepartmentRepository> deptRepo = new Mock<IDepartmentRepository>();
            //Act
            deptRepo.Object.GetRecentDepartment();
            //Assert
            deptRepo.Verify(x => x.GetRecentDepartment());
        }

        [Theory, ClassData(typeof(DepartmentTestDataGenerator))]
        public void Add_DepartmentNotNull_VerifyMultipleDepartmentSaveToRepository(Departments dept1, Departments dept2)//string deptName)
        {
            //Arrange
            Mock<IDepartmentRepository> deptRepo = new Mock<IDepartmentRepository>();
            //Act
            deptRepo.Object.Add(dept1);//(new Departments() { Name = deptName });
            deptRepo.Object.Add(dept2);
            //Assert            
            deptRepo.Verify(x => x.Add(It.IsAny<Departments>()), Times.Exactly(2));
        }

        [Theory, ClassData(typeof(DepartmentTestDataGenerator))]
        public void Add_DepartmentNotNull_VerifyDepartmentSaveToRepository(Departments dept1, Departments dept2)//string deptName)
        {
            //Arrange
            Mock<IDepartmentRepository> deptRepo = new Mock<IDepartmentRepository>();
            //Act
            deptRepo.Object.Add(dept1);//new Departments() { Name = deptName });
            //Assert            
            deptRepo.Verify(x => x.Add(It.Is<Departments>(d => d.Name.Equals("Admin"))), Times.Once());
        }

        //use of memberdata
        [Theory, MemberData(nameof(TesData))]
        public void Add_Department_VerifyMultipleDepartmentSaveToRepository(string dept1Name, string dept2Name)
        {
            //Arrange
            Mock<IDepartmentRepository> deptRepo = new Mock<IDepartmentRepository>();
            //Act
            deptRepo.Object.Add(new Departments() { Name = dept1Name });
            deptRepo.Object.Add(new Departments() { Name = dept2Name });
            //Assert            
            deptRepo.Verify(x => x.Add(It.IsAny<Departments>()), Times.Exactly(2));
        }

        //Mermber Data Setup in same class as of test class
        public static IEnumerable<object[]> TesData()
        {
            yield return new object[] { "Admin", "HR" };
            yield return new object[] { "Delivery", "IT Support" };
        }
    }

    //Class Data Setup
    internal class DepartmentTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
            {
                //new object[] { "Admin" }
                //, new object[] { "HR" }
                new object[] {
                    new Departments() { Name = "Admin"},
                    new Departments() { Name = "HR"}
                },
                new object[]{
                    new Departments() { Name = "Delivery" },
                    new Departments() { Name = "IT Support"}
                }
            };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
