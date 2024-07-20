using System;
using System.IO;
using Data;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
	public class SaveLoadService : ISaveService, ILoadService
	{
		private readonly string _savePath = Path.Combine(Application.persistentDataPath, "savefile.json");


		public void SaveProgress(Progress progress)
		{
			try
			{
				string json = JsonUtility.ToJson(progress);
				File.WriteAllText(_savePath, json);
				Debug.Log("Save");
			}
			catch (Exception e)
			{
				Debug.LogError("Failed to save progress: " + e.Message);
			}
		}

		public Progress LoadProgress()
		{
			if (File.Exists(_savePath))
			{
				try
				{
					string json = File.ReadAllText(_savePath);
					Progress progress = JsonUtility.FromJson<Progress>(json);
					return progress;
				}
				catch (Exception e)
				{
					Debug.LogError("Failed to load progress: " + e.Message);
					return new Progress();
				}
			}

			Debug.LogWarning("Save file not found. Returning null.");
			return null;
		}
	}
}