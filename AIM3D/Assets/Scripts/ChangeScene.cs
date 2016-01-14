using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
    //change scene
	public void ChangeToScene (int sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}

    //quit gimma
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit game");
	}
}
