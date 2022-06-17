using Library.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Tours
{
    public interface ITourService
    {
        IList<TourDto> GetAllTours(string search = null);
        TourDto GetTourById(Guid id);
        TourDto EditTour(Guid id, InsertUpdateTourDto input);
        TourDto AddTour(InsertUpdateTourDto input);
        bool DeleteTour(Guid id);
        IList<TourDto> ReportTours(TourLookUpDto request);
        Booking GetOrder(Guid bookingId);
    }
}
