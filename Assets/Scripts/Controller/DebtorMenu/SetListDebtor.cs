using System.Collections;
using System.Collections.Generic;
using Model.DAO;
using UnityEngine;

public class SetListDebtor : MonoBehaviour
{

	public GameObject item;

	// Use this for initialization
	void Start ()
	{
		var dao = new UnityPrefsDAO();
		foreach (var id in dao.Debtors)
		{
			var debtor = dao.GetDebotById(id);
			var newObj = Instantiate(item, transform);
			var script = newObj.GetComponent(typeof(ItemDebtor)) as ItemDebtor;
			script.Debtor = debtor;
		}
	}
	
}
