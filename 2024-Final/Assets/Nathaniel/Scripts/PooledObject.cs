using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(MeshCollider))]

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
        objPool.Release(this);
    }
}
