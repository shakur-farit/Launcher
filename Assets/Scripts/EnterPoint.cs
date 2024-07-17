using System;
using UnityEngine;

public class EnterPoint : MonoBehaviour
{
	private ILauncherStatesSwitcher _laucnherStatesSwitcher;



	private void Awake()
	{
		StartLauncher();
	}

	private void StartLauncher()
	{
		_laucnherStatesSwitcher.SwitchState<LoadStaticDataState>();
	}
}