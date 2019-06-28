using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scenes : MonoBehaviour {

    public void changeMenuScenne(int SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
