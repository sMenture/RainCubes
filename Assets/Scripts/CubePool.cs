using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _spawnCount = 50;

    private Queue<GameObject> _pooledObject = new Queue<GameObject>();
    private List<GameObject> _objectsUsed = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            var newPoolElement = Instantiate(_cubePrefab, transform);
            newPoolElement.SetActive(false);

            _pooledObject.Enqueue(newPoolElement);    
        }
    }


    private void Update()
    {
        for (int i = _objectsUsed.Count - 1; i >= 0; i--)
        {
            var selected = _objectsUsed[i];

            if (selected.activeInHierarchy == false)
            {
                _objectsUsed.RemoveAt(i);
                _pooledObject.Enqueue(selected);
            }
        }
    }

    public bool TryGetElement(out GameObject gameObject)
    {
        gameObject = null;

        if (_pooledObject.Count == 0)
            return false;

        var firstPoolElement = _pooledObject.Dequeue();
        _objectsUsed.Add(firstPoolElement);

        firstPoolElement.SetActive(true);
        gameObject = firstPoolElement;

        return true;
    }
}
