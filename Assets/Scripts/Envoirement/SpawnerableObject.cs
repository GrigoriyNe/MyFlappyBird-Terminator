using System;
using UnityEngine;

public class SpawnerableObject : MonoBehaviour
{
    public event Action<SpawnerableObject> Returned;

    public void Return(SpawnerableObject obj)
    {
        Returned.Invoke(obj);
    }
}
