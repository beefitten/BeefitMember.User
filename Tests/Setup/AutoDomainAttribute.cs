using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Tests.Setup
{
    public class AutoDomainAttribute : AutoDataAttribute
    {
        public AutoDomainAttribute() : base(FixtureFactory)
        {
        }

        private static IFixture FixtureFactory()
        {
            var fixture = new Fixture();

            var fixtureFactory = fixture.Customize(new AutoMoqCustomization {ConfigureMembers = true});

            return fixtureFactory;
        }
    }
}