using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class teleportation_script : MonoBehaviour
{
    // Start is called before the first frame update
     public float tpDistance = 0.1f;
    public bool teleporting = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (!teleporting)
            {
                teleporting = true;
                teleport();
            }
        }
        
        else if(OVRInput.GetUp(OVRInput.Button.Three))
            teleporting = false;
        
    }


    void teleport()
    {
        transform.position = transform.position + transform.forward * tpDistance;
    }

    
}
