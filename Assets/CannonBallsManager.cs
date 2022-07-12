using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallsManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float timeToSpawn;
    [SerializeField] float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0 )
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = timeToSpawn;
            GameObject obj = Instantiate(prefab);
        }
    }
}
