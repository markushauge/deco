using System;
using System.Collections.Generic;
using System.Linq;

namespace Deco {
    public static class ReflectionExtensions {
        public static IEnumerable<Type> GetTypes(this Type type) =>
            Enumerable.Concat(
                type.GetBaseTypes(),
                type.GetInterfaces()
            );

        public static IEnumerable<Type> GetBaseTypes(this Type? type) {
            while (type != null) {
                yield return type;
                type = type.BaseType;
            }
        }
    }
}
