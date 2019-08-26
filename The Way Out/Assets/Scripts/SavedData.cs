using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[System.Serializable]
public class Data
{
    public string something;
    public bool isNew;
    public int level, life, diamond;
    public bool speedUp, flash;
    public int graphics;
    public float music, sfx;
}

//[System.Serializable]
public class SavedData
{
    public Data _savedData;

    private string savedDataPath;
    private TextAsset savedDataFile;

    public SavedData()
    {
        savedDataPath = Path.Combine(Application.streamingAssetsPath, "Saved.txt");
        _savedData = JsonUtility.FromJson<Data>(ReadDataFile());
    }

    public string ReadDataFile()
    {
        return File.ReadAllText(savedDataPath);
    }

    public void OverwriteDataFile()
    {
        var jsonString = JsonUtility.ToJson(_savedData);
        File.WriteAllText(savedDataPath, jsonString);
    }

    public void ResetProgress()
    {
        _savedData.level = 0;
        _savedData.life = 2;
        _savedData.diamond = 0;
        _savedData.speedUp = false;
        _savedData.flash = false;
        OverwriteDataFile();
    }
}
