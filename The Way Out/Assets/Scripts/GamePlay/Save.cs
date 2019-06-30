using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public SavedData savedData;

    void Awake()
    {
        savedData = new SavedData();
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //savedData = new SavedData();
    }
    
}
