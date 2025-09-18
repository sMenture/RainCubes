
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool isHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        const int MaximumLifetime = 5;
        const int MinimumLifetime = 5;

        if (isHit) return;

        isHit = true;

        UserUtility userUtility = new UserUtility();

        GetComponent<MeshRenderer>().material.color = userUtility.GenerateRandomColor();
        StartCoroutine(DisableTimer(userUtility.GetRandomValue(MinimumLifetime, MaximumLifetime)));
    }

    private IEnumerator DisableTimer(int delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }
}
