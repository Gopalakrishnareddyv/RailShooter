using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    void Start()
    {
        Invoke("GoToGameScene", 4.0f);
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
