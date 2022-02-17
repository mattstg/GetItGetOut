using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour
{
	public GunType type;
	private Button yourButton;

	void Start()
	{
		yourButton =GetComponent<Button>();
		yourButton.onClick.AddListener(()=>{ InitialGameSettings.ChangeGunType(type); } );
	}
}
