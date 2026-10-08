using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Vector3 spawnRange;
    
    private float _timeElapsed;
    
    private void Update()
    {
        if (_timeElapsed >= spawnInterval)
        {
            Spawn();
            _timeElapsed -= spawnInterval;
        }
        
        _timeElapsed += Time.deltaTime;
    }
    
    private void Spawn()
    {
        Vector3 offset = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), Random.Range(-spawnRange.y, spawnRange.y), Random.Range(-spawnRange.z, spawnRange.z));
        Vector3 spawnPos = transform.position + offset;

        GameObject clone = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        clone.transform.localScale *= Random.Range(0.5f, 2f);
    }
}
