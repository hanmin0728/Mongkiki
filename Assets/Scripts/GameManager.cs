using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    public PlayerMove Player { get; private set; }

    private AllPoolManager allPoolManager; //진짜
    public AllPoolManager AllPoolManager 
    {
        get
        {
            if (allPoolManager == null)
            {
                allPoolManager = FindObjectOfType<AllPoolManager>();
            }
            return allPoolManager;
        }
    }
    private PoolManager poolManager;
    public PoolManager PoolManager 
    {
        get 
        {
            if (poolManager == null)
            {
                poolManager = FindObjectOfType<PoolManager>();
            }
            return poolManager;
        }
    }

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
    private float storage;

    private string path;

    
    private void Awake()
    {
        path = Application.persistentDataPath + "/" + "score.txt";
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        Time.timeScale = 1f;
        allPoolManager = FindObjectOfType<AllPoolManager>();
        createEnemy = GetComponent<CreateEnemy>();
        MaxPosition = new Vector2(8.5f, 4.5f);
        MinPosition = new Vector2(-8.5f, -4.5f);
        poolManager = FindObjectOfType<PoolManager>();
        Player = FindObjectOfType<PlayerMove>();
        best = PlayerPrefs.GetInt("Best", 0);
        UpdateUI();
    }

    private void Start()
    {
        LoadScore();    
    }

    private void SaveScore()
    {
        jarohung data = new jarohung();
        data.score = this.storage;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    private void LoadScore()
    {
        if (! File.Exists(path))
        {
            SaveScore();
        }
        string json = File.ReadAllText(path);
        jarohung data = JsonUtility.FromJson<jarohung>(json);
        this.storage = data.score;
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
        SaveScore();
        Debug.Log(storage);
        stopPopUp.SetActive(false);
        StartCoroutine(ContinueDelay());
    }

    public void OnClickStop()
    {
        Time.timeScale = 0;
        stopPopUp.SetActive(true);
       // SoundManager.Instance.audioSource.Stop();
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
      //   SoundManager.Instance.audioSource.clip = SoundManager.Instance.audioclip;
       // SoundManager.Instance.audioSource.Play();
        countTime = 3;
    }

    public void AddScore(int addScore)
    {
        if ((score + addScore) % 500 < addScore)
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
