using System.Collections.Generic;
using UnityEngine;

public class BuffPanel : MonoBehaviour
{
	public BuffObject BuffObjectPrefabs;
	public Transform BuffObjectParent;
	private Dictionary<BuffEntity, BuffObject> _buffObjects;

	private void Awake()
	{
		_buffObjects = new Dictionary<BuffEntity, BuffObject>();
	}

	public void AddBuff(BuffEntity buff)
	{
		_buffObjects.Add(buff, CreateBuffObject(buff));
	}

	public void RemoveBuff(BuffEntity buff)
	{
		var obj = GetBuffObject(buff);
		_buffObjects.Remove(buff);
		Destroy(obj.gameObject);
	}

	private BuffObject CreateBuffObject(BuffEntity buff)
	{
		var obj = Instantiate(BuffObjectPrefabs, BuffObjectParent, false);
		obj.SetIconImage(buff.sprite.Sprite);
		return obj;
	}

	private BuffObject GetBuffObject(BuffEntity buff)
	{
		return _buffObjects[buff];
	}
}
