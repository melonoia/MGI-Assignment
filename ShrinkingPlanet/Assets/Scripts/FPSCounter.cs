using UnityEngine.UI;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
		public GameObject FPSPanel;
		public Text FPSText;
		
		void Start ()
		{
			FPSText.text = "FPS: 0fps";
			Application.targetFrameRate = 30;
		}
		
		void Update ()
	{
		FPSText.text = "";
		
		// Current FPS value
		if(Menu.isGameStarted)
		{
			float fps = 1 / Time.unscaledDeltaTime;
			FPSText.text = "FPS: " + (int)fps;
			FPSPanel.SetActive(true);
		}
		else
		{
			FPSPanel.SetActive(false);
		}
	}
}
