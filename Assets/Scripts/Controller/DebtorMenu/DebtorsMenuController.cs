using System.Collections.Generic;
using Model;
using Model.DAO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
	public class DebtorsMenuController : MonoBehaviour
	{


		public void ClickAdd()
		{
			SceneManager.LoadScene("AddDebtor");
		}

		public void ClickBack()
		{
			SceneManager.LoadScene("Start");
		}
	}
}
