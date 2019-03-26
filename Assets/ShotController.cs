using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public bool shooting = false;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    //public float rotSpeed = 180;

    public int fireRate = 2;

    Transform ship;

    void Start()
    {
        ship = this.gameObject.transform;
    }

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (shooting)
            {
                GameObject bullet = Instantiate<GameObject>(bulletPrefab, spawnPoint.position, transform.rotation);

            }
            yield return new WaitForSeconds(1.0f / (float)fireRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "base")
        {
            shooting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "base")
        {
            shooting = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "base")
        {
            Vector3 toPlayer = other.transform.position - transform.position;
        }
    }

    void Update()
    {

    }
}
