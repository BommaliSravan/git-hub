using AutoFixture;
using EmployeeApplication.Controllers;
using EmployeeApplication.Core.Interfaces;
using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeRepositary> _employeeRepoMock;
        private Fixture _fixture;
        private EmployeeController _controller;
        public EmployeeControllerTests()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeRepositary>();
        }
        [TestMethod]
        public async Task Get_Employee_ReturnOk()
        {
            var employeeList = _fixture.CreateMany<Employee>(3).ToList();
            _employeeRepoMock.Setup(repo => repo.GetEmployee()).Returns(employeeList);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.GetEmployee();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);

        }
        [TestMethod]
        public async Task Get_Employee_ThrowException()
        {
            _employeeRepoMock.Setup(repo => repo.GetEmployee()).Throws(new Exception());
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.GetEmployee();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task Insert_Employee_ReturnOk()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.InsertEmployee(It.IsAny<Employee>())).Returns(employee);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.InsertEmployee(employee);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Update_Employee_ReturnOk()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.UpdateEmployee(It.IsAny<Employee>())).Returns(employee);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.UpdateEmployee(employee);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Delete_Employee_ReturnOk()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.DeleteEmployee(It.IsAny<int>())).Returns(employee);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.DeleteEmployee(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
    }

    
}
