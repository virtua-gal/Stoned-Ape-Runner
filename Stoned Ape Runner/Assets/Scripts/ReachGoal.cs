using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachGoal : MonoBehaviour
{
    public UnityEvent reachGoal;
    
    void Start()
    {
        if (reachGoal == null)
            reachGoal = new UnityEvent();

        reachGoal.AddListener(DoSomething);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            reachGoal.Invoke();
        }
    }

    void DoSomething()
    {
        print("reached goal");
    }

}
