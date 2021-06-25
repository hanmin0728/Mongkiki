using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textBest = null;
    void Start()
    {
        textBest.text = string.Format("Best {0}", PlayerPrefs.GetInt("Best"));
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene("Start");
    }
}
