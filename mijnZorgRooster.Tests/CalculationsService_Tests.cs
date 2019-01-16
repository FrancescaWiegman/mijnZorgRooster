using System;
using Xunit;
using mijnZorgRooster.Services;

namespace mijnZorgRooster.Tests
{
    public class CalculationsService_Tests
    {
        private readonly Services.CalculationsService _calculationsService;

        public CalculationsService_Tests()
        {
            _calculationsService = new Services.CalculationsService(null);
        }

        [Fact]
        public void BerekenLeeftijdInJaren_DateTime_ReturnsInteger()
        {
            // TODO: Deze test is eigenlijk niet goed omdat hij niet repeatable is. Na 17 september klopt hij niet meer.
            var result = _calculationsService.BerekenLeeftijdInJaren(DateTime.Parse("17 september 1977"));

            Assert.True(result == 41);
        }
    }
}
