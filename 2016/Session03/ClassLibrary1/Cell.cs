using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Cell
    {
        public bool IsAlive { get; set; } = true;

        public List<Cell> Neighbours { get; } = new List<Cell>();

        public int AliveNeighbourCount => this.Neighbours.Count(cell1 => cell1.IsAlive);
    }
}
