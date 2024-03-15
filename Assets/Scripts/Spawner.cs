using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _objectToSpawn;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _target;

    private void Start()
    {
        if (_spawnPoints == null)
            return;

        _objectToSpawn.GetComponent<Movement>()?.SetTarget(_target);
        StartCoroutine(SpawnObject(_delay));
    }

    private IEnumerator SpawnObject(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int spawnPointIndex;

        while (enabled)
        {
            spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_objectToSpawn, _spawnPoints[spawnPointIndex].position, _spawnPoints[spawnPointIndex].rotation);

            yield return wait;
        }
    }
}
