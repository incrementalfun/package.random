using System;
using System.Threading;

namespace Incremental.Common.Random
{
    /// <summary>
    ///     Random provider thanks to https://csharpindepth.com/Articles/Random
    /// </summary>
    public static class RandomProvider
    {
        private static int _seed = Environment.TickCount;

        private static readonly ThreadLocal<System.Random> RandomWrapper = new(() => new System.Random(Interlocked.Increment(ref _seed)));

        /// <summary>
        ///     Retrieve a local (as in thread) random provider.
        /// </summary>
        /// <returns>An instance of <see cref="Random" />.</returns>
        public static System.Random? GetThreadRandom()
        {
            return RandomWrapper.Value;
        }
    }
}