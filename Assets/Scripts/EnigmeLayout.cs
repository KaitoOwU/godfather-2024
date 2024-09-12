using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnigmeLayout : MonoBehaviour
{

    [SerializeField] private TMP_Text _tFuseArmed;
    [SerializeField] private TMP_Text _tValidate;
    [SerializeField] private TMP_Text _tTextMachin;

    public TMP_InputField field;

    [HideInInspector] public int currentCode;
    [HideInInspector] public Enigme toComplete;

    public void Init(int code, Enigme toComplete)
    {
        this.currentCode = code;
        this.toComplete = toComplete;
        gameObject.SetActive(false);
    }

    public void CheckCode() => StartCoroutine(CO_CheckCode());

    private IEnumerator CO_CheckCode()
    {
        if (field.text == currentCode.ToString())
        {
            _tFuseArmed.text = "FUSIBLE RÉARMÉ";
            _tTextMachin.text = "<color=green>Code correct";
            toComplete.Complete();
            field.gameObject.SetActive(false);
            _tValidate.gameObject.SetActive(false);
            

            yield return new WaitForSecondsRealtime(2f);
            gameObject.SetActive(false);
            _tFuseArmed.text = "FUSIBLE RÉARMÉ";
            _tTextMachin.text = "Code de réarmement nécéssaire";
            field.gameObject.SetActive(true);
            _tValidate.gameObject.SetActive(true);
            field.text = string.Empty;
        }
        else
        {
            _tValidate.text = "ERROR";
            yield return new WaitForSecondsRealtime(2f);
            _tValidate.text = "VALIDATE";
        }
    }
    
}
