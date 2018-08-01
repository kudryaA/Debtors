using UnityEngine;

namespace Controller.Money
{
	public class ClickDestroy : MonoBehaviour {

		void OnMouseDown() {
			Destroy (gameObject);
		}
	}
}
