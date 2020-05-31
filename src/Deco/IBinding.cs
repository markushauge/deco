using System;

namespace Deco {
    public interface IBinding {
        event Action? Changed;
    }
}
