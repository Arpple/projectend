using System;

public static class IntegerLoopExtension
{
	/// <summary>
	/// Callback action
	/// </summary>
	public delegate void Callback();

	/// <summary>
	/// Loop callback action for specific count
	/// </summary>
	/// <param name="count">Count.</param>
	/// <param name="callback">Callback.</param>
	public static void Loop(this int count, Callback callback)
	{
		for(int i = 0; i < count; i++)
		{
			callback();
		}
			
	}
		
	/// <summary>
	/// Callback action
	/// </summary>
	/// <param name="index">index of loop</param>>
	public delegate void IndexCallback(int index);

	/// <summary>
	/// Loop the specified count and callback.
	/// </summary>
	/// <param name="count">Count.</param>
	/// <param name="callback">Callback.</param>
	public static void Loop(this int count, IndexCallback callback)
	{
		for(int i = 0; i < count; i++)
		{
			callback(i);
		}
	}
}
