using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoSingelton<GameManager>
{
   // public static GameManager Instance;
    //private static GameManager instance = null;

    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            FindObjectOfType<GameManager>();
    //            if (instance == null)
    //            {
    //                instance = new GameObject("GameManager").AddComponent<GameManager>();
    //            }
    //        }
    //        return instance;
    //    }
    //}
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    public PlayerMove Player { get; private set; }

    private AllPooler allPooler;

    public EnemyPoolManager enemyPoolManager;

    private AllPoolManager allPoolManager;
    
    
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

    public int life = 3;

    public int score = 0;

    public int best = 0;

    private CreateEnemy createEnemy;

    private CreateBoss createBoss;

    [SerializeField]
    private float storage;

    private string path;

    private bool isBossSpawn = false;

    public UIManager uiManager;

    public GameObject boss;
    private void Awake()
    {
        //path = Application.persistentDataPath + "/" + "score.txt";
        //if (Instance != null)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    Instance = this;
        //   // DontDestroyOnLoad(this);
        //}

        Time.timeScale = 1f;

        allPoolManager = FindObjectOfType<AllPoolManager>();
        allPooler = GetComponent<AllPooler>();

        createBoss = GetComponent<CreateBoss>();
        createEnemy = GetComponent<CreateEnemy>();

        MaxPosition = new Vector2(8.5f, 4.5f);
        MinPosition = new Vector2(-8.5f, -4.5f);

        poolManager = FindObjectOfType<PoolManager>();
        enemyPoolManager = FindObjectOfType<EnemyPoolManager>();

        Player = FindObjectOfType<PlayerMove>();

        best = PlayerPrefs.GetInt("Best", 0);

    }

    private void Start()
    {
      // LoadData();
    }

    //private void SaveData()
    //{
    //    jarohung data = new jarohung();
    //    data.volume = SoundManager.Instance.controlVolume;
    //    string json = JsonUtility.ToJson(data, true);
    //    File.WriteAllText(path, json);
    //}
    //private void LoadData()
    //{
    //    if (!File.Exists(path))
    //    {
    //        SaveData();
    //    }
    //    string json = File.ReadAllText(path);
    //    jarohung data = JsonUtility.FromJson<jarohung>(json);
    //    SoundManager.Instance.controlVolume = data.volume;
    //}


    public void AddScore(int addScore)
    {
        if ((score + addScore) % 500 < addScore)
        {
            createEnemy.MonkeySpawn();
        }
        else if ((score + addScore) >= 5000 && !isBossSpawn)
        {
            boss.SetActive(true);
           
          //  allPooler.DeSpawn();
            isBossSpawn = true;
        }
   
        score += addScore;
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Best", best);
        }
        uiManager.UpdateUI();
    }

    public void Dead()
    {
        life--;
        uiManager.UpdateUI();
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
            //SoundManager.Instance.audioSources[0].Stop();
            //SoundManager.Instance.audioSources[1].Stop();
            //SoundManager.Instance.audioSources[2].Play();
        }
    }


}
