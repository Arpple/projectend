using Network;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class TestScene : MonoBehaviour
{
	private SceneLoader _sceneLoader;

	private void Awake()
	{
		_sceneLoader = GetComponent<SceneLoader>();
	}

	private void Start()
	{
		Debug.Log("Start");
	}

	private void Update()
	{
		if (!_sceneLoader.IsReady()) return;
		Debug.Log("Update");
	}
}