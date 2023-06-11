using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CrateManager : MonoBehaviourPunCallbacks
{
    public GameObject cratePrefab;
    public float spawnRadius;
    public float spawnHeight;
    public int maxCrates;

    private float spawnTimer;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        // Start spawning crates
        InvokeRepeating("SpawnCrate", 0f, 3f); // Spawn a crate every 5 seconds
    }

    private void SpawnCrate()
    {
        if (GameObject.FindGameObjectsWithTag("Crate").Length < maxCrates)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadius, spawnRadius), spawnHeight, Random.Range(-spawnRadius, spawnRadius));
            GameObject crate = PhotonNetwork.Instantiate(cratePrefab.name, spawnPosition, Quaternion.identity);
            crate.tag = "Crate"; // Add tag to newly spawned crate
        }
    }
}
