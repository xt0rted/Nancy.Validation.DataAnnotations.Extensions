namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    internal static class ShouldExtensions
    {
        public static void ShouldEqual(this object source, object control)
        {
            Assert.Equal(control, source);
        }

        public static void ShouldHave<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            Assert.True(list.Any(predicate));
        }

        public static void ShouldBeTrue(this bool source)
        {
            Assert.True(source);
        }

        public static void ShouldBeFalse(this bool source)
        {
            Assert.False(source);
        }
    }
}