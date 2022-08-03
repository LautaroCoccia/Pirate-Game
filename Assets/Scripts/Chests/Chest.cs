using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo cofre", menuName = "Cofre")]
public class Chest : ScriptableObject
{
    public GameObject chestModel;
    public string name;
    public int score;
    public int effectRate;
    public int spawnRate;

   
}
