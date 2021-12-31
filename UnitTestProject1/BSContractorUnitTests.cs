using BitServices_version_1.Models;
using BitServices_version_1.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class BSContractorUnitTests
    {
        [TestMethod]
        public void TestContractorCollection()
        {
            ContractorViewModel contractorVM = new ContractorViewModel();
            int count = contractorVM.Contractors.Count;
            Assert.AreEqual(4, count);

        }

      
        [TestMethod]
        public void TestContractorObject()
        {
            DateTime bdate = new DateTime(1979, 03, 15);
            Contractor contractor = new Contractor
            {
                ContractorId = 1001,
                FirstName = "Randy",
                LastName = "Sandpass",
                DOB = bdate,
                Email = "randys@email.com",
                Address = "2 laila ave",
                Suburb = "Mona Vale",
                PostCode = "1658",
                Password = "straw"
            };
            Assert.AreEqual("Randy", contractor.FirstName);
          
        }
        [TestMethod]
        public void TestContractorCollectionMock()
        {
            DateTime bdate = new DateTime(1979, 03, 15); 
            ObservableCollection<Contractor> mockContractors = new ObservableCollection<Contractor>();
            mockContractors.Add(
                 new Contractor
                 {
                     ContractorId = 1001,
                     FirstName = "Randy",
                     LastName = "Sandpass",
                     DOB = bdate,
                     Email = "randys@email.com",
                     Address = "2 laila ave",
                     Suburb = "Mona Vale",
                     PostCode = "1658",
                     Password = "straw"
                 }
            );
            Mock<ContractorViewModel> mockContractorVM = new Mock<ContractorViewModel>();
            mockContractorVM.Setup(mc => mc.GetAllContractors()).Returns(mockContractors);
            int count = mockContractorVM.Object.GetAllContractors().Count;
            Assert.AreEqual(1, count);

        }
    }
}
