using System;

namespace Reactor.Binding {
    public class State<T> : IState<T> {
        public static implicit operator State<T>(T value) => new State<T>(value);

        private T _value;

        public event Action? Changed;

        public State(T value) {
            _value = value;
        }

        public virtual T Value {
            get => _value;
            set {
                _value = value;
                Changed?.Invoke();
            }
        }
    }
}
