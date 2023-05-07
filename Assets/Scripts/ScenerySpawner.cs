using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{

    [SerializeField] float treeLeftSpawnPositionXUpper = 1382.9f;
    [SerializeField] float treeLeftSpawnPositionXLower = 1340f;
    [SerializeField] float treeRightSpawnPositionXUpper = 1382.9f;
    [SerializeField] float treeRightSpawnPositionXLower = 1340f;
    [SerializeField] float treeSpawnPositionY = -383f;
    [SerializeField] float treeSpawnPositionZ = -514.3f;
    
    [SerializeField] float stoneLeftSpawnPositionXUpper;
    [SerializeField] float stoneLeftSpawnPositionXLower;
    [SerializeField] float stoneRightSpawnPositionXUpper;
    [SerializeField] float stoneRightSpawnPositionXLower;

    [SerializeField] float stoneSpawnPositionY;
    [SerializeField] float stoneSpawnPositionZ;

    readonly float spawnIntervalUpper, spawnIntervalLower = 0f;
    
    int sceneryCount = 5;
    [SerializeField] int maxSceneryCount;

    [SerializeField] GameObject[] sceneryObjects = new GameObject[4];
    GameObject cylinder;

    readonly Quaternion treeSpawnRotation = Quaternion.Euler(180, 0, 0); 
    readonly Quaternion stoneSpawnRotation = Quaternion.Euler(172, 0, 0);

    void Start()
    {
        cylinder = GameObject.Find("Cylinder");
        GameObject newThing = Instantiate(sceneryObjects[0], GetRandomPosition(0), GetRotation(0));
        newThing.transform.SetParent(cylinder.transform, true);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Sunflower"))
        {
            Destroy(other.gameObject);
            Invoke(nameof(SpawnScenery), Random.Range(spawnIntervalLower, spawnIntervalUpper));
            if (sceneryCount < maxSceneryCount)
            {
                Invoke(nameof(SpawnScenery), Random.Range(spawnIntervalLower, spawnIntervalUpper));
                Invoke(nameof(SpawnScenery), Random.Range(spawnIntervalLower, spawnIntervalUpper));
            }
        }
    }

    void SpawnScenery()
    {
        int pickRandomObject = Random.Range(0, sceneryObjects.Length);
        GameObject newThing = Instantiate(sceneryObjects[pickRandomObject], GetRandomPosition(pickRandomObject), GetRotation(pickRandomObject));
        newThing.transform.SetParent(cylinder.transform, true);
        sceneryCount++;
    }

    Vector3 GetRandomPosition(int objectIndex)
    {
        
        int leftOrRight = Random.Range(0, sceneryObjects.Length);

        if (objectIndex == 0)
        {
            if (leftOrRight == 0)
            {
                Vector3 spawnLocation = new Vector3(Random.Range(treeLeftSpawnPositionXLower, treeLeftSpawnPositionXUpper), treeSpawnPositionY, treeSpawnPositionZ);
                return spawnLocation;
            }
            else
            {
                Vector3 spawnLocation = new Vector3(Random.Range(treeRightSpawnPositionXLower, treeRightSpawnPositionXUpper), treeSpawnPositionY, treeSpawnPositionZ);
                return spawnLocation;
            }
        }
        if (leftOrRight == 0)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(stoneLeftSpawnPositionXLower, stoneLeftSpawnPositionXUpper), stoneSpawnPositionY, stoneSpawnPositionZ);
            return spawnLocation; 
        }
        else
        {
            Vector3 spawnLocation = new Vector3(Random.Range(stoneRightSpawnPositionXLower, stoneRightSpawnPositionXUpper), stoneSpawnPositionY, stoneSpawnPositionZ);
            return spawnLocation;
        }
    }

    Quaternion GetRotation (int objectIndex)
    {
        if (objectIndex == 0)
        {
            return treeSpawnRotation;
        }
        return stoneSpawnRotation;
    }
}


