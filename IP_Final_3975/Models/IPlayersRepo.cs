using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IP_Final_3975.Models
{
    public interface IPlayersRepo
    {
        IEnumerable<Players> GetPlayers();
        IEnumerable<Players> GetPlayers(int? id);
    }
}
