using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Xml.Serialization;
using System.IO;

public class GameData : MonoBehaviour
{
	private string fullPath;
	private GameData data = new GameData();

	// What to save
	public float volumeSlider;

	private void Save()
	{
		// set datas score to current
		//data.volumeSlider = 

		//var serializer = new XmlSerializer(typeof(GameData));
		using (var stream = new FileStream(fullPath, FileMode.Create))
		{
			//serializer.Serialize(stream, data);
		}
	}
	private void Load()
	{

	}
}
