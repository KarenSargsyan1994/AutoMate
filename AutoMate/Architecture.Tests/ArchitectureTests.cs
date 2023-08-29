using NetArchTest.Rules;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private readonly string DomainNamespace = "Domain";
        private readonly string ApplicationNamespace = "Application";
        private readonly string InfrastructureNamespace = "Infrastructure";
        private readonly string AppNamespace = "App";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange

            var assembly = typeof(Automate.Domain.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                AppNamespace,
                DomainNamespace,
                ApplicationNamespace,
                InfrastructureNamespace,
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}