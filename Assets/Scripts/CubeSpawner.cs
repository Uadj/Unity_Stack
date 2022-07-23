using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveAxis { x=0, z}
public class CubeSpawner : MonoBehaviour
{
    
    [SerializeField]
    private Transform[] cubeSpawnPoints;
    [SerializeField]
    private Transform movingCubePrefab;

    [field:SerializeField]
    public Transform LastCube { set; get; }

    [SerializeField]
    private float colorWeight = 15.0f;

    private int currentColorNumberOfTime = 5;
    private int maxColorNumberOfTime = 5;

    private MoveAxis moveAxis = MoveAxis.x;
    public void SpawnCube()
    {
        Transform clone = Instantiate(movingCubePrefab);

        if (LastCube == null || LastCube.name.Equals("StartCubeTop"))
        {
            clone.position = cubeSpawnPoints[(int)moveAxis].position;
        }
        else
        {
            float x = cubeSpawnPoints[(int)moveAxis].position.x;
            float z = cubeSpawnPoints[(int)moveAxis].position.z;
            float y = LastCube.position.y + movingCubePrefab.localScale.y;

            clone.position = new Vector3(x, y, z);
        }
        clone.GetComponent<MeshRenderer>().material.color = GetRandomColor();
        moveAxis = (MoveAxis)(((int)moveAxis + 1) % cubeSpawnPoints.Length);

        LastCube = clone;
    }
    private void OnDrawGizmos()
    {
        for(int i=0; i< cubeSpawnPoints.Length; ++i)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(cubeSpawnPoints[i].transform.position, movingCubePrefab.localScale);

        }
    }
    private Color GetRandomColor()
    {
        Color color = Color.white;
        if(currentColorNumberOfTime > 0)
        {
            float colorAmount = (1.0f / 255.0f) * colorWeight;
            color = LastCube.GetComponent<MeshRenderer>().material.color;
            currentColorNumberOfTime--;
        }
        else
        {
            color = new Color(Random.value, Random.value, Random.value);
            currentColorNumberOfTime = maxColorNumberOfTime;
        }
        return color;
    }
}
