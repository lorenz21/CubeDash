using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour {
	public static int currentScore;
	public static int highScore;


	public static int currentLevel = 1;
	public static int unlockedLevel;

	void Start(){
		DontDestroyOnLoad(gameObject);
	}
	public static void CompleteLevel(){

		if(currentLevel < 2){
			
			SceneManager.LoadScene(currentLevel);
			currentLevel += 1;
			print(currentLevel);
		} else{
			print("You Win!");
		}


	}
}
