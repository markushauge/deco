using Deco.Styling;

namespace Deco.Views {
    public class View : IView {
        public float Margin { get; set; } = 0;
        public float Padding { get; set; } = 0;
        public ColorProperties Colors { get; set; } = ColorProperties.Default;
        public BorderProperties Border { get; set; } = BorderProperties.Default;
    }
}
