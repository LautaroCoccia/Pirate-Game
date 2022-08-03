using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shovel : MonoBehaviour, IPowerUp
{
    public static Action<float, float> Active;
    [SerializeField] float itemDuration;
    [SerializeField] float digSpeedMultiplier;

    public void OnActive()
    {
        Active?.Invoke(itemDuration, digSpeedMultiplier);
    }
}
