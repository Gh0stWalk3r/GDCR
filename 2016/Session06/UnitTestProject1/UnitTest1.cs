namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void UnderPopulation_IsDead()
        {
            var cell = Cell.Alive;
            cell.AddAliveNeighbours(NeighbourCount.One);
            var status = cell.Mutate();
            Assert.Equal(CellStatus.Dead, status);
        }

        [Fact]
        public void Survival_TwoNeighbours_IsAlive()
        {
            var cell = Cell.Alive;
            cell.AddAliveNeighbours(NeighbourCount.Two);
            var status = cell.Mutate();
            Assert.Equal(CellStatus.Alive, status);
        }

        [Fact]
        public void Survival_ThreeNeighbours_IsAlive()
        {
            var cell = Cell.Alive;
            cell.AddAliveNeighbours(NeighbourCount.Three);
            var status =  cell.Mutate();
            Assert.Equal(CellStatus.Alive, status);
        }

        [Fact]
        public void Overcrowding_IsDead()
        {
            var cell = Cell.Alive;
            cell.AddAliveNeighbours(NeighbourCount.Eight);
            var status = cell.Mutate();
            Assert.Equal(CellStatus.Dead, status);
        }

        [Fact]
        public void Reproduction_IsAlive()
        {
            var cell = Cell.Dead;
            cell.AddAliveNeighbours(NeighbourCount.Three);
            var status = cell.Mutate();
            Assert.Equal(CellStatus.Alive, status);
        }
    }

    public class AliveCell : Cell
    {
        public AliveCell()
        {
           
        }
    }

    public class DeadCell : Cell
    {
        public DeadCell()
        {
           
        }
    }

    public class Cell
    {
        public static Cell Alive => new AliveCell();
        public static Cell Dead => new DeadCell();

        private List<Cell> _neighbours  = new List<Cell>();

        public void AddNeighbours(NeighbourCount neihghboursCount, CellStatus cellStatus)
        {
            for (int i = 0; i < (int)neihghboursCount; i++)
            {
                AddNeighbour(CellFactory(cellStatus).AddNeighbour(this));
            }
        }

        private static Cell CellFactory(CellStatus cell)
        {
            return CellStatus.Alive == cell ? Alive : Dead;
        }

        public void AddAliveNeighbours(NeighbourCount neihghboursCount)
        {
            AddNeighbours(neihghboursCount, CellStatus.Alive);
        }

        public NeighbourCount NeighboursCount()
        {
            return (NeighbourCount)_neighbours.Count(IsAlive);
        }

        private bool IsAlive(Cell cell)
        {
            return   cell is AliveCell;
        }
      
        private Cell AddNeighbour(Cell cell)
        {
            _neighbours.Add(cell);
            return this;
        }

        public Cell Mutate()
        {
            UnderPopulation();
            Survival();
            Overcrowding();
            var cell = Reproduction();
            return cell;
        }

        private Cell Reproduction()
        {
            if (!IsAlive(this)) return this;
            if (NeighboursCount() == NeighbourCount.Three)
                return (AliveCell)this;
               
        }

        private void Overcrowding()
        {
            if (!IsAlive(this)) return;
            if (NeighboursCount() > NeighbourCount.Three) return (DeadCell)this;
        }

        private void Survival()
        {
            if (Status != CellStatus.Alive) return;
            if (NeighboursCount() == NeighbourCount.Two)
                Status = CellStatus.Alive;
        }

        private void UnderPopulation()
        {
            if (Status != CellStatus.Alive) return;
            if (NeighboursCount() < NeighbourCount.Two)
                Status = CellStatus.Dead;
        }
    }

    public enum NeighbourCount
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        five,
        Six,
        Seven,
        Eight
    }

    public enum CellStatus
    {
        Alive,
        Dead
    }
}
