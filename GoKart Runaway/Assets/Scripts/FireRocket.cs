using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocket : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject rocketCosmetic;
    public GameObject rocketOn;
    public int damage = 101;

    public Transform spawnPoint;
    private float rocketSpeed = 60f;
    

    public bool hasRocketAbility;

    public void GiveRocketAbility(GameObject rocketPrefab)
    {
        hasRocketAbility = true;
        rocketOn = Instantiate(rocketCosmetic, spawnPoint.position, spawnPoint.rotation, transform);

        // Instantiate the rocket prefab and do any additional logic here
    }


    private void Update()
    {
        if(hasRocketAbility == true){
            
            if (Input.GetKeyDown(KeyCode.Space)){

                Fire();
            }
        }
        
    }

    void Fire(){
        Destroy(rocketOn);  
                // Instantiate the rocket prefab
                var rocket = Instantiate(rocketPrefab, spawnPoint.position, spawnPoint.rotation);

                // Set the rocket's speed and spin speed
                rocket.GetComponent<Rigidbody>().velocity = spawnPoint.forward * rocketSpeed;

                

                hasRocketAbility = false;
    }

    void OnCollisionEnter(Collision collision){
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
            {
                health.TakeDamage(damage);
            }
    }
}