using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreMultiplier : MonoBehaviour, IPowerUp
{
    public static Action<float, float> Active;
    [SerializeField] float itemDuration;
    [SerializeField] float scoreMultiplier;

    public void OnActive()
    {
        
        Active?.Invoke(itemDuration, scoreMultiplier);
    }
}