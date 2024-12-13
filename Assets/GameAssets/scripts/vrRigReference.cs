using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrRigReference : MonoBehaviour
{
    public Transform root;
    public static vrRigReference Singleton;

    private void Awake()
    {
        Singleton = this;
    }
}
