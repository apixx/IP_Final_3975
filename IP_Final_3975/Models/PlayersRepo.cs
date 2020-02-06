using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IP_Final_3975.Models
{
    public class PlayersRepo : IPlayersRepo
    {
        private readonly IPFinalContext _context;

        public PlayersRepo(IPFinalContext context)
        {
            _context = context;
        }

        public IEnumerable<Players> GetPlayers()
        {
            return _context.Players.ToList();
        }

        public IEnumerable<Players> GetPlayers(int? id)
        {
            return _context.Players.Where(p => p.FkSportId == id).ToList();
        }
    }
}
