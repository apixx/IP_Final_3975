using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IP_Final_3975.Models
{
    public class SportRepo : ISportRepo
    {
        private readonly IPFinalContext _context;

        public SportRepo(IPFinalContext context)
        {
            _context = context;
        }

        public IEnumerable<Sport> GetSports()
        {
            return _context.Sport.ToList();
        }
    }
}
