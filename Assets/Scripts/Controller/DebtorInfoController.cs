using System.Collections;
using System.Collections.Generic;
using Model.DAO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebtorInfoController : MonoBehaviour
{

	public Text TextAbout;

	public static int debtorId;
	public GameObject example;
	public GameObject Content;

	void Start()
	{
		var dao = new UnityPrefsDAO();
		var debtor = dao.GetDebotById(debtorId);
		TextAbout.text = debtor.About;
		var list = dao.GetTransactionsById(debtorId);
		foreach (var item in list)
		{
			var newObj = Instantiate(example, Content.transform);
			var line1 = string.Format(item.Count >= 0 ? "<color=#00ff00ff>{0}</color>" : "<color=red>{0}</color>", item.Count);
			var line2 = string.Format(item.Count >= 0 ? "<color=#00ff00ff>{0}</color>" : "<color=red>{0}</color>", item.About);
			newObj.GetComponent<Text>().text = line1 + "\n" + line2;
		}
	}

	public void ClickBack()
	{
		SceneManager.LoadScene("DebtorView");
	}
}
