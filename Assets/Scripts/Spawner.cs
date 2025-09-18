using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;

    [Header("Settings")]
    [SerializeField] private int _powerDispersion;
    [SerializeField] private float _spawnDelay = 1;

    private void Start()
    {
        StartCoroutine(Rain());
    }

    private IEnumerator Rain()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            CreateCube();

            yield return wait;
        }
    }

    private void CreateCube()
    {
        if (_cubePool.CheckDequeueElememt())
        {
            GameObject poolElement = _cubePool.GetElement();

            poolElement.transform.rotation = UserUtility.GetRandomRotation();
            poolElement.transform.position = UserUtility.GetRandomDispersionByPosition(transform.position, _powerDispersion);

            if (poolElement.TryGetComponent<Cube>(out var cube))
            {
                cube.PlatformTouched += ReturnCubeToPool;
            }
        }
    }

    private void ReturnCubeToPool(Cube cube)
    {
        cube.PlatformTouched -= ReturnCubeToPool;
        _cubePool.ReturnToPool(cube.gameObject);
    }
}
