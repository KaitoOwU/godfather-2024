using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        field.placeholder.GetComponent<TMP_Text>().text = new string('_', code.ToString().Length);
    }

    public void CheckCode() => StartCoroutine(CO_CheckCode());

    private IEnumerator CO_CheckCode()
    {
        if (field.text == currentCode.ToString())
        {
            _tFuseArmed.text = string.Empty;
            _tFuseArmed.DOText("FUSIBLE RÉARMÉ", 0.5f);
            _tFuseArmed.DOColor(Color.green, 0.5f);
            _tTextMachin.text = string.Empty;
            toComplete.Complete();
            field.gameObject.SetActive(false);
            _tValidate.gameObject.SetActive(false);
            

            yield return new WaitForSecondsRealtime(2f);
            gameObject.SetActive(false);
            _tFuseArmed.text = "INSÉRER CODE RÉARMEMENT";
            _tFuseArmed.color = Color.red;
            _tTextMachin.text = toComplete.hint;
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
