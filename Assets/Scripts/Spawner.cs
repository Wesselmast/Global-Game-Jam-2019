using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject toSpawn;
    [SerializeField] private float maxSpawnTime, minSpawnTime;
    [SerializeField] private float spawnInterval;
    private float elapsed;
    private int iteration = 0;

	private void FixedUpdate () {
        elapsed -= Time.fixedDeltaTime;
        if (elapsed <= 0) {
            Instantiate(toSpawn, transform.position, Quaternion.identity);
            elapsed = maxSpawnTime - (spawnInterval * iteration) <= minSpawnTime ? 
                      minSpawnTime :
                      maxSpawnTime - (spawnInterval * iteration);
            iteration++;
        }
	}
}