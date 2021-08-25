using System.Collections.Generic;

namespace BL.Models
{
    public sealed class Position
    {
        public static IReadOnlyCollection<string> Positions { get; } = new [] { "Developer", "Tester", "Business analyst", "Manager" };
    }
}
