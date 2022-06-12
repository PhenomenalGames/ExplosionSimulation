using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectPooling : GenericSingletonClass<ObjectPooling>
{
   // [SerializeField] int objectCount;
    [SerializeField] GameObject objectPrefab;
    [SerializeField] Transform objectParent;


    [SerializeField] Transform buildTransform;
    [SerializeField] int rows, columns, depth;
    [SerializeField] float padding;

    [SerializeField] Queue<GameObject> objectQueue =new Queue<GameObject>();
    [SerializeField] bool shouldInstantiate;

    private void Awake()
    {
       if(shouldInstantiate)
        CreateCubeShape();

    }
   

    public void CreateCubeShape()
    {
        GameObject spawnedObject=null;
        for (int i = 0; i < depth; i++)
        {
           
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    Vector3 pos = new Vector3(buildTransform.position.x+k * padding, buildTransform.position.y + j * padding, buildTransform.position.z + i * padding);
                     spawnedObject= Instantiate(objectPrefab, objectParent);
                    spawnedObject.transform.position = pos;
                    objectQueue.Enqueue(spawnedObject);
                }
            }
        }
    }
    GameObject GetObject()
    {
        return objectQueue.Dequeue();
    }
}
