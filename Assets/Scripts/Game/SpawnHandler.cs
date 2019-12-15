using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] Spawner spawnerPrefab;
    [SerializeField] ControllerSO controllerSO;
    [SerializeField] Transform[] spawnPoints;

    private void Awake()
    {
        if (spawnPoints.Length <= 0 || spawnerPrefab == null || controllerSO == null)
            return;
        controllerSO.model.spawnPoints = spawnPoints;
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(spawnerPrefab.gameObject.name, spawnerPrefab.transform.position, spawnerPrefab.transform.rotation).GetComponent<Spawner>();
        }
    }
}
