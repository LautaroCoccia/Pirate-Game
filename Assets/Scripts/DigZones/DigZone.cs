using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DigZone : MonoBehaviour
{
    public static event Action<Vector3> OnDestroyDigZone;
    [SerializeField] ChestSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        if(Time.deltaTime != 0)
            spawner.SpawnChest();
        OnDestroyDigZone?.Invoke(transform.position);
    }
    
}
