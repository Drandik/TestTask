using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.signal.impl;
using UnityEngine;

public class MainContextView : ContextView
{
    private void Awake()
    {
        var context = new MainContext(this);
        context.Start();
    }
}
