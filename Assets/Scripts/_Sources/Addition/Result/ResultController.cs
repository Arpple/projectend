using Network;
using UnityEngine;

namespace Result
{
	public class ResultController : MonoBehaviour
	{
		private void Start()
		{
			NetworkController.Instance.Stop();
		}
	}
}
