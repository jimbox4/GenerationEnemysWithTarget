using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField, Min(0)] private float _lifeTime;

    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _startTime >=  _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
