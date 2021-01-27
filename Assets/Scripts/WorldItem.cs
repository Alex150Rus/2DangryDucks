using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHealthChangeUnityEvent : UnityEvent<float> { }

public class WorldItem : MonoBehaviour
{
    public float Health { get { return _health; } }

    [Range(0, 100)]
    [SerializeField]
    private float _health = 100;

    [Range(0, 1)]
    [SerializeField]
    private float _defense = 1;

    public bool IsAlive = true;

    public OnHealthChangeUnityEvent OnHealthChange = new OnHealthChangeUnityEvent();

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (!IsAlive)
        {
            return;
        }

        float magnitude = collision2D.relativeVelocity.magnitude;

        if (magnitude < UpsetDucksConstants.MinMagnitudeForDamage)
        {
            return;
        }

        float damage = magnitude * 10 / _defense;

        _health -= damage;
        OnHealthChange.Invoke(damage);

        if (_health <= 0)
        {
            _health = 0;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
