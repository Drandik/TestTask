using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class AppStartCommand : Command
{
    [Inject]
    public GameModel GameModel { get; set; }

    public override void Execute()
    {
        Debug.Log("App started ");
        Retain();
        WWW www = new WWW(GameModel.GameData.JsonSettingsPath);
        RoutineRunner.Instance.StartCoroutine(LoadBundlesCoroutine(www));
    }

    private IEnumerator LoadBundlesCoroutine(WWW www)
    {
        yield return www;
        List<JsonObject> objects = new List<JsonObject>();
        if (string.IsNullOrEmpty(www.error))
        {
            string serviceData = www.text;
            objects = JsonConvert.DeserializeObject<List<JsonObject>>(serviceData);
        }
        else
        {
            Debug.Log("Failed to load json! Error: " + www.error);
            Release();
            yield return null;
        }

        foreach (var obj in objects)
        {
            string path;
            if (string.IsNullOrEmpty(obj.Path))
                path = Application.dataPath + "/AssetBundles/";
            else
                path = obj.Path;
            string uri = Path.Combine(path, obj.Name);

            UnityWebRequest request = UnityWebRequest.GetAssetBundle(uri, 0);
            yield return request.Send();
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (bundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                Release();
                yield return null;
            }

            GameModel.SetPrefabs(obj.Name, bundle.LoadAllAssets<GameObject>());
            SetObjectsSettings(obj.Name, bundle.GetAllAssetNames());
        }

        Release();
        GameModel.SettingsReady();
    }

    private void SetObjectsSettings(string resourceName, string[] prefabsName)
    {
        List<GeometryObjectData> datas = new List<GeometryObjectData>();
        for (int i = 0; i < prefabsName.Length; i++)
        {
            var data = Resources.Load<GeometryObjectData>(resourceName + "/" + Path.GetFileNameWithoutExtension(prefabsName[i])
                + "/" + Path.GetFileNameWithoutExtension(prefabsName[i]));
            datas.Add(data);
        }
        GameModel.SetObjectsSettings(resourceName, datas.ToArray());
    }

    class JsonObject
    {
        public string Path;
        public string Name;
    }
}
