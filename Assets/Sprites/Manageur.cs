using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manageur : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField _field;

    private void Start()
    {
        _field.text = string.Empty;
    }
}
