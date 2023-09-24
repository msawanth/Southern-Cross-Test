using RestSharp;
using APITests.Model;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Net;

namespace APITests.Tests
{
    [TestFixture]
    public class UserRegistrationTests
    {
        private RestClient _client;
        private string _baseUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/users";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public void CreateUserRegistrationTest()
        {
            // Create a new user request model
            var requestModel = new UserRegistrationModel
            {
                ConfirmPassword = "Q123456&y",
                Password = "Q123456&y",
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Username = Faker.Name.Middle()
            };

            string requestBody = JsonConvert.SerializeObject(requestModel);

            // Create a request with the JSON body
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

            // Execute the request
            var response = _client.Execute(request);

            // Assert the response
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        }
    }
}
