﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ModelSO : ScriptableObject
{
    public PlayerSO playerSO;
    public GameObject playerPrefab;
    public GameObject player;
    [HideInInspector] public Transform[] spawnPoints;
}
