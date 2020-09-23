using System.Threading.Tasks;
using SalesManagement.Models.TokenAuth;
using SalesManagement.Web.Controllers;
using Shouldly;
using Xunit;

namespace SalesManagement.Web.Tests.Controllers
{
    public class HomeController_Tests: SalesManagementWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}