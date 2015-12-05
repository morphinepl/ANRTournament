using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace ANRTournament.Objects
{

    public static class ObservableCollectionExtensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static bool IsUniquePlayer(this IList<Game> elements)
        {
            return (from el1 in elements select el1.Player1Id).Union(from el2 in elements select el2.Player2Id).Distinct().Count() == (elements.Count() * 2);

        }
    }



    //public static class ObservableCollectionExtensions
    //{
    //    public static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> elements, int k)
    //    {
    //        List<T[]> result = new List<T[]>();

    //        if (k == 0)
    //        {
    //            // single combination: empty set
    //            result.Add(new T[0]);
    //        }
    //        else
    //        {
    //            int current = 1;
    //            foreach (T element in elements)
    //            {
    //                // combine each element with (k - 1)-combinations of subsequent elements
    //                result.AddRange(elements
    //                    .Skip(current++)
    //                    .Combinations(k - 1)
    //                    .Select(combination => (new T[] { element }).Concat(combination).ToArray())
    //                    );
    //            }
    //        }

    //        return result;
    //    }
    //}
}
