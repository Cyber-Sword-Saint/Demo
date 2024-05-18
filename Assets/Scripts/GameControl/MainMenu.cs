using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;

	// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// public void NewGame(int saveSlot)
	// {
	// 	Debug.Log("" + saveSlot);
	// 	DataPersistenceManager.instance.NewGame(saveSlot);
	// 	DataPersistenceManager.instance.SaveGame();
	// 	SceneManager.LoadScene(startScene);
	// }

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quitting Game");
	}

	public void ContinueGame(int saveSlot)
	{
		
		DataPersistenceManager.instance.LoadGame(saveSlot);
		SceneManager.LoadScene(startScene);

		// DataPersistenceManager.instance.SaveGame();

	}
}
