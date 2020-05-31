namespace Deco {
    public interface IViewHandler<TNativeView>
        where TNativeView : class
    {
        TNativeView Render(IView view);
    }
}
