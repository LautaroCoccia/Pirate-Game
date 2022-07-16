using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float shovelCurrentTime;
    [SerializeField] float parrotCurrentTime;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //Shovel
        if (shovelCurrentTime > 0)
            shovelCurrentTime -= Time.deltaTime;
        else
            ActivateShovel(0, 1);
        //Parrot
        if (parrotCurrentTime > 0)
            parrotCurrentTime -= Time.deltaTime;
        else
            ActivateParrot(0, 1);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateParrot(15, 2);
        }
    }
    public void ActivateShield(bool isActive)
    {
        playerController.SetActiveShield(isActive);
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
}
