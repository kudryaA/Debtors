using UnityEngine;

namespace Controller.Money
{
	public class FallingMoney : MonoBehaviour {

		public float fallingSpeed;

		void Update () {
			transform.position -= new Vector3 (0, fallingSpeed * Time.deltaTime);
			if (transform.position.y < -6f) {
				Destroy (gameObject);
			}
		}
	}
}
