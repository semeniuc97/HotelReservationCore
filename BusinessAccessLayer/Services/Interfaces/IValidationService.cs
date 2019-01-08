using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IValidationService
    {
        bool ValidateHotelName(string word);
        bool ValidateIsNumber(string word);
        bool ValidateIsPrice(string word);
        bool ValidateBookingDates(DateTime StartDate, DateTime EndDate);
        bool ValidateFoundationYear(DateTime foundationYear);
        bool ValidateRatingBookingDates(DateTime StartDate, DateTime EndDate);
    }
}
