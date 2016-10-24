namespace UnitTestProject1
{
    using System.Collections.Generic;

    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Mutate_WithAliveCellAndOneNeighbour_IsDead()
        {
            var cell = Cell.Alive;
            var neighbour = Neighbour.One;
            cell.Mutate(neighbour);
            Assert.Equal(cell.Status, CellStatus.Dead);
        }


        [Fact]
        public void Mutate_WithAliveCellAndTwoNeighbour_IsAlive()
        {
            var cell = Cell.Alive;
            var neighbour = Neighbour.Two;
            cell.Mutate(neighbour);
            Assert.Equal(cell.Status, CellStatus.Alive);
        }

        [Fact]
        public void Mutate_WithAliveCellAndThreeNeighbour_IsAlive()
        {
            var cell = Cell.Alive;
            var neighbour = Neighbour.Three;
            cell.Mutate(neighbour);
            Assert.Equal(cell.Status, CellStatus.Alive);
        }

        [Fact]
        public void Mutate_WithAliveCellAndForNeighbour_IsDead()
        {
            var cell = Cell.Alive;
            var neighbour = Neighbour.Four;
            cell.Mutate(neighbour);
            Assert.Equal(cell.Status, CellStatus.Dead);
        }
        [Fact]
        public void Mutate_WithDeadCellAndThreeNeighbour_IsAlive()
        {
            var cell = Cell.Dead;
            var neighbour = Neighbour.Three;
            cell.Mutate(neighbour);
            Assert.Equal(cell.Status, CellStatus.Alive);
        }

        [Fact]
        public void GetNeighbours_ThreeNeighbours_ThreeNeighbours()
        {
           
            Cell cell = Cell.Alive;
            var neighbour = Given(Neighbour.Three);
            cell.Neighbours = neighbour;
            cell.Mutate();
            Assert.Equal(cell.Status, CellStatus.Alive);
        }

        private static Neighbours Given(Neighbour three)
        {
            var world = new Neighbours();
            for (int i = 0; i < (int)three; i++)
                world.AddAlive();
            return world;
        }
    }

    internal class Neighbours
    {
        List<Cell> cells = new List<Cell>();

        public void AddRandomCell()
        {
            if (cells.Count % 2 == 0)
            {
                AddAlive();
                return;
            }
            AddDead();
        }

        public void AddAlive()
        {
            var c = Cell.Alive;
            cells.Add(c);
        }
        public void AddDead()
        {
            var c = Cell.Dead;
            cells.Add(c);
        }
    }

    public enum Neighbour
    {
        One,

        Two,

        Three,

        Four
    }

    public enum CellStatus
    {
        Dead,
        Alive
    }
    public class Cell
    {
        public static Cell Alive => new Cell(CellStatus.Alive);

        public static Cell Dead => new Cell(CellStatus.Dead);

        public CellStatus Status { get; private set; }

        public Neighbours Neighbours { get; set; }

        private Cell(CellStatus status)
        {
            this.Status = status;
        }

        public void Mutate()
        {
            UnderPopulation();
            Overcrowding();
            Reproduction();
            Survival();
        }

        private void UnderPopulation()
        {
            if (Neighbours.C < Neighbour.Two)
                Status = CellStatus.Dead;
        }
        private void Overcrowding(Neighbour neighbour)
        {
            if (neighbour > Neighbour.Three)
                Status = CellStatus.Dead;
        }

        private void Reproduction(Neighbour neighbour)
        {
            if (neighbour == Neighbour.Three)
                Status = CellStatus.Alive;
        }


        private void Survival(Neighbour neighbour)
        {
            if (Status == CellStatus.Dead) return;
            if (neighbour == Neighbour.Two)
                Status = CellStatus.Alive;
        }
    }
}
