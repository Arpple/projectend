using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ResourceCardSetting : IndexDataList<Resource, ResourceCardData>
{
	/// <summary>
	/// random weigth for card charge index i equals i+1 charge
	/// </summary>
	[Tooltip("random weigth for card charge index i equals i+1 charge")]
	public List<int> CardChargeWeigth;
}