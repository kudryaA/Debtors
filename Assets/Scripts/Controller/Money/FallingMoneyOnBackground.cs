using System.Collections;
using UnityEngine;

namespace Controller.Money
{
	public class FallingMoneyOnBackground : MonoBehaviour {

		public GameObject coin;
		public GameObject dollar;

		public float border;
		public float hight;
		public float seconds;

		void Start () {
			StartCoroutine (Spawn ());
		}
	
		IEnumerator Spawn() {
			long l = 0;
			while (true) {
				l++;
				Instantiate (dollar, new Vector2 (Random.Range (-border, border), hight), Quaternion.identity);
				if (l % 2 == 0) {
					l = 0;
					Instantiate (coin, new Vector2 (Random.Range (-border, border), hight), Quaternion.identity);
				}
				yield return new WaitForSeconds (seconds);
			}
		}
		


	}
}
