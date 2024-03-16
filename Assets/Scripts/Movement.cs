using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _targets;
    private IEnumerator _enumTargets;
    private Transform _target;

    private void Start()
    {
        _enumTargets = _targets.GetEnumerator();

        if (_enumTargets.MoveNext() == false)
        {
            return;
        }

        _target = (Transform)_enumTargets.Current;
    }

    private void Update()
    {
        if (_target.position == transform.position)
        {
            if (_enumTargets.MoveNext() == false)
            {
                Destroy(gameObject);
            }

            _target = (Transform)_enumTargets.Current;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void Init(Transform[] targets)
    {
        _targets = targets;
    }
}
