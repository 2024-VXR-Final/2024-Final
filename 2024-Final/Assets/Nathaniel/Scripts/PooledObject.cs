using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent (typeof(Collider))]

public class PooledObject : MonoBehaviour
{
    IObjectPool<PooledObject> objPool;

    public void SetPool(IObjectPool<PooledObject> pool)
    {
        objPool = pool;
    }

    //When there are no cameras pointing at the object, release it from the pool
    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(DespawnTimer());
        }
    }

    //If you see it again before it despawns, it cancels the timer
    private void OnBecameVisible()
    {
        if (gameObject.activeSelf)
        {
            StopAllCoroutines();
        }
    }

    //This should (hopefully) stop errors when you exit play mode
    private void OnApplicationQuit()
    {
        objPool.Release(this);
    }

    private void ReleaseObject()
    {
        objPool.Release(this);
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(3);
        objPool.Release(this);
    }
}