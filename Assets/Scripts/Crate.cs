using UnityEngine;

public class Crate : MonoBehaviour
{
	[SerializeField]
	private WorldItem _worldItem;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	//Disable a harmless warning shown by the code editor
#pragma warning disable 0414 // The field is assigned but its value is never used
	[SerializeField]
	private Sprite _idleSprite;
#pragma warning restore

	[SerializeField]
	private Sprite _hitSprite;

	protected void Start()
	{
		_worldItem.OnHealthChange.AddListener(WorldItem_OnHealthChange);
	}

	private void WorldItem_OnHealthChange(float delta)
	{
		if (_worldItem.Health <= 0)
		{
			UpsetDucksGame.Instance.DestroyCrate(this);
		}
		else
		{
			if (delta > UpsetDucksConstants.MinCrateHealthChangeForReaction)
			{
				_spriteRenderer.sprite = _hitSprite;
			}
		}
	}
}
