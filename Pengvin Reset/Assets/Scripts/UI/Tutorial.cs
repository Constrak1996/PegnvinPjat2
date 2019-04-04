using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tutorialMenu;

    public void OpenTutorial()
    {
        tutorialMenu.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialMenu.SetActive(false);
    }

   
}
