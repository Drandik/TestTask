using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ClickColorData")]
public class ClickColorData : ScriptableObject
{
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color Color;
}
