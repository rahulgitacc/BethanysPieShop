using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).ToList();
            }
        }

        public IEnumerable<Pie> PiesOfTheWeeks
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }

        }

        public Pie GetPieById(int pieId) => _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
    }
}