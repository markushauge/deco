using Reactor.Demo.WPF;
using System;
using System.Windows;

namespace Reactor.Demo {
    public class Program {
        [STAThread]
        public static void Main() {
            new Application().Run(new MainWindow());
        }
    }
}
