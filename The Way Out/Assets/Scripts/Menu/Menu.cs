using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public struct PlayerData
{
    public bool IsNew;
    public int Level, Life, Diamond;
}

public struct SettingData
{
    public int Graphics, Music, SFX;
}

public struct SavedData
{
    public PlayerData playerData;
    public SettingData settingData;
}

public class Menu : MonoBehaviour
{
    public TextAsset dataFile;

    public SavedData savedData;
    // Start is called before the first frame update
    void Start()
    {
        savedData = new SavedData();
        LoadSavedData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSavedData()
    {
        
        var data = dataFile.text;
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(data));

        var xmlPath = "//data/player";
        XmlNodeList nodeList = xmlDoc.SelectNodes(xmlPath);

        foreach (XmlNode node in nodeList)
        {
            var isNew = node.FirstChild;
            var level = isNew.NextSibling;
            var life = level.NextSibling;
            var diamond = life.NextSibling;

            savedData.playerData.IsNew = isNew.InnerText == "1" ? true : false;
            savedData.playerData.Level = int.Parse(level.InnerText);
            savedData.playerData.Life = int.Parse(life.InnerText);
            savedData.playerData.Diamond = int.Parse(diamond.InnerText);
        }

        xmlPath = "//data/setting";
        nodeList = xmlDoc.SelectNodes(xmlPath);

        foreach (XmlNode node in nodeList)
        {
            var graphics = node.FirstChild;
            var music = graphics.NextSibling;
            var sfx = music.NextSibling;

            savedData.settingData.Graphics = int.Parse(graphics.InnerText);
            savedData.settingData.Music = int.Parse(music.InnerText);
            savedData.settingData.SFX = int.Parse(sfx.InnerText);
        }
    }
}
