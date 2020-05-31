using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Reactor.Binding {
    public class BindingRegistry : Dictionary<Type, Func<object, IEnumerable<IBinding>>> {
        public static readonly BindingRegistry Default = new BindingRegistry();

        private static readonly ParameterExpression ObjectParameter = Expression.Parameter(typeof(object));

        private static Func<object, IBinding> CreateGetter(Type type, FieldInfo fieldInfo) {
            var expression = Expression.Lambda<Func<object, IBinding>>(
                Expression.Field(
                    Expression.Convert(ObjectParameter, type),
                    fieldInfo
                ),
                ObjectParameter
            );

            return expression.Compile();
        }
        
        public void Register(Type type) {
            var getters = type
                .GetFields(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance
                )
                .Where(fieldInfo => typeof(IBinding).IsAssignableFrom(fieldInfo.FieldType))
                .Select(fieldInfo => CreateGetter(type, fieldInfo));

            this[type] = target => getters.Select(getter => getter(target));
        }

        public IEnumerable<IBinding> GetBindings(object target) {
            var type = target.GetType();

            if (!ContainsKey(type)) {
                Register(type);
            }

            return this[type](target);
        }
    }
}
