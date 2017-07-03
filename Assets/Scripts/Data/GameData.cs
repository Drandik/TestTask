using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    public int ObservableTime;
    public string JsonSettingsPath;
}
