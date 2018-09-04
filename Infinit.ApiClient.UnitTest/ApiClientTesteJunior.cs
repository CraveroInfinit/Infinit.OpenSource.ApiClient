using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net;

namespace Infinit.ApiClient.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        const string URLTest = "https://boiling-citadel-15307.herokuapp.com/";


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region TESTES JUNIOR
        [TestMethod]
        public void ApiClientTest_TestaGetJSON_ReturnRespostaPadrao()
        {
            var resultMethod = new ApiModel.MessageModel
            {
                message = "resposta padrao"
            };

            var API = new APIClient();
            var response = (ApiModel.MessageModel)API.GetJSON(URLTest, new List<APIClientParametro>(), typeof(ApiModel.MessageModel)).Result.Result;

            Assert.AreEqual(resultMethod.message, response.message);
        }
        [TestMethod]
        public void ApiClientTest_TestaGetByIdJSON_ReturnIdEncontrado()
        {
            var resultMethod = new ApiModel.MessageModel
            {
                message = "Id encontrado"
            };

            var API = new APIClient();
            var response = (ApiModel.MessageModel)API.GetJSON(URLTest, 1, typeof(ApiModel.MessageModel), null).Result.Result;

            Assert.AreEqual(resultMethod.message, response.message);
        }
        [TestMethod]
        public void ApiClientTest_TestaGetByIdStringJSON_ReturnIdStringEncontrado()
        {
            var resultMethod = new ApiModel.MessageModel
            {
                message = "Id em string encontrado"
            };

            var API = new APIClient();
            var response = (ApiModel.MessageModel)API.GetJSON(URLTest, "2", typeof(ApiModel.MessageModel), null).Result.Result;

            Assert.AreEqual(resultMethod.message, response.message);
        }
        [TestMethod]
        public void ApiClientTest_TestaPostJSON_ReturnNull()
        {
            var resultMethod = new ApiModel.SendModel
            {
                Id = 321654,
                Values = "produto"
            };

            var API = new APIClient();
            var response = API.PostarJSON(URLTest, resultMethod).Result;

            Assert.AreEqual(null, response.Result);
        }
        [TestMethod]
        public void ApiClientTest_TestaPostJSON_ReturnObjetoPostado()
        {
            var resultMethod = new ApiModel.SendModel
            {
                Id = 321654,
                Values = "produto"
            };

            var API = new APIClient();
            var response = (ApiModel.SendModel)API.PostarJSON(URLTest, resultMethod, typeof(ApiModel.SendModel)).Result.Result;

            Assert.AreEqual(resultMethod.Id, response.Id);
        }
        [TestMethod]
        public void ApiClientTest_TestaPutJSON_ReturnObjetoPostado()
        {
            var resultMethod = new ApiModel.SendModel
            {
                Id = 321654,
                Values = "produto"
            };

            var API = new APIClient();
            var response = (ApiModel.SendModel)API.PutJSON(URLTest, resultMethod, typeof(ApiModel.SendModel)).Result.Result;

            Assert.AreEqual(resultMethod.Id, response.Id);
        }
        [TestMethod]
        public void ApiClientTest_TestaDeleteJSON_ReturnObjetoPostado()
        {
            var resultMethod = new ApiModel.SendModel
            {
                Id = 321654,
                Values = "produto"
            };

            var API = new APIClient();
            var response = (ApiModel.SendModel)API.DeletarJSON(URLTest, 1, typeof(ApiModel.SendModel)).Result.Result;

            Assert.AreEqual(new ApiModel.SendModel().Id, response.Id);
        }
        #endregion
    }
    public class TestGetJSON
    {
        public string message { get; set; }
    }
}
