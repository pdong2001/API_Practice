using AutoMapper;
using Library.DataAccesLayer;
using Library.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Tours
{
    public class TourService : ITourService
    {
        private readonly ToursDB _dbContext;
        private readonly IMapper mapper;

        public TourService(ToursDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public TourDto AddTour(InsertUpdateTourDto input)
        {
            var entity = mapper.Map<InsertUpdateTourDto, Tour>(input);
            _dbContext.Tours.Add(entity);
            if (_dbContext.SaveChanges() > 0)
            {
                return mapper.Map<Tour, TourDto>(entity);
            }
            else
            {
                return null;
            }
        }

        public bool DeleteTour(Guid id)
        {
            _dbContext.Tours.Remove(_dbContext.Tours.Find(id));
            return _dbContext.SaveChanges() > 0;
        }

        public TourDto EditTour(Guid id, InsertUpdateTourDto input)
        {
            var tour = _dbContext.Tours.Find(id);
            if (tour == null) return null;
            tour = mapper.Map<InsertUpdateTourDto, Tour>(input, tour);
            if (_dbContext.SaveChanges() > 0)
            {
                return mapper.Map<Tour, TourDto>(tour);
            }
            return null;
        }

        public IList<TourDto> GetAllTours(string search = null)
        {
            var query = _dbContext.Tours.AsQueryable();
            var tours = query.ToList();
            if (search != null)
            {
                var searchKeys = search.ToLower().Split(" ");
                tours = tours.Where(t => searchKeys.All(k => t.Name.ToLower().Contains(k))).ToList();
            }
            return tours.Select(t => mapper.Map<Tour, TourDto>(t)).ToList();
        }

        public Booking GetOrder(Guid bookingId)
        {
            return _dbContext.Bookings
                .Include(t => t.Tour)
                .Include(t => t.Customer)
                .FirstOrDefault(b => b.Id == bookingId);
        }

        public TourDto GetTourById(Guid id)
        {
            var tour = _dbContext.Tours.Find(id);
            if (tour == null) return null;
            return mapper.Map<Tour, TourDto>(tour);
        }

        public IList<TourDto> ReportTours(TourLookUpDto request)
        {
            var query = _dbContext.Tours.Include(t => t.Bookings);
            var tours = query.Where(t => !t.Bookings.Any(
                b => (b.CheckInDate >= request.CheckInDate &&
                b.CheckInDate <= request.CheckOutDate) ||
                (b.CheckOutDate <= request.CheckOutDate && b.CheckOutDate >= request.CheckInDate)
                )).ToList();
            return tours.Select(t => mapper.Map<Tour, TourDto>(t)).ToList();
        }
    }
}
