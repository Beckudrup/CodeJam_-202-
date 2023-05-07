using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Building", order = 1)]                                     // Allows the scriptable object to be created via. the Unity asset menu.

public class BuildingValues : SceneryValues
{
    [SerializeField] int randomYRotationLower;                                                             // Sets the lowest possible random Y-rotation offset value
    [SerializeField] int randomYRotationUpper;                                                             // Sets the highest possible random Y-rotation offset value

    public override Quaternion GetRotation()                                                               // The GetRotation method is overridden to add a new randomized vector3 to the
                                                                                                           // predefined rotation, and return the result as a quaternion. 
    {
        Quaternion objectRotation = Quaternion.Euler(spawnRotation + 
            new Vector3(0, (int)Random.Range(randomYRotationLower, randomYRotationUpper), 0));
        return objectRotation;
    }

}
