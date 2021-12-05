using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.AI;
using TheDayAfter.Interfaces;

public class HeroHandleDrone : MonoBehaviour
{
    protected GameObject _drone;

    public GameObject dronePrefab;

    public KeyCode spawnKey = KeyCode.Alpha1;
    public KeyCode patrolKey = KeyCode.Alpha2;
    public KeyCode recallKey = KeyCode.Alpha3;

    public void Spawn()
    {
        if (_drone != null) return;

        _drone = Instantiate(dronePrefab, transform.position, transform.rotation);

        var ownable = _drone.GetComponent<IOwnable>();
        if (ownable != null) ownable.SetOwner(gameObject);

        Recall();
    }

    public void Patrol()
    {
        var patroller = _drone.GetComponent<IPatroller>();
        if (patroller != null) patroller.StartPatrolling();
    }

    public void Recall()
    {
        var patroller = _drone.GetComponent<IPatroller>();
        if (patroller != null) patroller.Recall();
    }

    void Update()
    {
        if (Input.GetKeyDown(patrolKey))
        {
            Patrol();
        }
        if (Input.GetKeyDown(spawnKey))
        {
            Spawn();
        }
        if(Input.GetKeyDown(recallKey))
        {
            Recall();
        }
    }
}
