using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{

    [SerializeField] float leftSpawnPositionXUpper = 1382.9f;
    [SerializeField] float leftSpawnPositionXLower = 1340f;
    [SerializeField] float rightSpawnPositionXUpper = 1382.9f;
    [SerializeField] float rightSpawnPositionXLower = 1340f;


    [SerializeField] float spawnPositionY = -383f;
    [SerializeField] float spawnPositionZ = -514.3f;

    [SerializeField] GameObject[] sceneryObjects = new GameObject[3];
    GameObject cylinder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Destroy(other.gameObject);
            SpawnScenery();
        }
    }

    void SpawnScenery()
    {
        int pickRandomObject = (int)Random.Range(0, 3);
        GameObject newThing = Instantiate(sceneryObjects[pickRandomObject], GetRandomPlacement(), Quaternion.identity);
        newThing.transform.SetParent(cylinder.transform, true);
    }

    Vector3 GetRandomPlacement()
    {
        int leftOrRight = Random.Range(0, 2);
        if(leftOrRight == 0)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(leftSpawnPositionXLower, leftSpawnPositionXUpper), spawnPositionY, spawnPositionZ);
            return spawnLocation;
        }
        else
        {
            Vector3 spawnLocation = new Vector3(Random.Range(rightSpawnPositionXLower, rightSpawnPositionXUpper), spawnPositionY, spawnPositionZ);
            return spawnLocation;
        }
        
    }

    private void Start()
    {
        cylinder = GameObject.Find("Cylinder");

        GameObject newThing = Instantiate(sceneryObjects[0], GetRandomPlacement(), Quaternion.identity);
        newThing.transform.SetParent(cylinder.transform, true);
    }

}


