using UnityEngine;
using System.Collections.Generic;

public class GameModel
{
    public readonly GameData GameData;
    private Dictionary<string, GameObject[]> objectsPrefabs = new Dictionary<string, GameObject[]>();
    private Dictionary<string, GeometryObjectData[]> objectsSettings = new Dictionary<string, GeometryObjectData[]>();
    public bool SettingsLoaded { get; private set; }

    public GameModel()
    {
        GameData = Resources.Load<GameData>("GameData");
        SettingsLoaded = false;
        if (GameData == null)
            Debug.LogError("Can't load game data");
    }

    public void SetPrefabs(string key, GameObject[] prefabs)
    {
        if (prefabs != null && prefabs.Length > 0)
        {
            objectsPrefabs[key] = prefabs;
            Debug.Log("Success ");
        }
        else
            Debug.Log("Failed Load prefabs");
    }

    public void SetObjectsSettings(string key ,GeometryObjectData[] settings)
    {
        objectsSettings[key] = settings;
    }

    public void SettingsReady()
    {
        SettingsLoaded = true;
    }

    public GameObject GetRandomPrefab(string key)
    {
        return objectsPrefabs[key][Random.Range(0, objectsPrefabs[key].Length)];
    }

    public GeometryObjectData GetObjectData(string key, string objectType)
    {
        foreach (var objectData in objectsSettings[key])
        {
            if (string.Compare(objectData.ObjectType, objectType) == 0)
                return objectData;
        }
        return null;
    }
}
