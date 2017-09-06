using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}