using UnityEngine;
public class UpsetDucksGame : MonoBehaviour
{
	/// <summary>
	/// Setup "Singleton" Design Pattern
	/// </summary>
	private static UpsetDucksGame _instance;
	public static UpsetDucksGame Instance { get { return _instance; } }

	protected void Awake()
	{
		_instance = this;
	}

	protected void Start()
	{
		// Start the catapult
		AddAsteroid();
	}

	private void AddAsteroid()
	{
		if (Catapult.Instance != null)
		{
			Catapult.Instance.AddAsteroid();
		}
	}

	public void DestroyCrate(Crate crate)
	{
		Destroy(crate.gameObject);
	}
}