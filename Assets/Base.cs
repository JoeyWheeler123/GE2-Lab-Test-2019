using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float tiberium = 0;

    public TextMeshPro text;

    public GameObject fighterPrefab;

    Color baseColor;

    public float timer = 1f;

    //Coroutine TiberiumCount;
    private void Awake()
    {
        StartCoroutine("TiberiumCount");
    }

    // Start is called before the first frame update
    void Start()
    {
        //baseColor = gameObject.GetComponent<Renderer>().material.color;
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + tiberium;

        if(tiberium >= 10)
        {
            //Instantiate(fighterPrefab, spawnPoint, Quaternion.
            //identity);
            Instantiate(fighterPrefab, gameObject.transform.position, Quaternion.
            identity);
            tiberium = tiberium - 10;
        }
    }

    IEnumerator TiberiumCount()
    {
        //yield return new WaitForSeconds(timer);

        while (true)
        {
            yield return new WaitForSeconds(timer);
            tiberium++;
        }

        //yield; 

        }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "bullet")
        {
            tiberium = tiberium - .5f;
        }
    }


}
