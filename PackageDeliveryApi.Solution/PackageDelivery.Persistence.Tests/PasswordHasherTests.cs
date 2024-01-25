using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.Tests.Strapper;

namespace PackageDelivery.Persistence.Tests
{
    public class PasswordHasherTests
    {
        private PackageDeliveryDbContext packageDeliveryDbContext;

        private ServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            serviceProvider = Bootstrapper.Bind();

            packageDeliveryDbContext = serviceProvider.GetRequiredService<PackageDeliveryDbContext>();
        }

        [TearDown]
        public async Task TearDown()
        {
            await serviceProvider.DisposeAsync();

            await packageDeliveryDbContext.DisposeAsync();
        }

        [Test]
        public async Task Should_updatePassword_ReturnOk()
        {
            var newPassword = "P@ssw0rd123_";

            var passwordHasher = new PasswordHasher<User>();

            var user = await packageDeliveryDbContext.Users.FirstOrDefaultAsync(x => x.Id == 2);

            user.Should().NotBeNull();

            var newHashedPassword = passwordHasher.HashPassword(user, newPassword);

            newHashedPassword.Should().NotBeNull();
        }
    }
}