using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject originalTower;
    public GameObject brokenTower;
    public int damageTaken = 0;

    void Update()
    {
        if (damageTaken >= 100)
        {
            if (originalTower != null)
            {
                originalTower.SetActive(false);
                if (brokenTower != null)
                {
                    Vector3 pos = originalTower.transform.position;
                    pos.y -= pos.y;
                    brokenTower = Instantiate(brokenTower, pos, originalTower.transform.rotation);
                    foreach (Transform t in brokenTower.transform)
                    {
                        var rb = t.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(2, originalTower.transform.position, 2);
                        }
                    }
                }
            }
        }
    }
}