using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
    //change scene
	public void ChangeToScene (int sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}

    public void ChangeSceneAfter()
    {
        StartCoroutine("SwitchScene");
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("WinScene");
    }

    //quit gimma
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit game");
	}
}
