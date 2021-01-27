using System.Collections;
using UnityEngine;

public class UpsetDuck : MonoBehaviour
{
	[SerializeField]
	private WorldItem _worldItem;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[SerializeField]
	private Sprite _idleSprite;

	[SerializeField]
	private Sprite _hitSprite;

	[SerializeField]
	private Sprite _deadSprite;

	protected void Start()
	{
		_worldItem.OnHealthChange.AddListener(WorldItem_OnHealthChange);
	}

	private void WorldItem_OnHealthChange(float delta)
	{
		if (!_worldItem.IsAlive)
		{
			return;
		}

		if (_worldItem.Health <= 0)
		{
			_spriteRenderer.sprite = _deadSprite;

		}
		else
		{
			if (delta > UpsetDucksConstants.MinUpsetDuckHealthChangeForReaction)
			{
				StartCoroutine(SetSpriteTemporarilyCoroutine(_hitSprite));
			}
		}
	}

	private IEnumerator SetSpriteTemporarilyCoroutine(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
		yield return new WaitForSeconds(UpsetDucksConstants.UpsetDuckSpriteFlickerDelay);

		if (_worldItem.IsAlive)
		{
			_spriteRenderer.sprite = _idleSprite;
		}
	}
}
