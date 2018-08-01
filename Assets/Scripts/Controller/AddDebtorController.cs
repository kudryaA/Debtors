using System.Collections;
using System.Collections.Generic;
using Model.DAO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddDebtorController : MonoBehaviour
{

	public InputField InputFieldName;
	public InputField InputFieldAbout;
	
	public void ClickAdd()
	{
		var name = InputFieldName.text;
		if (!name.Equals(""))
		{
			var about = InputFieldAbout.text;
			var dao = new UnityPrefsDAO();
			dao.AddDebtor(name, about);
			SceneManager.LoadScene("DebtorsMenu");
		}
		
	}
	
	public void ClickBack()
	{
		SceneManager.LoadScene("DebtorsMenu");
	}
}
