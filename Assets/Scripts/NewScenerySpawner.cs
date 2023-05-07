using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script was inspired by the code-example found in the Unity documentation page about the ScriptableObject class. 
// See: https://docs.unity3d.com/Manual/class-ScriptableObject.html


public class NewScenerySpawner : MonoBehaviour
{
    int currentSceneryCount;                                                                                        // Stores the current number of scenery prefabs in the scene. 
    [SerializeField] int maxSceneryCount;                                                                           // Sets the maximum number of scenery prefabs that may exist in the scene. 

    [SerializeField] GameObject[] sceneryObjects = new GameObject[4];                                               // Stores scenery prefabs to be instantiated in the scene.
    
    [SerializeField] SceneryValues[] sceneryValues = new SceneryValues[4];                                          // Stores scriptable objects containing the transform and rotation values
                                                                                                                    // for instantiation of each scenery prefab. 

    [SerializeField] GameObject cylinder;                                                                           // Stores a refference to the "cylinder" gameObject in the scene.
                                                                                                                    // The cylinder provides the surface that scenery prefabs are placed on. 
    
    float spawnIntervalUpper = .25f;                                                                                // Sets the highest possible invoke time (delay in seconds) when instantiating prefabs. 
    float spawnIntervalLower = 0f;                                                                                  // Sets the lowest possible invoke time (delay in seconds) when instantiating prefabs. 

    [SerializeField] int numberOfObjectsToSpawn;                                                                    // Sets the number of prefabs to instantiate.

    int numberOfObjectsToSpawnWhenFull = 1;                                                                         // Sets the number of prefabs to instatiate when the number of prefabs in the scene
                                                                                                                    // has reached the maximum value. 


    private void Start()
    {      
        currentSceneryCount = GameObject.FindGameObjectsWithTag("Scenery").Length;                                  // Counts the initial number of scenery prefabs in the scene and stores it. 
        Debug.LogFormat("Initial number of scenery objects is {0}", currentSceneryCount);                           
    }

    void OnTriggerEnter(Collider other)                                                                             // This method fires when the collider of the "deadzone" gameobject (which hold this 
                                                                                                                    // script as a component) overlaps with another collider.                                                                                                                   
    {
        if (other.gameObject.tag == "Scenery")                                                                      // All scenery prefabs hold the "Scenery" tag. 
        {

            Destroy(other.gameObject);                                                                              // Destroys the colliding scenery prefab object. 
            currentSceneryCount--;                                                                                  // Subtracts one from the scenery count. 

            for (int i = 0; i < numberOfObjectsToSpawn; i++)                                                        // loops the nested code block as many times as set by the numberOfObjectsToSpawn variable. 
            {
                Invoke("SpawnScenery", Random.Range(spawnIntervalLower, spawnIntervalUpper));                       // The SpawnScenery method is called via Invoke with a random delay time, to spread
                                                                                                                    // the prefabs out in a natural way rather than spawning on a straight line. 

                currentSceneryCount++;                                                                              // adds one to the scenery count. 
                Debug.LogFormat("Number of scenery objects in scene: {0}", currentSceneryCount);

                if (currentSceneryCount >= maxSceneryCount)                                                         // Checks if the scenery count has reached the maximum value. 
                {
                    numberOfObjectsToSpawn = numberOfObjectsToSpawnWhenFull;                                        // Changes the numberOfObjectsToSpawn when the maximum scenery count is reached. 
                    Debug.Log("Scenery limit reached!");
                }
            }
        }
    }

    void SpawnScenery()
    {
        int randomSceneryObject = (int)Random.Range(0, sceneryObjects.Length);                                      // Picks a random scenery prefab from the array. 
        GameObject newSceneryObject =                                                                               
            Instantiate(sceneryObjects[randomSceneryObject], sceneryValues[randomSceneryObject].GetPosition(),      // Instantiates the selected prefab using the values stored in the prefabs                                                                                                                  
            sceneryValues[randomSceneryObject].GetRotation());                                                      // according scriptable obeject.
        
        newSceneryObject.transform.SetParent(cylinder.transform, true);                                             // Sets the instantiated prefab to be child of the cylinder object.
                                                                                                                    // This will make the scenery prefab move with the cylinder as it rotates. 
    }

}
