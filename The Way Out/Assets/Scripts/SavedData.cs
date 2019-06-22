using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Data
{
    public bool isNew;
    public int Level, Life, Diamond;
    public bool speedUp, flash;
    public float graphics, music, sfx;
}

public class ShopData
{
    public bool speedUp, flash;
}

public class SettingData
{
    public float graphics, music, sfx;
}

[System.Serializable]
public class SavedData
{

    public Data _savedData;

    private string dataPath = "Assets/SavedData/Saved.json";
    private TextAsset file;

    public SavedData()
    {
        _savedData = JsonUtility.FromJson<Data>(ReadDataFile());
    }

    public string ReadDataFile()
    {
        return File.ReadAllText(dataPath);
    }

    public void OverwriteDataFile()
    {
        var jsonString = JsonUtility.ToJson(this._savedData);
        File.WriteAllText(dataPath, jsonString);
    }

    public void OverwriteDataFile(Data data)
    {
        var jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, jsonString);
    }
}
