using Reactor.Binding;
using System.Windows;

namespace Reactor.WPF.Binding {
    public class AsyncState<T> : State<T> {
        public static implicit operator AsyncState<T>(T value) => new AsyncState<T>(value);
         
        public AsyncState(T value) : base(value) { }

        public override T Value {
            set {
                Application.Current.Dispatcher.Invoke(() => {
                    base.Value = value;
                });
            }
        }
    }
}
