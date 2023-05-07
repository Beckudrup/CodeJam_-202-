using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Building", order = 1)]

public class BuildingValues : SceneryValues
{
    [SerializeField] int randomYRotationLower;
    [SerializeField] int randomYRotationUpper;

    public override Quaternion GetRotation()
    {
        Quaternion objectRotation = Quaternion.Euler(spawnRotation + new Vector3(0, (int)Random.Range(randomYRotationLower, randomYRotationUpper), 0));
        return objectRotation;
    }

}
