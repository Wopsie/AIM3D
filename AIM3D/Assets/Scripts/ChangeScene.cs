using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
	public void ChangeToScene (int sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}

	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit game");
	}
}
