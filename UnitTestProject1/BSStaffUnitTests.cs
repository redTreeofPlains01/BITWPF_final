using System;
using BitServices_version_1.ViewModels;
using BitServices_version_1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using Moq;

namespace UnitTestProject1
{
    public class BSStaffUnitTests
    {
        //Unit Test case ID : 10001
        //This test case will test the observable collection for customer view model to see if it 
        //generates the correct number of customers
        //Rmemeber that you are connecting to databasd to retrieve the customers and copy them to 
        //observable collection. Meaning if the applcation then adds new customers 
        //number of customers(count) may not match with the static 5 that is why this is not a pure unit test
        //But these types of tests are actulllay  called Integration test cases.
        [TestMethod]
        public void TestStaffCollection()
        {
            StaffViewModel staffVM = new StaffViewModel();
            int count = staffVM.Staffs.Count;
            Assert.AreEqual(4, count);

        }

        //the follwing code is typical unit test...no connecting any exteranl 
        //service/ application
        [TestMethod]
        public void TestStaffObject()
        {
            DateTime bdate = new DateTime(1979, 03, 15);
            Staff staff = new Staff
            {
                StaffId = 1001,
                FirstName = "Randy",
                LastName = "Sandpass",
                DOB = bdate,
                Email = "randys@email.com",
                Address = "2 laila ave",
                Suburb = "Mona Vale",
                PostCode = "1658",
                Password = "straw"
            };
            Assert.AreEqual("Randy", staff.FirstName);
            //try a few asserts here
            //you can make this method to add this customer to the database by connecting to the addmethod()
        }
        [TestMethod]
        public void TestClientCollectionMock()
        {
            DateTime bdate = new DateTime(1979, 03, 15);  //y/m/d
            ObservableCollection<Staff> mockStaffs = new ObservableCollection<Staff>();
            mockStaffs.Add(
                 new Staff
                 {
                     StaffId = 1001,
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
            Mock<StaffViewModel> mockStaffVM = new Mock<StaffViewModel>();
            mockStaffVM.Setup(mc => mc.GetAllStaffs()).Returns(mockStaffs);//this part of synstax to use getallcustomers utilising bypass
            int count = mockStaffVM.Object.GetAllStaffs().Count;
            Assert.AreEqual(1, count);

            //get => _customerId;
            //set => _customerId = value;
            //get { return _customerId; }
            //set { _customerId = value; }
        }
    }
}
