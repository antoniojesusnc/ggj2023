using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace EnvironmentInteraction
{
	public class Beam : MonoBehaviour
	{
		[SerializeField]
		private float _delayTime = 6f;
		
		[SerializeField]
		private float _beamTime = 2f;

		[SerializeField]
		private float _targetScale = 2f;

		[SerializeField]
		private float _minimumOpacity = 0.5f;

		[SerializeField]
		private SpriteRenderer _sprite;

		private float _originalScale;
		
		private void Start() {
			// Set minimum opacity as start opacity
			_sprite.color = new Color(1f, 1f, 1f, _minimumOpacity);

			// Start shine loop
			StartCoroutine(ShineCoroutine());

			_originalScale = transform.lossyScale.x;
		}

		public IEnumerator ShineCoroutine() {
			// Set a first random delay, so we avoid all items to shine at the same time
			yield return new WaitForSeconds(Random.Range(_delayTime, _delayTime * 2f));
			// Start shine loop
			while (true) {
				Shine();
				yield return new WaitForSeconds(_delayTime);
			}
		}

		public void Shine() {
			// Fade
			_sprite.DOFade(1f, HalfBeamTime()).onComplete += () => _sprite.DOFade(_minimumOpacity, HalfBeamTime());
			// Scale
			transform.DOScale(_targetScale, HalfBeamTime()).onComplete += () => transform.DOScale(_originalScale, HalfBeamTime());
			// Rotate (The whole delay time, so it is always rotating, 2 loops per second)
			transform.DORotate(new Vector3(0f, 0f, 720f * _delayTime), _delayTime).onComplete += () => transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}

		private float HalfBeamTime() =>
			_beamTime * 0.5f;
	}
}
