using Infrastructure.Services.Score;
using TMPro;
using UnityEngine;
using Zenject;

public class WalkerHud : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _timerText;
		
	private ITimerService _timerService;

	[Inject]
	public void Constructor(ITimerService timerService) => 
		_timerService = timerService;

	private void OnEnable()
	{
		_timerService.TimeUpdated += UpdateTimerText;
			
		UpdateTimerText(_timerService.TimeElapsed);
	}

	private void OnDisable() => 
		_timerService.TimeUpdated -= UpdateTimerText;

	private void UpdateTimerText(int timeElapsed) => 
		_timerText.text = _timerService.GetFormattedTime();
}