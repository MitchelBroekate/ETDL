using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UsbManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> usbSpawnpoints = new();

    [SerializeField]
    GameObject usbObject;

    [System.Obsolete]
    void Start()
    {
        //Spawns the USB sticks in a random set location.
        for(int i = 0; i < usbSpawnpoints.Count;)
        {
            int randomSpawnpoint = UnityEngine.Random.RandomRange(0, usbSpawnpoints.Count);

            GameObject usb = Instantiate(usbObject, usbSpawnpoints[randomSpawnpoint].position, quaternion.identity);
            usb.transform.parent = null;

            usbSpawnpoints.Remove(usbSpawnpoints[randomSpawnpoint]);
        }
    }

}
