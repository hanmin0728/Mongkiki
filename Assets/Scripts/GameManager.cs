using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    public PlayerMove Player { get; private set; }
    public AllPoolManager allPoolManager { get; private set; }
    public PoolManager poolManager { get; private set; }

    [SerializeField]
    private Text textDelayTime = null;

    [SerializeField]
    private Text textLife = null;

    [SerializeField]
    private Text textScore = null;

    [SerializeField]
    private Text textBest = null;

    private int life = 3;

    public int score = 0;

    private int best = 0;

    private int countTime = 3;
    private CreateEnemy createEnemy;

    [SerializeField]
    private GameObject stopPopUp;

    [SerializeField]
    private AudioSource audioSource;
    private void Awake()
    {
        Time.timeScale = 1f;
        createEnemy = GetComponent<CreateEnemy>();
        MaxPosition = new Vector2(9.7f, 4.5f);
        MinPosition = new Vector2(-9.7f, -4.5f);
        poolManager = FindObjectOfType<PoolManager>();
        allPoolManager = FindObjectOfType<AllPoolManager>();
        Player = FindObjectOfType<PlayerMove>();
        best = PlayerPrefs.GetInt("Best", 0);
        UpdateUI();
    }
    
    public void OnClickLobby()
    {
        SceneManager.LoadScene("Start");
    }
    public void OnClickReStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnClickContinue()
    {
        stopPopUp.SetActive(false);
        StartCoroutine(ContinueDelay());
    }

    public void OnClickStop()
    {
        Time.timeScale = 0;
        stopPopUp.SetActive(true);
        audioSource.Stop();
        
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
        audioSource.Play();
        yield return 0;
    }

    public void AddScore(int addScore)
    {
        if ((score + addScore) % 500 < addScore )
            createEnemy.MonkeySpawn();
       
        score += addScore;
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Best", best);
        }
        UpdateUI();
    }
    
    public void Dead()
    {
        life--;
        UpdateUI();
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void UpdateUI()
    {
        textLife.text = string.Format("LIFE {0}", life);
        textScore.text = string.Format("Score {0}", score);
        textBest.text = string.Format("Best {0}", best);
    }
}
