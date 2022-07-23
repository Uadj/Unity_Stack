using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner cubeSpawner;
    [SerializeField]
    private CameraController cameraController;
    private IEnumerator Start()
    {
        while (true)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                if (cubeSpawner.CurrentCube != null)
                {
                    cubeSpawner.CurrentCube.Arrangement();
                }
                cameraController.MoveOnStep();
                cubeSpawner.SpawnCube();
            }
            yield return null;
        }
    }
}
