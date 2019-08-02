using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTelling : MonoBehaviour {
	
	//////Story
	public GameObject _story;
	public Text _message; 
 	private List<string> diag=new List<string>();
 	private int Cpt=-1;
	 
	// Use this for initialization
	void Start ()
    {
		diag.Add("So Free but also so Lost...");
		diag.Add("What to do ? ...");
		diag.Add("Where to belong ? ...");
		diag.Add("So the journey begins...");
		diag.Add("of discovering itself..");
		diag.Add("of finding a home..");

	}

	public void StoryTell()
	{	Cpt++;
		if(Cpt<6)
			{
			_message.text=diag[Cpt];
			}
		else{CloseStory(); }
	}
    public void CloseStory()
    {
            UIManager.Instance.SwitchStatePanel(PanelState.OnPlayPanel);

    }

}
