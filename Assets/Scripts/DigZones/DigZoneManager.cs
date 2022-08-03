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

    struct DigZoneStruct
    {
        public GameObject digZonePrefab;
        public bool isInUse;
    }
    List<DigZoneStruct> positionsInUse = new List<DigZoneStruct>();
    DigZoneStruct digZone;
    private void OnEnable()
    {
        ChestSpawner.OnDestroyDigZone += UpdatePosInUse;
    }
    private void OnDisable()
    {
        ChestSpawner.OnDestroyDigZone -= UpdatePosInUse;
    }
    void UpdatePosInUse(Vector3 position)
    {
        for(int i = 0; i < positionsInUse.Count; i++)
        {
            if (position == positionsInUse[i].digZonePrefab.transform.position)
            {
                digZone = positionsInUse[i];
                digZone.isInUse = false;
                digZone.digZonePrefab.SetActive(false);
                positionsInUse[i] = digZone;
                numPosInUse--;
                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        digZone = new DigZoneStruct();
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
                    digZone.digZonePrefab = Instantiate(digZonePrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
                    //digZone.digZonePrefab.SetActive(false);
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
                        digZone.digZonePrefab.SetActive(true);
                        positionsInUse[rnd] = digZone;
                        numPosInUse++;
                        hasSpawned = true;
                    }

                } while (!hasSpawned);

            }

        }      
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
   
}
