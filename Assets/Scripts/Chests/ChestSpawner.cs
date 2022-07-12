using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
public class ChestSpawner : MonoBehaviour
{
    public static Action<int> AddScore;
    [SerializeField] List<Chest> chests;
    //[SerializeField] List<Item> items;
    
    public void SpawnChest()
    {
        int rnd = Random.Range(0, 100);
        int aux = 0; 
        for (int i = 0; i < chests.Count; i++)
        {
            if (rnd >= aux && rnd < aux + chests[i].spawnRate)
            {
                AddScore?.Invoke(chests[i].score);
                //items[0].ActivateEffect();
                break;
            }
            else
                aux += chests[i].spawnRate;
        }
    }
}
