using System;
using GameAssets.scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class Power :MonoBehaviour
{
    public string powerName;
    public float damageCost;
    public int staminaCost;
    public int maxObjects;
    public GameObject powerPrefab;
    public PowerTypeEnum powerType;
}