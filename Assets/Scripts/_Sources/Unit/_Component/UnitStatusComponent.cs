﻿using Entitas;

[Unit]
public class UnitStatusComponent : IComponent
{
	public int HitPoint;
	public int AttackPower;
	public int AttackRange;
	public int VisionRange;
	public int MoveSpeed;
}