using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    [SerializeField] private Color[] colorsArray;
    [SerializeField] private Camera camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ChangeColorCoroutine());
        }
    }

    private void ChangeColorFunction()
    {
        foreach (Color color in colorsArray)
        {
            camera.backgroundColor = color;
        }
    }
    

    private IEnumerator ChangeColorCoroutine()
    {
        foreach (Color color in colorsArray)
        {
            camera.backgroundColor = color;
            yield return new WaitForSeconds(1);
        }
    }
}
