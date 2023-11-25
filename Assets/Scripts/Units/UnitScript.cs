using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatusConditions; // This line is important.

public class UnitScript : MonoBehaviour
{
	public List<Status> Conditions = new();
	private List<int> ExpiredConditions = new();
	public int MaxHP = 100;
	public int HP = 100;

	private void Update()
	{
		foreach (var item in Conditions)
		{
			if (item.Process(this))
			{
				ExpiredConditions.Add(Conditions.IndexOf(item));
			}
		}
		Conditions.Reverse();
		foreach (var item in ExpiredConditions)
		{
			Conditions.RemoveAt(item);
		}
		Conditions.Clear();
	}
}
