using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSetting : MonoBehaviour
{
    public void OnValueChange()
    {
        var dropDown = this.GetComponent<Dropdown>();
        QualitySettings.SetQualityLevel(dropDown.value);
    }
}
