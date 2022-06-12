using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectController : MonoBehaviour
{
    enum States { ReadyForExplosion, ExplosionFast, ExplosionSlow };
    [SerializeField] States CurrentState;
    public Action<Vector3> OnExplosion;
    ObjectObserver objectObserver;
    [SerializeField] Vector3 explosionCenter;
    [SerializeField] GameObject explosionCenterTransform;
    private void Awake()
    {
        objectObserver = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectObserver>();
        CurrentState = States.ReadyForExplosion;
    }

    void FindExplosionCenter()
    {
        Vector3 sumVector = new Vector3(0f, 0f, 0f);

        foreach (Transform child in transform)
        {
            sumVector += child.position;
        }

        explosionCenter = sumVector / transform.childCount;

        explosionCenterTransform.transform.position = explosionCenter;
    }
    public void Action()
    {
        if (CurrentState == States.ReadyForExplosion)
        {
            Explosion();
            return;
        }

        else if (CurrentState == States.ExplosionFast)
        { ExplosionSlow(); return; }



        else if (CurrentState != States.ExplosionFast)
        { ExplosionFast(); return; }

    }
    void Explosion()
    {
        Debug.Log("Explosion");
        FindExplosionCenter();
        OnExplosion?.Invoke(explosionCenter);
        ChangeState(CurrentState);
    }
    void ChangeState(States currentState)
    {
        if (CurrentState == States.ReadyForExplosion)
        {
            CurrentState = States.ExplosionFast;
            return;
        }
        if (CurrentState == States.ExplosionFast)
        {
            CurrentState = States.ExplosionSlow;
            return;
        }
        if (CurrentState == States.ExplosionSlow)
        {
            CurrentState = States.ExplosionFast;
            return;
        }
    }
    void ExplosionFast()
    {
        Debug.Log("fast");

        GameManager.Instance.FastGame();
        ChangeState(CurrentState);

    }
    void ExplosionSlow()
    {
        Debug.Log("slow");
       GameManager.Instance.SlowGame();
        ChangeState(CurrentState);
    }
}

