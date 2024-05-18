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

	public void NewGame()
	{
		// TODO: get to know the saved language
		DataPersistenceManager.instance.NewGame();
		DataPersistenceManager.instance.SaveGame();
		SceneManager.LoadScene(startScene);
	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quitting Game");
	}

	public void ContinueGame()
	{
		SceneManager.LoadScene(startScene);
		DataPersistenceManager.instance.LoadGame();
		
	}

    
}
