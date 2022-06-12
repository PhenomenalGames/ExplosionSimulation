using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data 
{
	private float _forceFactor;
	public float Get()
	{
		return _forceFactor;
	}
	public Data(float forceFactor)
	{
		Debug.Log(forceFactor);
		_forceFactor= forceFactor;
	}
}
