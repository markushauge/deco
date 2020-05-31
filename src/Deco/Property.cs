using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Deco {
    public class Property<T> {
        private readonly Func<T> _get;
        private readonly Action<T> _set;

        public T Value {
            get => _get();
            set => _set(value);
        }

        public Property(Func<T> get, Action<T> set) {
            _get = get;
            _set = set;
        }
    }

    public static class PropertyExtensions {
        private static T CreateDelegate<T>(this MethodInfo methodInfo, object target) where T : Delegate =>
            (T)methodInfo.CreateDelegate(typeof(T), target);

        public static Property<TValue> GetProperty<TValue, TTarget>(this TTarget target, Expression<Func<TTarget, TValue>> expression) {
            var memberExpression = (MemberExpression)expression.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;
            return propertyInfo.ToProperty<TValue>(target!);
        }

        public static Property<T> ToProperty<T>(this PropertyInfo propertyInfo, object target) =>
            new Property<T>(propertyInfo.GetGetter<T>(target), propertyInfo.GetSetter<T>(target));

        public static Func<T> GetGetter<T>(this PropertyInfo propertyInfo, object target) =>
            propertyInfo.GetGetMethod().CreateDelegate<Func<T>>(target);

        public static Action<T> GetSetter<T>(this PropertyInfo propertyInfo, object target) =>
            propertyInfo.GetSetMethod().CreateDelegate<Action<T>>(target);
    }
}
