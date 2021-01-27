using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    /// <summary>
    /// Setup "Singleton" Design Pattern
    /// </summary>
    private static Catapult _instance;
    public static Catapult Instance { get { return _instance; } }

    [SerializeField]
    private GameObject _asteroidPrefab;

    [SerializeField]
    private GameObject _asteroidParent;

    [SerializeField]
    private GameObject _centerPoint;

    private void Awake()
    {
        _instance = this;
        AddAsteroid();
    }

    public Asteroid AddAsteroid()
    {
        GameObject asteroidGameObject = Instantiate(_asteroidPrefab);
        asteroidGameObject.transform.SetParent(_asteroidParent.transform);
        asteroidGameObject.transform.position = _centerPoint.gameObject.transform.position;

        Asteroid asteroid = asteroidGameObject.GetComponent<Asteroid>();
        asteroid.TargetJoint2D.enabled = true;
        return asteroid;
    }
}
