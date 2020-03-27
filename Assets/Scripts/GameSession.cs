using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.3f , 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int pointsPerBlockDestroyed = 53;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    // Start is called before the first frame update
    private void Start()
    {
        DisplayScore();
    }
    
   public  void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        
    }

    



    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        DisplayScore();


    }

    public void DisplayScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
       
    }

}
