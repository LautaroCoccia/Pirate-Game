using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shield : MonoBehaviour, IPowerUp
{
    public static Action<bool> Active;
    public void OnActive()
    {
        Active?.Invoke(true);
    }
}
