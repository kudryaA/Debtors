using System;
using System.Collections;
using System.Collections.Generic;
using Model.DAO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransactionContoller : MonoBehaviour
{

	public static bool IsPay;
	public static int DebtorId;

	private InputField InputFieldName;
	private InputField InputFieldAbout;

	void Start()
	{
		InputFieldName = GameObject.Find("InputFieldName").GetComponent<InputField>();
		InputFieldAbout = GameObject.Find("InputFieldAbout").GetComponent<InputField>();
	}

	public void ClickTransaction()
	{
		if (!InputFieldName.text.Equals(""))
		{
			var dao = new UnityPrefsDAO();
			dao.AddTransaction(Convert.ToDouble(InputFieldName.text), DebtorId, InputFieldAbout.text, IsPay);
			SceneManager.LoadScene("DebtorView");
		}
		
	}

	public void ClickBack()
	{
		SceneManager.LoadScene("DebtorView");
	}
}
