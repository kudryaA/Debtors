using System.Collections;
using System.Collections.Generic;
using Model;
using Model.DAO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebtorViewController : MonoBehaviour
{

	public static Debtor debtor;

	void Start ()
	{
		var TextName = GameObject.Find("TextName").GetComponent<Text>();
		var TextCount = GameObject.Find("TextCount").GetComponent<Text>();
		TextName.text = debtor.Name;
		double count = 0;
		var dao = new UnityPrefsDAO();
		var list = dao.GetTransactionsById(debtor.Id);
		foreach (var item in list)
		{
			count += item.Count;
		}

		TextCount.text = string.Format(count >= 0 ? "<color=#00ff00ff>{0}</color>" : "<color=red>{0}</color>", count);
	}

	public void ClickAbout()
	{
		DebtorInfoController.debtorId = debtor.Id;
		SceneManager.LoadScene("DebtorInfo");
	}

	public void ClickBack()
	{
		SceneManager.LoadScene("DebtorsMenu");
	}

	public void ClickLende()
	{
		TransactionContoller.DebtorId = debtor.Id;
		TransactionContoller.IsPay = false;
		SceneManager.LoadScene("Transaction");
	}

	public void ClickReturn()
	{
		TransactionContoller.DebtorId = debtor.Id;
		TransactionContoller.IsPay = true;
		SceneManager.LoadScene("Transaction");
	}
}
