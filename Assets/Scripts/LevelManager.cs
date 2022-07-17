using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float score;
    [SerializeField] float multiplier = 1;
    private void OnEnable()
    {
        ChestSpawner.AddScore += OnScoreChange;
        ItemsManager.setScoreMultiplier += OnMultiplierChange;
    }
    private void OnDisable()
    {
        ItemsManager.setScoreMultiplier -= OnMultiplierChange;
        ChestSpawner.AddScore -= OnScoreChange;
    }
    void OnScoreChange(int value)
    {
        score += (value * multiplier);
    }
    void OnMultiplierChange(float newValue)
    {
        multiplier = newValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
