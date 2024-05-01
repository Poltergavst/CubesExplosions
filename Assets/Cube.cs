using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _divisionChance = 100;

    [SerializeField]  private Cube _prefab;
    [SerializeField]  private int _explosionRadius = 10, _explosionForce = 10;

    private void OnMouseUpAsButton()
    {
        if (CanBeDivided() == true)
        {
            Divide();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LowerDivisionChance(int previousDivisionChance)
    {
        int reductionFactor = 2;

        _divisionChance = previousDivisionChance / reductionFactor;
    }

    private bool CanBeDivided()
    {
        int maxChance = 100;
        int minChance = 0;

        return Random.Range(minChance, maxChance) <= _divisionChance;
    }

    private void Divide()
    {
        Cube currentCube;

        int minToSpawn = 2;
        int maxToSpawn = 6;
        int cubesToSpawn;

        int scaleDivider = 2;

        cubesToSpawn = Random.Range(minToSpawn, maxToSpawn + 1);

        for (int i = 0; i < cubesToSpawn; i++)
        {
            currentCube = Instantiate(_prefab, transform.position, Quaternion.identity);

            currentCube.transform.localScale = transform.localScale / scaleDivider;
            currentCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            currentCube.LowerDivisionChance(_divisionChance);
            currentCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }
}
