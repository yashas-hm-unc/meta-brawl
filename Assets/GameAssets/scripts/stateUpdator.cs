using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class stateUpdator : NetworkBehaviour
{
    public Transform root;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOwner){
            root.position = vrRigReference.Singleton.root.position - vrRigReference.Singleton.root.forward;

        }
    }
}
