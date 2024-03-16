using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Movement _prefab;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform[] _targets;

    private void Start()
    {
        if (_spawnPoints == null)
            return;

        StartCoroutine(SpawnObject(_delay));
    }

    private IEnumerator SpawnObject(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int spawnPointIndex;

        while (enabled)
        {
            spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[spawnPointIndex];

            Movement movement = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
            movement.Init(_targets);

            yield return wait;
        }
    }
}
