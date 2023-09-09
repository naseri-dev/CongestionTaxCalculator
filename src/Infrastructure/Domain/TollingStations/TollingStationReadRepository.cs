using AutoMapper;
using Domain.Entities.TollingStations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TollingStations
{
    public class TollingStationReadRepository : BaseGenericReadRepository<TollingStation>, ITollingStationReadRepository
    {
        private readonly IMapper _mapper;
        public TollingStationReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}
