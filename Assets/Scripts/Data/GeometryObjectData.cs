using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/GeometryObjectData")]
public class GeometryObjectData: ScriptableObject
{
    public string ObjectType;

    public List<ClickColorData> ClicksData;
}
