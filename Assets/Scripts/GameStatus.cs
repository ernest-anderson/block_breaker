using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Param    
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int scoreEachBlock = 25;
    [SerializeField] int currentScore;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] bool isAutoPlayEnabled;

    private void Awake()
    {
        int gameStatusAlive = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusAlive > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        textScore.text = "Score " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;        
    }

    public void AddScore() {
        currentScore += scoreEachBlock;
        textScore.text = "Score " + currentScore;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    public bool GetStatusAutoPlay() {
        return isAutoPlayEnabled;
    }
}