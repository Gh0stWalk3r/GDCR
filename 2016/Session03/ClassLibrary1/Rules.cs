using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Rules
    {
        public bool UnderPopulation(Cell cell)
        {
            return cell.IsAlive && cell.AliveNeighbourCount < 2;
        }

        public bool Survival(Cell cell)
        {
            var activeNeighbours = cell.AliveNeighbourCount;
            return cell.IsAlive && (activeNeighbours == 2 || activeNeighbours == 3);
        }

        public bool Overcrowd(Cell cell)
        {
            var activeNeighbours = cell.AliveNeighbourCount;
            return cell.IsAlive && activeNe
        }
    }
}
