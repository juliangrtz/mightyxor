using System.Collections.Generic;
using System.Linq;

namespace Amgine.UnitTests.Core.SecretSharing
{
    internal static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> SubSets<T>(this IEnumerable<T> source)
        {
            var enumerable = source as T[] ?? source.ToArray();
            if (!enumerable.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);

            var element = enumerable.Take(1);

            var haveNots = SubSets(enumerable.Skip(1));
            var haveNotsEnumerable = haveNots as IEnumerable<T>[] ?? haveNots.ToArray();
            var haves = haveNotsEnumerable.Select(set => element.Concat(set));

            return haves.Concat(haveNotsEnumerable);
        }
    }
}