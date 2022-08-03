using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CannonBall : MonoBehaviour
{
    public static Action OnHitPlayer;
    [SerializeField] int playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == playerLayer)
        {
            Debug.Log("FUCK");
            OnHitPlayer?.Invoke();
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
