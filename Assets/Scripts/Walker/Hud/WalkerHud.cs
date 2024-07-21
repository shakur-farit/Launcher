using System;
using Infrastructure.Services.Score;
using TMPro;
using UnityEngine;
using Zenject;

public class WalkerHud : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _timerText;
		
	private ITimerService _timerService;
	private ITimerFormater _formater;

	[Inject]
	public void Constructor(ITimerService timerService, ITimerFormater formater)
	{
		_timerService = timerService;
		_formater = formater;
	}

	private void OnEnable() => 
		_timerService.TimeUpdated += UpdateTimerText;

	private void OnDisable() => 
		_timerService.TimeUpdated -= UpdateTimerText;

	private void Start() => 
		UpdateTimerText(_timerService.TimeElapsed);

	private void UpdateTimerText(int timeElapsed) => 
		_timerText.text = _formater.GetFormattedTime(_timerService.TimeElapsed);
}