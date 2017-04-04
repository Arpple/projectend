﻿using UnityEngine;
using System.Collections;

public class ClientPlayerLoader : PlayerLoader
{
	private bool _isReady;

	public ClientPlayerLoader()
	{
		_isReady = false;
	}

	public void SetReady()
	{
		_isReady = true;
	}

	public override bool IsReady()
	{
		return _isReady;
	}
}
