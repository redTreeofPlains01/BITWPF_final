using System;
using BitServices_version_1.ViewModels;
using BitServices_version_1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class BSClientUnitTests
    {
        //Unit Test case ID : 10001
        //This test case will test the observable collection for Client view model to see if it 
        //generates the correct number of Clients
        //Remember that you are connecting to database to retrieve the Clients and copy them to the observable collection. Meaning if the applcation then adds new Clients 
        //number of Clients(count) may not match with the static 5 that is why this is not a pure unit test
        //But these types of tests are actulllay called Integration test cases.
        [TestMethod]
        public void TestClientCollection()
        {
            ClientViewModel clientVM = new ClientViewModel();
            int count = clientVM.Clients.Count;
            Assert.AreEqual(4, count);

        }

        //the following code is typical unit test...no connecting any exteranl service/ application
        [TestMethod]
        public void TestClientObject()
        {
            DateTime bdate = new DateTime(1979, 03, 15);
            Client client = new Client
            {
                ClientId = 1001,
                FirstName = "Randy",
                LastName = "Sandpass",
                DOB = bdate,
                Email = "randys@email.com",
                Address = "2 laila ave",
                Suburb = "Mona Vale",
                PostCode = "1658",
                Password = "straw"
            };
            Assert.AreEqual("Randy", client.FirstName);
            //try a few asserts here
            //you can make this method to add this Client to the database by connecting to the addmethod()
        }
        [TestMethod]
        public void TestClientCollectionMock()
        {
            DateTime bdate = new DateTime(1979, 03, 15);  //y/m/d
            ObservableCollection<Client> mockClients = new ObservableCollection<Client>();
            mockClients.Add(
                 new Client
                 {
                     ClientId = 1001,
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
            Mock<ClientViewModel> mockClientVM = new Mock<ClientViewModel>();
            mockClientVM.Setup(mc => mc.GetAllClients()).Returns(mockClients);//this part of syntax to use getallClients utilising bypass
            int count = mockClientVM.Object.GetAllClients().Count;
            Assert.AreEqual(1, count);

            //get => _clientId;
            //set => _clientId = value;
            //get { return _ClientId; }
            //set { _ClientId = value; }
        }
    }
}
