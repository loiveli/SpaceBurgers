using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {

	// Use this for initialization
	public void GraphicsChange (int indexGFX) {
		QualitySettings.SetQualityLevel(indexGFX);
	}
	
	// Update is called once per frame
	public void SoundChange (bool sound) {
		if(sound){

		}
	}
}
