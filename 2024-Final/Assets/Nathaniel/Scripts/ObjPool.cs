using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjPool : MonoBehaviour
{
    Transform spawnPoint;
    Transform destroyPoint;
    Vector3 spawnOffset = new Vector3(0, 0.1f, 0);
    [SerializeField] PooledObject objToSpawn;
    public IObjectPool<PooledObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        //Get spawn and destroy locations
        var transforms = GetComponentsInChildren<Transform>();
        foreach (Transform t in transforms)
        {
            if (t.gameObject.CompareTag("Spawn"))
            {
                spawnPoint = t;
            }
            else if (t.gameObject.CompareTag("Destroy"))
            {
                destroyPoint = t;
            }
        }

        pool = new ObjectPool<PooledObject>(CreateObj, OnGet, OnRelease, OnDestroyObj, maxSize: 5);
        StartCoroutine(SpawnOnTimer());
    }

    //Creates more objects
    private PooledObject CreateObj()
    {
        PooledObject obj = Instantiate(objToSpawn, spawnPoint.position - spawnOffset, spawnPoint.rotation, transform);
        obj.SetPool(pool);
        return obj;
    }

    //Sets a pooled object to active and moves it to the spawn point
    private void OnGet(PooledObject obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = spawnPoint.position;
    }

    //Sets an object to inactive once it is released
    private void OnRelease(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    //Destroys object
    private void OnDestroyObj(PooledObject obj)
    {
        Destroy(obj.gameObject);
    }

    //Spawns a new object every second
    public IEnumerator SpawnOnTimer()
    {
        while (true)
        {
            pool.Get();
            yield return new WaitForSeconds(1);
        }
    }
}
