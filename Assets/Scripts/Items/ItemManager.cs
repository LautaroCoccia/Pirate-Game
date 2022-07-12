using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Space(10f)]
    [Header("-- Player --")]
    [SerializeField] Movement player;
    [Space(10f)]
    [Header("-- Shovel --")]
    [SerializeField] float shovelDuration;
    [SerializeField] float sholvelSpeedMult;

    private void OnEnable()
    {
        Shovel.StartEffect += shovelEffect;
    }
    private void OnDisable()
    {
        Shovel.StartEffect -= shovelEffect;
    }
    // Update is called once per frame
    void Update()
    {
        if(shovelDuration > 0)
        {
            shovelDuration -= Time.deltaTime;
            player.SetDigSpeed(sholvelSpeedMult);
        }
        else 
            player.SetDigSpeed(0.5f);
    }
    void shovelEffect(float dur, float speedMul)
    {
        shovelDuration = dur;
        sholvelSpeedMult = speedMul;
    }
}
