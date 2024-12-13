using System.Collections;
using System.Collections.Generic;
using GameAssets.scripts;
using UnityEngine;

public class towerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name is "Avatar")
        {
            Power hit = other.gameObject.GetComponent<Power>();
            if (hit is not null)
            {
                if (hit.powerType is PowerTypeEnum.THROWABLE)
                {
                    TowerScript tower = GetComponentInParent<TowerScript>();
                    tower.damageTaken += hit.damageCost;
                }
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Power hit = other.gameObject.GetComponent<Power>();
        if (hit is not null)
        {
            if (hit.powerType is PowerTypeEnum.COMBAT)
            {
                TowerScript tower = GetComponentInParent<TowerScript>();
                tower.damageTaken += hit.damageCost;
            }
        }
    }
}