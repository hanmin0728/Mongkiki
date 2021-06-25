using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameStartManager : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
