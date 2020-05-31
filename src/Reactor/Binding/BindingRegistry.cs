using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Reactor.Binding {
    public class BindingRegistry {
        private static readonly ParameterExpression ObjectParameter = Expression.Parameter(typeof(object));

        private static Expression<Func<object, IBinding>> CreateExpession(Type type, FieldInfo fieldInfo) =>
            Expression.Lambda<Func<object, IBinding>>(
                Expression.Field(
                    Expression.Convert(ObjectParameter, type),
                    fieldInfo
                ),
                ObjectParameter
            );

        private static Func<object, IEnumerable<IBinding>> CreateGetter(Type type) {
            var getters = type
                .GetFields(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance
                )
                .Where(fieldInfo => typeof(IBinding).IsAssignableFrom(fieldInfo.FieldType))
                .Select(fieldInfo => CreateExpession(type, fieldInfo).Compile());

            return target => getters.Select(getter => getter(target));
        }

        private readonly IDictionary<Type, Func<object, IEnumerable<IBinding>>> _registry =
            new Dictionary<Type, Func<object, IEnumerable<IBinding>>>();
        
        public IEnumerable<IBinding> this[object target] {
            get {
                var type = target.GetType();

                if (!_registry.ContainsKey(type)) {
                    _registry[type] = CreateGetter(type);
                }

                return _registry[type].Invoke(target);
            }
        }
    }
}
