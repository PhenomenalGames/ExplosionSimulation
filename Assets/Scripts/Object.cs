using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] bool useExplosionForce;

    Data data;
    ObjectObserver objectObserver;
    ObjectController objectController;
    Rigidbody rb;
    Vector3 dir;
   [SerializeField] float factor;
    private void Awake()
    {
        objectObserver = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectObserver>();
        rb = GetComponent<Rigidbody>();
       objectController = GetComponentInParent<ObjectController>();
    }
    private void OnEnable()
    {
        objectObserver.RegisterObject(gameObject);
       objectController.OnExplosion += OnExplosion;
    }
    private void OnDisable()
    {
        objectObserver.UnRegisterObject(gameObject);
        objectController.OnExplosion -= OnExplosion;
    }
    private void Start()
    {
        SetData();
	}
	private void SetData()
    {
        if(useExplosionForce)
            factor = Random.Range(100, 350);

        else
            factor = Random.Range(40, 100);


        data = new Data(factor);
    }
    void OnExplosion(Vector3 explosionCenter)
    {
        rb.isKinematic = false;

        if (useExplosionForce)
        {
            rb.AddExplosionForce(data.Get(), explosionCenter, 0.3f, 0.3f, ForceMode.Impulse);
        }
        else
        {
            dir = (transform.position - explosionCenter).normalized;
            rb.AddForce(dir * data.Get(), ForceMode.Impulse);
        }  
    }
}
