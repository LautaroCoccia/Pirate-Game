using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
public class ChestSpawner : MonoBehaviour,ICollidable
{
    public static event Action<Vector3> OnDestroyDigZone;
    public static Action<int> AddScore;
    [SerializeField] List<GameObject> items;
    [SerializeField] List<Chest> chests;

    private void OnEnable()
    {
        //PlayerController.SpawnChest += SpawnChest;
    }
    private void OnDisable()
    {
        //PlayerController.SpawnChest -= SpawnChest;
    }
    private void Update()
    {
    }
    public void SpawnChest()
    {
        int rnd = Random.Range(0, 100);
        int aux = 0;

        int aux2 =  Random.Range(0, items.Count);
        for (int i = 0; i < chests.Count; i++)
        {
            if (rnd >= aux && rnd < aux + chests[i].spawnRate)
            {
                AddScore?.Invoke(chests[i].score);
                items[aux2].GetComponent<IPowerUp>().OnActive();
                
                break;
            }
            else
                aux += chests[i].spawnRate;
        }
        //this.gameObject.SetActive(false);
    }
    public void Collidable()
    {
        SpawnChest();
        OnDestroyDigZone?.Invoke(transform.position);
    }
}
