using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

[RequireComponent(typeof(AutoCam))]
public class CameraTarget : MonoBehaviour
{
    [SerializeField] ControllerSO controllerSO;

    private AutoCam camController;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        camController = GetComponent<AutoCam>();
        if (controllerSO.model.player != null)
        {
            camController.SetTarget(controllerSO.model.player.transform);
        }
    }

    public void SetPlayerGO(object player)
    {
        if (player is GameObject)
        {
            GameObject target = (GameObject)player;
            camController.SetTarget(target.transform);
        }
    }
}
