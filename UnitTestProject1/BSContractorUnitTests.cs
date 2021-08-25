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
        //Unit Test case ID : 10001
        //This test case will test the observable collection for customer view model to see if it 
        //generates the correct number of customers
        //Rmemeber that you are connecting to databasd to retrieve the customers and copy them to 
        //observable collection. Meaning if the applcation then adds new customers 
        //number of customers(count) may not match with the static 5 that is why this is not a pure unit test
        //But these types of tests are actulllay  called Integration test cases.
        [TestMethod]
        public void TestContractorCollection()
        {
            ContractorViewModel contractorVM = new ContractorViewModel();
            int count = contractorVM.Contractors.Count;
            Assert.AreEqual(4, count);

        }

        //the follwing code is typical unit test...no connecting any exteranl service/ application
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
            //try a few asserts here
            //you can make this method to add this customer to the database by connecting to the addmethod()
        }
        [TestMethod]
        public void TestContractorCollectionMock()
        {
            DateTime bdate = new DateTime(1979, 03, 15);  //y/m/d
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
            mockContractorVM.Setup(mc => mc.GetAllContractors()).Returns(mockContractors);//this part of synstax to use getallcustomers utilising bypass
            int count = mockContractorVM.Object.GetAllContractors().Count;
            Assert.AreEqual(1, count);

            //get => _customerId;
            //set => _customerId = value;
            //get { return _customerId; }
            //set { _customerId = value; }
        }
    }
}
