using System;

namespace AvaloniaBankAppEF.Services
{
    internal static class RandomExtentions
    {
        public static T NextItem<T> (this Random rnd, params T[] items) => items[rnd.Next(items.Length)];
    }
}
