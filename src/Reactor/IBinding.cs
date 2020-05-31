using System;

namespace Reactor {
    public interface IBinding {
        event Action? Changed;
    }
}
