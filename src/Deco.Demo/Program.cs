using Deco.Demo.WPF;
using System;
using System.Windows;

namespace Deco.Demo {
    public class Program {
        [STAThread]
        public static void Main() {
            new Application().Run(new MainWindow());
        }
    }
}
