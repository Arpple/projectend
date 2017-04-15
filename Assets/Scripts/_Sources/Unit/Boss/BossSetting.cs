using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class BossSetting
{
	public List<BossData> BossData;

	private CacheList<Boss, BossData> _cacheData;

	public BossSetting()
	{
		_cacheData = new CacheList<Boss, BossData>();
	}

	public BossData GetBossData(Boss boss)
	{
		var data = _cacheData.Get(boss, (c) => BossData.FirstOrDefault(d => d.Type == c));
		if (data == null) throw new MissingReferenceException("Boss data not found : " + boss.ToString());
		return data;
	}
}

