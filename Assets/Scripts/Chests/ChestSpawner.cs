using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
public class ChestSpawner : MonoBehaviour
{
    [SerializeField] List<Chest> chests;
    [SerializeField] List<Item> items;
    
    public void SpawnChest()
    {
        int rnd = Random.Range(0, 100);
        int aux = 0; 
        for (int i = 0; i < chests.Count; i++)
        {
            if (rnd >= aux && rnd < aux + chests[i].spawnRate)
            {
                items[0].ActivateEffect();
                break;
            }
            else
                aux += chests[i].spawnRate;
        }
    }
}
