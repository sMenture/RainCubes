using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private bool _isHit = false;
    private MeshRenderer _meshRenderer;

    public event Action<Cube> PlatformTouched;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        const int MaximumLifetime = 5;
        const int MinimumLifetime = 5;

        if (_isHit)
            return;

        if (collision.gameObject.TryGetComponent<Platform>(out var touchPlatform))
        {
            _isHit = true;

            UpdateColor(UserUtility.GenerateRandomColor());
            StartCoroutine(DisableTimer(UserUtility.GetRandomValue(MinimumLifetime, MaximumLifetime)));
        }
    }

    private void UpdateColor(Color newColor)
    {
        _meshRenderer.material.color = newColor;
    }

    private IEnumerator DisableTimer(int delay)
    {
        yield return new WaitForSeconds(delay);

        _isHit = false;
        UpdateColor(UserUtility.ResetColor());
        PlatformTouched?.Invoke(this);
    }
}
