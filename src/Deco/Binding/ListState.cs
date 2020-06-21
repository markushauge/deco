using System;
using System.Collections;
using System.Collections.Generic;

namespace Deco.Binding {
    public class ListState<T> : IList<T>, IBinding {
        private readonly IList<T> _state = new List<T>();

        public T this[int index] {
            get => _state[index];
            set {
                _state[index] = value;
                Changed?.Invoke();
            }
        }

        public int Count => _state.Count;
        public bool IsReadOnly => _state.IsReadOnly;
        public event Action? Changed;

        public void Add(T item) {
            _state.Add(item);
            Changed?.Invoke();
        }

        public void Clear() {
            _state.Clear();
            Changed?.Invoke();
        }

        public bool Contains(T item) => _state.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _state.CopyTo(array, arrayIndex);
        public int IndexOf(T item) => _state.IndexOf(item);

        public void Insert(int index, T item) {
            _state.Insert(index, item);
            Changed?.Invoke();
        }

        public bool Remove(T item) {
            var result = _state.Remove(item);
            Changed?.Invoke();
            return result;
        }

        public void RemoveAt(int index) {
            _state.RemoveAt(index);
            Changed?.Invoke();
        }

        public IEnumerator<T> GetEnumerator() => _state.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
