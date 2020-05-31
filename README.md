# Reactor
Declarative and component based UI library for C#

## How it works

```csharp
public class App : Component {
    private readonly State<int> _count = 0;

    // Bindings ensure that the components are rerendered when state changes
    public override IEnumerable<IBinding> Bindings => new[] { _count };

    public override IView Render() =>
        new VStack {
            new HStack {
                new Button(" - ", () => _count.Value--),
                new Button(" + ", () => _count.Value++)
            },
            new Text($"Count: {_count.Value}")
        };
}
```

Reactor uses the [MVU](https://thomasbandt.com/model-view-update) pattern known from Elm and React, is built on the idea that "UI is a function of state".

## Other

Rendering architecture is heavily inspired by [Comet](https://github.com/Clancey/Comet).
