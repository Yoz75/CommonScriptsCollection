
using System;
using System.Collections.Generic;

namespace CSC
{
    /// <summary>
    /// Helper class to select elements from collections based on element weights
    /// </summary>
    /// <typeparam name="TCollection">Collection type</typeparam>
    /// <typeparam name="TElement">Element type</typeparam>
    public static class WeightedSelect<TCollection, TElement>
        where TCollection : IEnumerable<TElement>
        where TElement : IWeighted
    {
        private static Random Random = new();

        /// <summary>
        /// Select a random element from a collection based on the element weights
        /// </summary>
        public static TElement SelectRandom(TCollection collection)
        {
            int totalWeight = 0;
            foreach(var element in collection)
            {
                int weight = element.Weight;
                if(weight > 0)
                    totalWeight += weight;
            }

            if(totalWeight <= 0)
                throw new InvalidOperationException("All weights are zero or negative.");

            int target = Random.Next(totalWeight);

            foreach(var element in collection)
            {
                int weight = element.Weight;
                if(weight <= 0) continue;

                if(target < weight)
                    return element;

                target -= weight;
            }

            throw new InvalidOperationException("Selection failed.");
        }
    }
}