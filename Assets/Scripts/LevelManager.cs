using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int score = 0;

    [SerializeField] private TextMeshProUGUI UIScore;
    [SerializeField] private TextMeshProUGUI UIHealth;
    [SerializeField] private TextMeshProUGUI UIEnemies;
    [SerializeField] private TextMeshProUGUI UIExtras;
    [SerializeField] private UIManager UImanager;

    private static bool pause = false;
    
    private static bool playerAlive = true;

    private static LevelManager _instanceLevelManager;
    public static LevelManager Get()
    {
        return _instanceLevelManager;
    }
    private void Awake()
    {
        if (_instanceLevelManager == null)
        {
            _instanceLevelManager = this;
        }
        else if (_instanceLevelManager != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        PlayerController.OnDie += GameOver;
        ChestSpawner.AddScore += UpdateScore;
    }
    private void OnDisable()
    {
        ChestSpawner.AddScore -= UpdateScore;
        PlayerController.OnDie -= GameOver;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            SetPause();
        }
    }
    public void UpdateScore(int SCORE)
    {
        score += SCORE;
        if (UIScore != null)
            UIScore.text = ("Score: " + score);
    }
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    private void GameOver()
    {
        SetTimeScale(0);
        //GameOverMenuUI.SetActive(true);
        UImanager.SetActiveGameOverMenuUI(true);
    }
    public void SetPause()
    {
        if(playerAlive)
        {
            if(!UImanager.GetActivePauseMenuUI() && !pause)
            {
                pause = true;
                //PauseMenuUI.SetActive(true);
                UImanager.SetActivePauseMenuUI(true);
                SetTimeScale(0);
            }
            else if(UImanager.GetActiveQuitMenuUI())
            {
                //QuitMenuUI.SetActive(false);
                UImanager.SetActiveQuitMenuUI(false);
                UImanager.SetActivePauseMenuUI(true);


            }
            else
            {
                pause = false;
                UImanager.SetActivePauseMenuUI(false);
                //PauseMenuUI.SetActive(false);
                SetTimeScale(1);
            }
        }
        else 
        {
            //QuitMenuUI.SetActive(false);
            UImanager.SetActiveQuitMenuUI(false);
            UImanager.SetActiveGameOverMenuUI(true);
        }
    }
}
