using System.Collections;
using System.Collections.Generic;

namespace Reactor.Views {
    public abstract class Container<T> : IView, IEnumerable<T> {
        public IList<T> Children { get; set; } = new List<T>();
        
        public void Add(T item) => Children.Add(item);
        public IEnumerator<T> GetEnumerator() => Children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
