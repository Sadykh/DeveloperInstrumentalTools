using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayShiftServiceTests
    {
        private readonly DayShiftService _dayShiftService = new DayShiftService(new DayOfWeekService());

        [Test]
        public void GetShiftBusinessDaySubtract()
        {
            var fromDate = new DateTime(2020, 12, 29);
            var resultDate = new DateTime(2019, 12, 30);

            _dayShiftService.GetShiftBusinessDay(fromDate, -365).Should().Be(resultDate);
        }

        [Test]
        public void GetShiftBusinessDayAdd()
        {
            var fromDate = new DateTime(2019, 12, 30);

            var resultDate = new DateTime(2020, 12, 29);

            _dayShiftService.GetShiftBusinessDay(fromDate, 365).Should().Be(resultDate);
        }

        [Test]
        public void GetShiftBusinessDayZero()
        {
            var fromDate = new DateTime(2020, 12, 29);
            var resultDate = new DateTime(2020, 12, 29);

            _dayShiftService.GetShiftBusinessDay(fromDate, 0).Should().Be(resultDate);
        }

        [Test]
        public void GetShiftBusinessDayOneAdd()
        {
            var fromDate = new DateTime(2020, 12, 29);
            var resultDate = new DateTime(2020, 12, 30);

            _dayShiftService.GetShiftBusinessDay(fromDate, 1).Should().Be(resultDate);
        }

        [Test]
        public void GetShiftBusinessDayOneSubstract()
        {
            var fromDate = new DateTime(2020, 12, 29);
            var resultDate = new DateTime(2020, 12, 28);

            _dayShiftService.GetShiftBusinessDay(fromDate, -1).Should().Be(resultDate);
        }
    }
}