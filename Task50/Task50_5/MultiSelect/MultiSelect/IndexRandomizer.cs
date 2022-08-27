using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSelect
{
    public class IndexRandomizer
    {
        public static int[] GetRandomIndexes(int availableQty, int indexQtyLimit)
        {
            Random rnd = new Random();
            int randomValue = 0;
            int indexCounter = 0;
            int[] indexes = new int[indexQtyLimit];
            while (indexCounter < indexQtyLimit)
            {
                while (Array.Find<int>(indexes, i => i == randomValue) == randomValue)
                {
                    randomValue = rnd.Next(0, availableQty - 1);
                }
                indexes[indexCounter] = randomValue;
                indexCounter++;
            }
            return indexes;
        }
    }
}
