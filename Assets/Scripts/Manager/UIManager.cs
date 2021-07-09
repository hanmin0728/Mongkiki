using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text textLife = null;

    [SerializeField]
    private Text textScore = null;

    [SerializeField]
    private Text textBest = null;

    [SerializeField]
    private GameObject StopPopUp;

    [SerializeField]
    private Text textDelayTime = null;

    private int countTime = 3;

    private bool isStop = false;    
    void Start()
    {
        GameManager.Instance.uiManager = this;
        UpdateUI();
    }

    public void UpdateUI()
    {
        textLife.text = string.Format("LIFE {0}", GameManager.Instance.life);
        textScore.text = string.Format("Score {0}", GameManager.Instance.score);
        textBest.text = string.Format("Best {0}", GameManager.Instance.best);
    }

    public void StopPopUpAtive(bool isAtive)
    {
        StopPopUp.SetActive(isAtive);
    }
    public void OnClickLobby()
    {
        SceneManager.LoadScene("Start");
        SoundManager.Instance.ButtonSound();

        //SoundManager.Instance.audioSources[0].Stop();
        //SoundManager.Instance.audioSources[1].Stop();
        //SoundManager.Instance.audioSources[2].Play();
    }

    public void OnClickReStart()
    {
        SceneManager.LoadScene("Main");
        SoundManager.Instance.ButtonSound();
        GameManager.Instance.life = 3;
        GameManager.Instance.score = 0;
        //SoundManager.Instance.audioSources[0].Stop();
        // SoundManager.Instance.audioSources[1].Stop();
        //SoundManager.Instance.audioSources[2].Stop();
    }

    //public void OnClickChit()
    //{
    //   // if (Input.GetKeyDown(KeyCode.F1))
    //      GameManager.Instance.score += 5000;
    //}
    public void OnClickContinue()
    {
        StopPopUpAtive(false);
        StartCoroutine(ContinueDelay());
        SoundManager.Instance.ButtonSound();

        //SoundManager.Instance.audioSources[0].Stop();
        //SoundManager.Instance.audioSources[1].Play();
        // SoundManager.Instance.audioSources[2].Stop();
    }

    public void OnClickStop()
    {
        if (isStop) return;
        isStop = true;
        Time.timeScale = 0;
        StopPopUpAtive(true);
        SoundManager.Instance.ButtonSound();

    }
    private IEnumerator ContinueDelay()
    {

        while (countTime > 0)
        {
            textDelayTime.text = string.Format("{0}", countTime);
            countTime--;
            yield return new WaitForSecondsRealtime(1f);

            if (countTime == 0)
                textDelayTime.text = string.Format("");
        }

        Time.timeScale = 1f;
        //SoundManager.Instance.audioSource.clip = SoundManager.Instance.audioclip;
        // SoundManager.Instance.audioSource.Play();
        countTime = 3;
        isStop = false;
    }
}
