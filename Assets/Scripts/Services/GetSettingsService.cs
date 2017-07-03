using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class GetSettingsService
{
    [Inject]
    public GameModel GameModel { get; set; }
    
    public void GetJson()
    {
        WWW www = new WWW(GameModel.GameData.JsonSettingsPath);
        RoutineRunner.Instance.StartCoroutine(GetdataEnumerator(www));
    }

    IEnumerator GetdataEnumerator(WWW www)
    {
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            string serviceData = www.text;
            List<JsonObject> objects = JsonConvert.DeserializeObject<List<JsonObject>>(serviceData);
            Debug.Log("json " + objects[0].Name);
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    public class JsonObject
    {
        public string Path;
        public string Name;
    }
}
