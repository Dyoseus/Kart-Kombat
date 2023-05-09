using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public GameObject cratePrefab;
    public float spawnRadius;
    public float spawnHeight;
    public int maxCrates;

    private float spawnTimer;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Crate").Length < maxCrates && Time.time >= spawnTimer)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadius, spawnRadius), spawnHeight, Random.Range(-spawnRadius, spawnRadius));
            GameObject crate = Instantiate(cratePrefab, spawnPosition, Quaternion.identity);
            crate.tag = "Crate"; // yAdd tag to newly spawned crate
            spawnTimer = Time.time + 5f; // Set timer for next spawn
        }
    }
}
