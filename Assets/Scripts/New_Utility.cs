using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class New_Utility : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("You've just exit");
    }

}
