using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    static public GameManager Instance;
    [Header("Menu Panels")]
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject EndPanel;

    [Header("Game variables")]
    public Text CoinCounter;
    public Text TimeCounter;
    public GameObject Board;

    [Header("Summary variables")]
    public Text CoinSummary;
    public Text TimeSummary;
    public Text PointsSummary;
    public GameObject RestartButton;
    public GameObject QuitButton;

    private float GameTime = 60;
    private bool IsGameStarted;
    private int CollectedCoins = 0;
    private int Points = 0;

    private void Awake()
    {
        Instance = this;
    }
        
    void Start () {        

        RefreshCoinCounter();
    }

    public void StartGame()
    {
        MenuPanel.SetActive(false);
        EndPanel.SetActive(false);
        GamePanel.SetActive(true);
        Board.SetActive(true);
        IsGameStarted = true;       

    }

    void Update () {
        if (IsGameStarted)
        {
            if (GameTime > 0)
            {
                GameTime -= Time.fixedDeltaTime;
                TimeCounter.text = GameTime.ToString("f0");
            }
        }
        
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void WonGame()
    {
        IsGameStarted = false;
        MenuPanel.SetActive(false);
        EndPanel.SetActive(true);
        GamePanel.SetActive(false);
        Board.SetActive(false);
        CoinSummary.text = CollectedCoins.ToString();
        TimeSummary.text = GameTime.ToString("f0");
        PointsSummary.text = Points.ToString();

        StartCoroutine("CountSummaryPoints");
    }

    IEnumerator CountSummaryPoints()
    {
        for (int i = CollectedCoins; i > 0; i--)
        {
            yield return new WaitForSeconds(0.5f);
            CoinSummary.text = (i - 1).ToString();
            Points += 5;
            PointsSummary.text = Points.ToString();
        }

        for (int i = (int)GameTime; i > 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            TimeSummary.text = (i - 1).ToString();
            Points += 1;
            PointsSummary.text = Points.ToString();
        }

        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CollectedCoin(GameObject coin)
    {
        Destroy(coin);
        CollectedCoins++;
        RefreshCoinCounter();
    }
    public void RefreshCoinCounter()
    {
        CoinCounter.text = CollectedCoins.ToString();
    }

}
