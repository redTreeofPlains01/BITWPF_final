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
       
        [TestMethod]
        public void TestStaffCollection()
        {
            StaffViewModel staffVM = new StaffViewModel();
            int count = staffVM.Staffs.Count;
            Assert.AreEqual(4, count);

        }
       
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
            
        }

        [TestMethod]
        public void TestClientCollectionMock()
        {
            DateTime bdate = new DateTime(1979, 03, 15);  
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
            mockStaffVM.Setup(mc => mc.GetAllStaffs()).Returns(mockStaffs);
            int count = mockStaffVM.Object.GetAllStaffs().Count;
            Assert.AreEqual(1, count);
           
        }
    }
}
