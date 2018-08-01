using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemDebtor : MonoBehaviour
{


	private Debtor debtor;
	
	public Debtor Debtor
	{
		set
		{
			GetComponentInChildren<Text>().text = value.Name; 
			debtor = value;
		}
	}

	public void ClickItem()
	{
		DebtorViewController.debtor = debtor;
		SceneManager.LoadScene("DebtorView");
	}

}
