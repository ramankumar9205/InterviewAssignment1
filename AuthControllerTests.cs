// Unit Tests (xUnit)
// Create a separate test project and include this code
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class AuthControllerTests
{
    [Fact]
    public async Task Login_ReturnsOkResult_WhenCredentialsAreValid()
    {
        // Arrange
        var user = new ApplicationUser { Email = "test@example.com" };
        var mockUserManager = MockUserManager();
        mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);

        var mockSignInManager = MockSignInManager(mockUserManager.Object);
        mockSignInManager.Setup(x => x.PasswordSignInAsync(user, It.IsAny<string>(), false, false))
                         .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

        var controller = new AuthController(mockUserManager.Object, mockSignInManager.Object);

        // Act
        var result = await controller.Login(new LoginRequest { Email = "test@example.com", Password = "password" });

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    private static Mock<UserManager<ApplicationUser>> MockUserManager()
    {
        var store = new Mock<IUserStore<ApplicationUser>>();
        return new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
    }

    private static Mock<SignInManager<ApplicationUser>> MockSignInManager(UserManager<ApplicationUser> userManager)
    {
        var contextAccessor = new Mock<Microsoft.AspNetCore.Http.IHttpContextAccessor>();
        var claimsFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
        return new Mock<SignInManager<ApplicationUser>>(userManager, contextAccessor.Object, claimsFactory.Object, null, null, null, null);
    }
}
