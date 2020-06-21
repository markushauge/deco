using WPFView = System.Windows.UIElement;

namespace Deco.WPF.Handlers {
    public abstract class AbstractViewHandler<TVirtualView, TNativeView> : IViewHandler<WPFView>
        where TVirtualView : class, IView
        where TNativeView : WPFView
    {
        private TVirtualView? _virtualView;
        private TNativeView? _nativeView;

        protected abstract TNativeView CreateView(TVirtualView virtualView);
        protected abstract void UpdateProperties(TVirtualView? oldVirtualView, TVirtualView newVirtualView, TNativeView nativeView);

        public WPFView Render(IView view) {
            var virtualView = (TVirtualView)view;

            if (_nativeView == null) {
                _nativeView = CreateView(virtualView);
            }

            UpdateProperties(_virtualView, virtualView, _nativeView);
            _virtualView = virtualView;
            return _nativeView;
        }
    }
}
