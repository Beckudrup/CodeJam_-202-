using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scenery", order = 1)]                                                 // Allows the scriptable object to be created via. the Unity asset menu.
public class SceneryValues : ScriptableObject
{
  [SerializeField] float spawnPosXLeftSideUpper;                                                                      // sets the highest and lowest possible x-tranform value when the
  [SerializeField] float spawnPosXLeftSideLower;                                                                      // object is instantiated on the left side of the road. 

  [SerializeField] float spawnPosXRightSideUpper;                                                                     // sets the highest and lowest possible x-tranform value when the
  [SerializeField] float spawnPosXRightSideLower;                                                                     // object is instantiated on the right side of the road. 

  [SerializeField] float spawnPosY;                                                                                    // sets the y-transform value for instantiation
  [SerializeField] float spawnPosZ;                                                                                    // sets the z-tranform value for instantiation 

  [SerializeField] Vector3 _spawnRotation = new Vector3();                                                             // sets the rotation values for instantiation in Euler angles. 
                                                              
  public Vector3 spawnRotation                                                                                         // public variable allowing the rotation value to be accessed by other scripts,
                                                                                                                       // while the value itself is kept private in the backing variable "_spawnRotation". 
    {
        get
        {
            return _spawnRotation;
        }
    }

    public virtual Quaternion GetRotation()                                                                            // converts the rotation value to Quaternions and returns it. 
                                                                                                                       // the method is marked with the virtual keyword to allow it to be overwritten. 
    {
        Quaternion objectRotation = Quaternion.Euler(_spawnRotation);
        return objectRotation;
    }

   public Vector3 GetPosition()                                                                                         // Generates a random x-transform value, and returns it along with
                                                                                                                        // the y- and z-transform values. 
    {
        float randomXPos = default;                                                                                     // local variable to hold the randomly generated x-value. 

        while(randomXPos == default || randomXPos > spawnPosXLeftSideUpper && randomXPos < spawnPosXRightSideLower)     // this loop will run as long as randomXPos has its default value ("0"), or any value that
                                                                                                                        // that lies in between spawnPosXLeftSideUpper and spawnPosXRightSideLower.
                                                                                                                        // The latter prevents objects from being instantiated on the road. 
        {
            randomXPos = Random.Range(spawnPosXLeftSideLower, spawnPosXRightSideUpper);                                 // Generates a random float value between spawnPosXLeftSideLower and 
                                                                                                                        // spawnPosXRightSideUpper, for as long as the loop runs.
                                                                                                                        // The loop will break when randomXPos gets a value that is not included
                                                                                                                        // in the loop conditions. 
                                                                                                             
        }

        return new Vector3(randomXPos, spawnPosY, spawnPosZ);
    }

}
