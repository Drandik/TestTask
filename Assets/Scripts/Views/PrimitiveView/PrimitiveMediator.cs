using strange.extensions.mediation.impl;
using UnityEngine;
using UniRx;
using System;

public class PrimitiveMediator : Mediator
{
    [Inject]
    public PrimitiveView View { get; set; }

    [Inject]
    public GameModel GameModel { get; set; }

    public override void OnRegister()
    {
        View.Init();

        Observable.Interval(TimeSpan.FromSeconds(GameModel.GameData.ObservableTime))
            .Subscribe(x => View.ChangeColor(UnityEngine.Random.ColorHSV(0f, 1f, .5f, 1f, 0f, 1f))).AddTo(this);
    }

    private void OnMouseDown()
    {
        View.model.ClickCount++;
        GeometryObjectData data = GameModel.GetObjectData(View.objectsType, View.model.ObjectType);
        foreach (var clickData in data.ClicksData)
            if (ValueInRange(View.model.ClickCount, clickData.MinClicksCount, clickData.MaxClicksCount)
                && View.model.ObjectColor != clickData.Color)
                View.ChangeColor(clickData.Color);

        Debug.Log("click " + View.model.ClickCount);
    }

    private bool ValueInRange(int value, int min, int max)
    {
        return value >= min && value <= max;
    }
}
