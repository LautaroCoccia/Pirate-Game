using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int score;
    private void OnEnable()
    {
        ChestSpawner.AddScore += OnScoreChange;
    }
    private void OnDisable()
    {
        ChestSpawner.AddScore -= OnScoreChange;
    }
    void OnScoreChange(int value)
    {
        score += value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
