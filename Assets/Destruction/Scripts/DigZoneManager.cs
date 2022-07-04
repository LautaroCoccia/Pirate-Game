using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DigZoneManager : MonoBehaviour
{
    [Header("Level Data")]
    [SerializeField] int horizontalAmount;
    [SerializeField] int verticalAmount;
    [SerializeField] float floorDistance = 0.5f;
    [SerializeField] int maxPositions;
    [SerializeField] int numPosInUse;
    [Header("spawner")]
    [SerializeField] float spawnTime;
    [SerializeField] float currentTime;

    [Header("Prefabs")]
    [SerializeField] GameObject digZonePrefab;

    //[SerializeField] private List<GameObject> itemList;

    struct DigZone
    {
        public Vector3 position;
        public bool isInUse;
    }
    List<DigZone> positionsInUse = new List<DigZone>();
    DigZone digZone;
    // Start is called before the first frame update
    void Start()
    {
        digZone = new DigZone();
        horizontalAmount = horizontalAmount * 2;
        verticalAmount = verticalAmount * 2;
        if (horizontalAmount % 2 == 0) horizontalAmount++;
        if (verticalAmount % 2 == 0) verticalAmount++;
        for (int x = 0; x < horizontalAmount; x++)
        {
            for (int y = 0; y < verticalAmount; y++)
            {
                //Instantiate(floorPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
                if (x % 2 == 1 && y % 2 == 1)
                {
                    digZone.position = new Vector3(x, floorDistance, y);
                    digZone.isInUse = false;
                    positionsInUse.Add(digZone);
                    maxPositions++;
                    //positionsInUse.Add(new Vector3(x, floorDistance, y),);

                }
                //Instantiate(digZonePrefab, new Vector3(x, floorDistance, y), Quaternion.identity, transform);
                //
                //else
                //    positionsInUse.Add(y * horizontalAmount + x); //CRANEAR ESTO
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(numPosInUse < maxPositions)
        {
            if(currentTime > 0)
            {
                currentTime -= Time.deltaTime;

            }
            else
            {
                currentTime = spawnTime;
                int rnd;
                bool hasSpawned = false;
                do
                {
                    rnd = Random.Range(0, positionsInUse.Count);
                    if(!positionsInUse[rnd].isInUse)
                    {
                        digZone = positionsInUse[rnd];
                        digZone.isInUse = true;
                        positionsInUse[rnd] = digZone;
                        Instantiate(digZonePrefab, positionsInUse[rnd].position, Quaternion.identity, transform);
                        numPosInUse++;
                        hasSpawned = true;
                    }

                } while (!hasSpawned);

            }

        }      
    }
}
