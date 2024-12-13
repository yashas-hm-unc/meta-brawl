using System.Collections;
using System.Collections.Generic;
using GameAssets.scripts;
using UnityEngine;

public class AvatarCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name is "Avatar")
        {
            Power hit = other.gameObject.GetComponent<Power>();
            if (hit.powerType is PowerTypeEnum.THROWABLE)
            {
                Avatar.Singleton.health -= hit.damageCost;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name is "Avatar")
        {
            Power hit = other.gameObject.GetComponent<Power>();
            if (hit.powerType is PowerTypeEnum.COMBAT)
            {
                Avatar.Singleton.health -= hit.damageCost;
            }
        }
    }
}
