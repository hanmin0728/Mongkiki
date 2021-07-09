using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textBest = null;

    void Start()
    {
       // SoundManager.Instance.audioSources[2].Play();
        textBest.text = string.Format("Best {0}", PlayerPrefs.GetInt("Best"));
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene("Start");
        SoundManager.Instance.ButtonSound();
        //SoundManager.Instance.audioSources[0].Stop();
        //SoundManager.Instance.audioSources[1].Stop();
        //SoundManager.Instance.audioSources[2].Play();
    }
}
