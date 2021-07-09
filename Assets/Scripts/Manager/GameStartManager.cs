using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameStartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject informationPopUp;

    private void Start()
    {
       // SoundManager.Instance.audioSources[2].Play();
    }
    public void OnClickStart()
    {
        //SoundManager.Instance.audioSources[0].Play();
        //SoundManager.Instance.audioSources[1].Stop();
        //SoundManager.Instance.audioSources[2].Stop();
        SceneManager.LoadScene("Main");
        SoundManager.Instance.ButtonSound();

    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
    
    public void OnClickInformaition()
    {
        informationPopUp.SetActive(true);
        SoundManager.Instance.ButtonSound();

    }
    public void OnClickInformaitionExit()
    {
        informationPopUp.SetActive(false);
        SoundManager.Instance.ButtonSound();

    }
}
