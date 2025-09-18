using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _spawnCount = 50;

    private Queue<GameObject> _pooledObject = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            var newPoolElement = Instantiate(_cubePrefab, transform);
            newPoolElement.SetActive(false);

            _pooledObject.Enqueue(newPoolElement);    
        }
    }

    public bool CheckDequeueElememt()
    {
        if (_pooledObject.Count == 0)
            return false;

        return true;
    }

    public GameObject GetElement()
    {
        var firstPoolElement = _pooledObject.Dequeue();

        firstPoolElement.SetActive(true);

        return firstPoolElement;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        _pooledObject.Enqueue(gameObject);
    }
}
