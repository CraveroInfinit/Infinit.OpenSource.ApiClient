using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infinit.ApiClient.UnitTest
{
    [TestClass]
    public class ApiClientTeste
    {
        [TestMethod]
        public void Test_PutJSON()
        {
            ApiModel.SendModel sendMessage = new ApiModel.SendModel();
            sendMessage.Id = 1;
            sendMessage.Values = "PUT";

            ApiModel.MessageModel returnMessageExpected = new ApiModel.MessageModel();
            returnMessageExpected.message = string.Concat(sendMessage.Id, " - ", Convert.ToString(sendMessage.Values));

            ApiClient.APIClient _ApiClient = new APIClient();
            var response = (ApiModel.MessageModel)_ApiClient.PutJSON("https://infinitopensourceclienttestapi.azurewebsites.net/api/values", sendMessage, typeof(ApiModel.MessageModel)).Result.Result;

            Assert.AreEqual(returnMessageExpected.message, response.message);
        }

        [TestMethod]
        public void Test_GetJSON()
        {
            ApiModel.MessageModel returnMessageExpected = new ApiModel.MessageModel();
            returnMessageExpected.message = "SUCESS";

            ApiClient.APIClient _ApiClient = new APIClient();
            var response = (ApiModel.MessageModel)_ApiClient.GetJSON("https://infinitopensourceclienttestapi.azurewebsites.net/api/values", null, typeof(ApiModel.MessageModel)).Result.Result;

            Assert.AreEqual(returnMessageExpected.message, response.message);
        }

        [TestMethod]
        public void Test_GetByIDJSON()
        {
            APIClientParametro parametros = new APIClientParametro("ID", "10");

            ApiModel.MessageModel returnMessageExpected = new ApiModel.MessageModel();
            returnMessageExpected.message = "10 - ENCONTRADO";

            ApiClient.APIClient _ApiClient = new APIClient();
            var response = (ApiModel.MessageModel)_ApiClient.GetJSON("https://infinitopensourceclienttestapi.azurewebsites.net/api/values/", new System.Collections.Generic.List<APIClientParametro>() { parametros }, typeof(ApiModel.MessageModel)).Result.Result;

            Assert.AreEqual(returnMessageExpected.message, response.message);
        }

        [TestMethod]
        public void Test_PostarJSON()
        {
            ApiModel.SendModel sendMessage = new ApiModel.SendModel();
            sendMessage.Id = 1;
            sendMessage.Values = "POST";

            ApiModel.MessageModel returnMessageExpected = new ApiModel.MessageModel();
            returnMessageExpected.message = string.Concat(sendMessage.Id, " - ", Convert.ToString(sendMessage.Values));

            ApiClient.APIClient _ApiClient = new APIClient();
            var response = (ApiModel.MessageModel)_ApiClient.PostarJSON("https://infinitopensourceclienttestapi.azurewebsites.net/api/values", sendMessage, typeof(ApiModel.MessageModel)).Result.Result;

            Assert.AreEqual(returnMessageExpected.message, response.message);
        }

        [TestMethod]
        public void Test_DeletarJSON()
        {

            ApiModel.MessageModel returnMessageExpected = new ApiModel.MessageModel();
            returnMessageExpected.message = string.Concat(1, " - DELETADO");

            ApiClient.APIClient _ApiClient = new APIClient();
            var response = (ApiModel.MessageModel)_ApiClient.DeletarJSON("https://infinitopensourceclienttestapi.azurewebsites.net/api/values", 1, typeof(ApiModel.MessageModel)).Result.Result;

            Assert.AreEqual(returnMessageExpected.message, response.message);
        }


    }
}
