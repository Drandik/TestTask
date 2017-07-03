using System;
using strange.extensions.mediation.api;
using UnityEngine;

public class MainContext : SignalContext
{
    public MainContext(MonoBehaviour view)
        :base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();
        ViewBindings();
        CommandBindings();
        ModelBindings();
        ServiceBindings();
    }

    private void CommandBindings()
    {
        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
    }

    private void ModelBindings()
    {
        injectionBinder.Bind<GameModel>().ToSingleton();
    }

    private void ViewBindings()
    {
        mediationBinder.BindView<ClickCheckerView>().ToMediator<ClickCheckerMediator>();
        mediationBinder.BindView<PrimitiveView>().ToMediator<PrimitiveMediator>();
    }

    private void ServiceBindings()
    {
        injectionBinder.Bind<GetSettingsService>().ToSingleton();
    }
}