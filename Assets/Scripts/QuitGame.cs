using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("You've just exit");
    }
}
