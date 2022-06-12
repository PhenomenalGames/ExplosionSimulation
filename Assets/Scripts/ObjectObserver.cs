using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectObserver : MonoBehaviour{
  public  List<GameObject> Objects { get { return objects; } }
    [SerializeField] List<GameObject> objects;
    public void RegisterObject(GameObject explosionObject)
    {
        if (!objects.Contains(explosionObject))
        {
            objects.Add(explosionObject);
        }
    }
    public void UnRegisterObject(GameObject explosionObject)
    {
        if (objects.Contains(explosionObject))
        {
            objects.Remove(explosionObject);
        }
    }
}

