using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayOfWeekServiceTests
    {
        private readonly DayOfWeekService _dayOfWeekService = new DayOfWeekService();

        [Test]
        public void IsWeekendPositiveLastWeekend()
        {
            var date = new DateTime(2020, 12, 27);
            _dayOfWeekService.IsWeekend(date).Should().Be(true);
        }

        [Test]
        public void IsWeekendPositiveYearAgo()
        {
            var date = new DateTime(2019, 12, 28);

            _dayOfWeekService.IsWeekend(date).Should().Be(true);
        }

        [Test]
        public void IsWeekendNegative()
        {
            var date = new DateTime(2020, 12, 29);

            _dayOfWeekService.IsWeekend(date).Should().Be(false);
        }

        [Test]
        public void IsWeekendNegativeYearAgo()
        {
            var date = new DateTime(2019, 12, 30);

            _dayOfWeekService.IsWeekend(date).Should().Be(false);
        }
    }
}