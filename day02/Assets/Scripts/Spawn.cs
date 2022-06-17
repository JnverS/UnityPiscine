using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnTime;

    public GameObject footmanPrefab;
    public GameObject orcPrefab;

    private Vector3 _offset;
    private GameObject _prefab;
    void Start()
    {
        spawnTime = 10f;
        if (this.CompareTag("CastleHuman"))
        {
            _prefab = footmanPrefab;
        }        
        if (this.CompareTag("CastleOrc"))
        {
            _prefab = orcPrefab;
        }

        _offset = new Vector3(0, 2f, 0);
        _offset = transform.position - _offset;
        StartCoroutine(SpawnTime());
    }

    IEnumerator SpawnTime()
    {
        while (true)
        {
            Instantiate(_prefab, _offset, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
