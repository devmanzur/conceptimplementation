using Concepts.Core.Builders;
using FluentAssertions;
using Xunit;

namespace Concepts.Core.UnitTests.Builders
{
    public partial class DatabaseConnectionBuilderTests
    {
        [Fact]
        public void ShouldReturnDatabaseConnectionWhenDatabaseConnectionBuilderIsInvoked()
        {
            const string givenHostName = "localhost";
            const string givenDatabaseName = "mysql";
            const string givenPassword = "123456";
            const string givenUsername = "root";

            DatabaseConnection expectedConnection =
                new DatabaseConnection(givenHostName, givenDatabaseName, givenUsername, givenPassword,
                    DefaultDatabaseEngine, DefaultDatabaseVersion);

            DatabaseConnection databaseConnection = DatabaseConnectionBuilder.CreateConnection()
                .WithHost(givenHostName)
                .WithDatabase(givenDatabaseName)
                .WithCredential(x =>
                {
                    x.Password = givenPassword;
                    x.Username = givenUsername;
                })
                .Connect();

            databaseConnection.Should().Be(expectedConnection,
                "builder should build the same object since same property is provided");
        }
    }
}