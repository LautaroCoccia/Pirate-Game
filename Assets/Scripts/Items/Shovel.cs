using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shovel : Item
{
    public static event Action<float, float> StartEffect;
    [SerializeField] float effectDuration = 30;
    [SerializeField] float multiplier = 1.5f;

    public override void ActivateEffect()
    {
        StartEffect?.Invoke(effectDuration, multiplier);
    }

}
