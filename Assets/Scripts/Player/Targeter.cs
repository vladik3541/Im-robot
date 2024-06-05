using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    private List<Transform> targets;
    
    public Transform CurrentTarget
    {
        get
        {
            if(targets.Any())
                return targets.First();
            else 
                return null;
        }
    }
    void Start()
    {
        targets = new List<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyHealth enemy))
        {
            targets.Add(enemy.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            targets.Remove(enemy.transform);
        }
    }
}
