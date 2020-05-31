using Reactor.Binding;
using System;
using System.Threading.Tasks;

namespace Reactor.WPF.Binding {

    public class Resource<TIn, TOut> : BindingObject
        where TOut : class
    {
        private readonly struct ResourceState {
            public static ResourceState FromLoading(bool loading) =>
                new ResourceState(loading, null, null);

            public static ResourceState FromData(TOut? data) =>
                new ResourceState(false, data, null);

            public static ResourceState FromException(Exception? exception) =>
                new ResourceState(false, null, exception);

            public readonly bool Loading;
            public readonly TOut? Data;
            public readonly Exception? Exception;

            public ResourceState(bool loading, TOut? data, Exception? exception) {
                Loading = loading;
                Data = data;
                Exception = exception;
            }
        }

        public static implicit operator Resource<TIn, TOut>(Func<TIn, Task<TOut>> execute) =>
            new Resource<TIn, TOut>(execute);

        private readonly AsyncState<ResourceState> _state = ResourceState.FromLoading(false);
        private readonly Func<TIn, Task<TOut>> _execute;

        public bool Loading => _state.Value.Loading;
        public TOut? Data => _state.Value.Data;
        public Exception? Exception => _state.Value.Exception;

        public Resource(Func<TIn, Task<TOut>> execute) {
            _execute = execute;
        }

        public async Task Load(TIn input) {
            _state.Value = ResourceState.FromLoading(true);

            try {
                _state.Value = ResourceState.FromData(await _execute(input));
            } catch (Exception ex) {
                _state.Value = ResourceState.FromException(ex);
            }
        }
    }
}
