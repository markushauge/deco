using System;
using System.Reflection;
using System.Windows.Controls;

namespace Deco.WPF {
    public abstract class ViewHost : ContentControl {
        protected abstract Assembly Assembly { get; }
        protected abstract string Namespace { get; }

        public string View {
            set => Render(value);
        }

        protected void Render(string name) {
            var type = Assembly.GetType($"{Namespace}.{name}");

            if (type == null) {
                throw new Exception($"Could not find {name}");
            }

            var view = (IView)Activator.CreateInstance(type)!;
            Content = ViewHandlerRegistry.Default.Render(view);
        }
    }
}
