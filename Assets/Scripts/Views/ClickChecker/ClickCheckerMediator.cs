using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class ClickCheckerMediator : Mediator
{
    [Inject]
    public ClickCheckerView View { get; set; }

    [Inject]
    public GameModel GameModel { get; set; }

    public override void OnRegister()
    {
        View.Init();
        View.ClickSignal.AddListener(ClickLogic);
    }

    public override void OnRemove()
    {
        View.ClickSignal.RemoveListener(ClickLogic);
    }

    private void ClickLogic(Ray mouseRay)
    {
        if (!GameModel.SettingsLoaded)
            return;

        if (!Physics.Raycast(mouseRay.origin, mouseRay.direction, View.depth * 2))
        {
            InstantiateObject(mouseRay.origin + mouseRay.direction * View.depth);

        }
        
    }

    private void InstantiateObject(Vector3 position)
    {
        GameObject prefab = GameModel.GetRandomPrefab(View.keyForObjects);
        GameObject go = Instantiate(prefab, View.transform);
        go.transform.position = position;
        go.GetComponent<PrimitiveView>().SetData(prefab.name, View.keyForObjects);
    }
}
