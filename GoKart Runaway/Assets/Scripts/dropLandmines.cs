using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLandmines : MonoBehaviour
{

    public GameObject landmine;
    public bool hasMines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(hasMines)
            {
                StartCoroutine(dropMines());
                hasMines = false;
            }
        }
    }

    IEnumerator dropMines()
    {
        Vector3 pos;
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.4f);
            pos = transform.position;
            yield return new WaitForSeconds(0.15f);
            Instantiate(landmine, pos, Quaternion.identity);
        }
    }
}
