using BusinessAccessLayer.Services;
using Moq;
using System;
using Xunit;
using System.Collections.Generic;
namespace UnitTests
{
    public class BusinessServiceUnitTests
    {
        BookedDatesService bookedDatesService = new BookedDatesService();

        [Fact]
        public void Test_GetAllBookedDays()
        {
            var result= bookedDatesService.GetBookingDatesRange(new DateTime(2019, 1, 8), new DateTime(2019, 1, 13)).Count;

            Assert.Equal(6, result);
        }
    }
}
