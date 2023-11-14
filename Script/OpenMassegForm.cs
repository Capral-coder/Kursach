using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMassegForm : MonoBehaviour
{
    [SerializeField] GameObject messegeForm;

    public void ButtonMessegeForm()
    {
        messegeForm.SetActive(true);
    }

    public void Button_Exit_Form()
    {
        messegeForm.SetActive(false);
    }
}
