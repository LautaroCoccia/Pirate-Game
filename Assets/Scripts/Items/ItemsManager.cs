using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ItemsManager : MonoBehaviour
{
    public static Action<float> setScoreMultiplier;
    [SerializeField] PlayerController playerController;
    [SerializeField] float shovelCurrentTime;
    [SerializeField] float parrotCurrentTime;
    [SerializeField] float scoreMultiplierTime;

    private void OnEnable()
    {
        CannonBall.OnHitPlayer += OnPlayerGetHit;
        Shovel.Active += ActivateShovel;
        Parrot.Active += ActivateParrot;
        Shield.Active += ActivateShield;
        ScoreMultiplier.Active += ActiveMultiplier;
    }
    private void OnDisable()
    {
        ScoreMultiplier.Active -= ActiveMultiplier;
        Parrot.Active -= ActivateParrot;
        Shovel.Active -= ActivateShovel;
        CannonBall.OnHitPlayer -= OnPlayerGetHit;
        Shield.Active -= ActivateShield;
    }
    // Update is called once per frame
    void Update()
    {
        //Shovel
        if (shovelCurrentTime > 0)
            shovelCurrentTime -= Time.deltaTime;
        else
        {
            shovelCurrentTime = 0;
            playerController.SetDigSpeed(1);
        }
        //Parrot
        if (parrotCurrentTime > 0)
            parrotCurrentTime -= Time.deltaTime;
        else
        {
            parrotCurrentTime = 0;
            playerController.SetMovementSpeed(1);
        }
        //Score multiplier
        if (scoreMultiplierTime > 0)
            scoreMultiplierTime -= Time.deltaTime;
        else
        {
            scoreMultiplierTime = 0;
            setScoreMultiplier?.Invoke(1);
        }
    }

    public void ActivateShovel(float time, float multiplier)
    {
        shovelCurrentTime = time;
        playerController.SetDigSpeed(multiplier);
    }
    public void ActivateParrot(float time, float multiplier)
    {
        parrotCurrentTime = time;
        playerController.SetMovementSpeed(multiplier);
    }
    public void ActivateShield(bool isActive)
    {
        playerController.SetActiveShield(isActive);
    }
    public void ActiveMultiplier(float time, float newMultiplier)
    {
        //Debug.Log("chota");
        scoreMultiplierTime = time;
        setScoreMultiplier?.Invoke(newMultiplier);
    }
    void OnPlayerGetHit()
    {
        ActivateShield(false);
    }
    
}
