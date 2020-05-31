using Deco.Views;
using Deco.WPF.Binding;
using System;

namespace Deco.WPF.Components {
    public class ResourceView<TIn, TOut> : Component
        where TOut : class
    {
        private readonly TIn _input;
        private readonly Resource<TIn, TOut> _resource;

        public Func<IView?> RenderLoading { get; set; } = () => new Text("Loading...");
        public Func<TOut, IView?> RenderData { get; set; } = data => null;
        public Func<Exception, IView?> RenderException { get; set; } = ex => new Text(ex.Message);

        public ResourceView(TIn input, Resource<TIn, TOut> resource) {
            _input = input;
            _resource = resource;
        }

        public override async void OnMount() {
            await _resource.Load(_input);
        }

        public override IView? Render() {
            if (_resource.Loading) {
                return RenderLoading();
            }

            if (_resource.Exception != null) {
                return RenderException(_resource.Exception);
            }

            return RenderData(_resource.Data!);
        }
    }
}
