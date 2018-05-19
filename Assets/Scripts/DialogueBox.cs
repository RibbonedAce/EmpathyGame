using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject box;                                     // The actual dialogue box
    private Coroutine displayRoutine;                           // The current coroutine
    #endregion

    #region Properties
    public static DialogueBox Instance { get; private set; }    // The instance to reference
    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        box.SetActive(false);
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
    #endregion

    #region Methods
    // Display a new dialogue
    public void GiveDialogue(string dialogue)
    {
        if (displayRoutine != null)
        {
            StopCoroutine(displayRoutine);
        }
        displayRoutine = StartCoroutine(DisplayBox(5f, dialogue));
    }
    #endregion

    #region Coroutines
    // Display the dialogue box for set time
    private IEnumerator DisplayBox(float time, string text)
    {
        Text t = box.GetComponentInChildren<Text>();
        box.SetActive(true);
        t.text = text;
        yield return new WaitForSeconds(time);
        t.text = "";
        box.SetActive(false);
    }
    #endregion
}
