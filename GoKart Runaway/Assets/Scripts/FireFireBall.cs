using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FireFireBall : MonoBehaviour
{
    public GameObject fireBallPrefab;
    public GameObject fireBallCosmetic;
    public GameObject fireBallOn;

    public Transform spawnPoint;
    private float fireBallSpeed = 50f;
    private int fireCount = 0;
    

    public bool hasAbility;

    public void GiveFireBallAbility(GameObject fireBallPrefab)
    {
        hasAbility = true;
        fireBallOn = Instantiate(fireBallCosmetic, spawnPoint.position, spawnPoint.rotation, transform);

        // Instantiate the rocket prefab and do any additional logic here
    }


    private void Update()
    {
        if(hasAbility == true){
            
            
            if (Input.GetKeyDown(KeyCode.Space)){

                Fire();
            }
        }
        
    }

    void Fire(){
        StartCoroutine(FireRepeatedly());
    }

    IEnumerator FireRepeatedly() {
    while (fireCount < 15) // repeat 15 times
    {
        yield return new WaitForSeconds(0.6f); // wait for 0.6 seconds
        
        
        // Instantiate the fireball prefab
        var fireBall = PhotonNetwork.Instantiate(fireBallPrefab.name, spawnPoint.position, spawnPoint.rotation);
        fireBall.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireBallSpeed;

        
        fireCount++; // increment the fire count
    }
    fireCount = 0;
    Destroy(fireBallOn);
    hasAbility = false; // set ability flag to false when finished firing
    }   
}