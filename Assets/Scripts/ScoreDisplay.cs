using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    #region Variables
    private Text _text; // The text component attached
    #endregion

    #region Properties

    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        _text.text = string.Format("Score: {0}", GameController.Instance.Score);
    }
    #endregion

    #region Methods

    #endregion

    #region Coroutines

    #endregion
}
