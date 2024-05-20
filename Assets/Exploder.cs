using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionRadius = 10;
    [SerializeField] private int _explosionForce = 10;

    public void Explode(Vector3 explosionPosition, Rigidbody[] affectedObjects)
    {
        foreach (Rigidbody affectedObject in affectedObjects) 
        {
            affectedObject.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
        }
    }
}
