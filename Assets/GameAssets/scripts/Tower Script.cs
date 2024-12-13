using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerScript : MonoBehaviour
{
    public GameObject originalTower;
    public GameObject brokenTower;
    public ParticleSystem blastParticles;
    public AudioClip blastSound;
    public AudioSource audioSource;
    public int damageTaken = 0;
    private bool _blast = false;
    private GameObject _brokenTowerSpawn;

    private void Start()
    {
        brokenTower.SetActive(false);
    }

    void Update()
    {
        if (!_blast && damageTaken >= 100 && originalTower is not null && brokenTower is not null)
        {
            Explode();
        }
    }
    
    private void Explode()
    {
        _blast = true;
        createSpawnTower();
        originalTower.SetActive(false);
        brokenTower.SetActive(true);
        // brokenTower = Instantiate(brokenTower, originalTower.transform.position, originalTower.transform.rotation);
        Rigidbody[] rigidbodies = brokenTower.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb is not null)
            {
                rb.AddExplosionForce(2, originalTower.transform.position, 2f);
            }
        }

        audioSource.clip = blastSound;
        audioSource.Play();
        blastParticles.Play();

        StartCoroutine(FadeOutDestroyedObjects(rigidbodies));
    }

    private void createSpawnTower()
    {
        _brokenTowerSpawn = Instantiate(brokenTower, brokenTower.transform.position, brokenTower.transform.rotation);
        _brokenTowerSpawn.SetActive(false);
    }
    
    private IEnumerator FadeOutDestroyedObjects(Rigidbody[] rigidbodies)
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        int activeBodies = rigidbodies.Length;
        while (activeBodies > 0)
        {
            yield return wait;
            foreach (Rigidbody rb in rigidbodies)
            {
                if (rb.IsSleeping())
                {
                    activeBodies--;
                }
            }
        }

        yield return new WaitForSeconds(5f);

        float time = 0;
        Renderer[] renderers = Array.ConvertAll(rigidbodies, GetRenderer);

        foreach (Rigidbody rb in rigidbodies)
        {
            Destroy(rb.GetComponent<Collider>());
            Destroy(rb);
        }

        while (time < 1)
        {
            float step = Time.deltaTime * 0.25f;
            foreach (Renderer renderer in renderers)
            {
                renderer.transform.Translate(Vector3.down * (step / renderer.bounds.size.y), Space.World);
            }

            time += step;
            yield return null;
        }

        foreach (Renderer renderer in renderers)
        {
            Destroy(renderer.gameObject);
        }
        StartCoroutine(Respawn());
        print("test");
    }

    private Renderer GetRenderer(Rigidbody body)
    {
        return body.GetComponent<Renderer>();
    }
    
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        brokenTower = _brokenTowerSpawn;
        originalTower.SetActive(true);
        damageTaken = 0;
        _blast = false;
    }
}