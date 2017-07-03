using strange.extensions.mediation.impl;
using UnityEngine;

public class PrimitiveView : View
{
    internal GeometryObjectModel model;
    internal string objectsType;

    private MeshRenderer render;

    internal void Init()
    {
        render = GetComponent<MeshRenderer>();
        model.ObjectColor = render.material.color;
        model.ClickCount = 0;
    }

    internal void ChangeColor(Color newColor)
    {
        render.material.color = newColor;
        model.ObjectColor = render.material.color;
    }

    public void SetData(string primitiveType, string groupsType)
    {
        objectsType = groupsType;
        model = new GeometryObjectModel();
        model.ObjectType = primitiveType;
    }
}
