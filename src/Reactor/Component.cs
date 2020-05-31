namespace Reactor {
    public abstract class Component : IView {
        public abstract IView? Render();
        public virtual void OnMount() { }
        public virtual void OnUnmount() { }
    }
}
