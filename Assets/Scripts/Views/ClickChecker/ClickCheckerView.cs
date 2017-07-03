using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class ClickCheckerView : View
{
    [SerializeField]
    private Camera mainCamera;
    public string keyForObjects = "objects";
    public int depth = 50;

    internal Signal<Ray> ClickSignal = new Signal<Ray>();

    internal void Init()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickSignal.Dispatch(mainCamera.ScreenPointToRay(Input.mousePosition));
        }
        Debug.DrawRay(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
            mainCamera.ScreenPointToRay(Input.mousePosition).direction * 2* depth);
    }
}
