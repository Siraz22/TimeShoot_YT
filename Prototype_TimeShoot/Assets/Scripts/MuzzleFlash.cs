using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    IEnumerator DisableMuzzle()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine("DisableMuzzle");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 5920f * Time.deltaTime);
    }
}
