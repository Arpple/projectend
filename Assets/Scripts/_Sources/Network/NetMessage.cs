using UnityEngine.Networking;

namespace End
{
	public static class NetMessage
	{
		class NormalMessage : MessageBase { }

		public static short MsgServerFull = MsgType.Highest + 1;
		public static bool SendServerIsFull(this NetworkConnection conn)
		{
			return conn.Send(MsgServerFull, new NormalMessage());
		}

		public static short MsgGameStarted = MsgType.Highest + 1;
		public static bool SendGameStarted(this NetworkConnection conn)
		{
			return conn.Send(MsgGameStarted, new NormalMessage());
		}

		public class PlayerCountMessage : MessageBase
		{
			public int Count;
		}

		public static short MsgPlayerCount = MsgType.Highest + 1;
		public static bool SendPlayerCount(int count)
		{
			var msg = new PlayerCountMessage()
			{
				Count = count
			};
			return NetworkServer.SendToAll(MsgPlayerCount, msg);
		}

	}

}
