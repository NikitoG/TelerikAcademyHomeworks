namespace RefactorIfStatement
{
    using System;

    public class RefactorIfStatements
    {
        // Potato potato;
        // ... 
        // if (potato != null)
        //     if (!potato.HasNotBeenPeeled && !potato.IsRotten)
        //         Cook(potato);
        public static void Cookoing()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                bool isPeeled = potato.IsPeeled;
                bool isRotten = potato.IsRotten;

                if (isPeeled && !isRotten)
                {
                    Cook(potato);
                }
            }
        }

        public static void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }

        // if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
        // {
        //    VisitCell();
        // }
        public void Move(int x, int y)
        {
            const int MinX = 1;
            const int MaxX = 100;
            const int MinY = 1;
            const int MaxY = 100;

            bool shouldVisitCell = true;
            bool isInRange = this.CheckIsInRange(x, MinX, MaxX) && this.CheckIsInRange(y, MinY, MaxY);

            if (isInRange && shouldVisitCell)
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }

        private bool CheckIsInRange(int coor, int min, int max)
        {
            if (coor < min || max < coor)
            {
                return false;
            }

            return true;
        }
    }
}
