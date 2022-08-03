using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
            obj.transform.position = new Vector3(Random.Range(0, 10), 20, Random.Range(0, 10));
        }
    }
}
