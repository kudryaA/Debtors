using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
	public class StartClickController : MonoBehaviour {


		void Start()
		{
			Screen.fullScreen = false;
		}

		public void ClickExit()
		{
			Application.Quit();
		}

		public void ClickOpenWeb()
		{
			System.Diagnostics.Process.Start("http://google.com");
		}

		public void ClickNext()
		{
			SceneManager.LoadScene("DebtorsMenu");
		}
	}
}
