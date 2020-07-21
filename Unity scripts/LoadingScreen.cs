using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// controls the loading bar on loading screen
public class LoadingScreen : MonoBehaviour {

	public Image loadingbar;
	
	private AsyncOperation async = null; 
	
	void Awake(){
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(LoadALevel(2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator LoadALevel(int level) {
		async = Application.LoadLevelAsync(level);
		yield return async;
		async = null;
		yield break;
	}
	
	void OnGUI() {
		if (async != null) {
				loadingbar.fillAmount = async.progress;
		}

	}
}
