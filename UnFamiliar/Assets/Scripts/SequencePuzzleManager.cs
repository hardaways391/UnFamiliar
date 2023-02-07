using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SequencePuzzleManager : MonoBehaviour
{
    private int buttonsPushed = 0;
    [SerializeField] private Animator gate = null;

    public GameObject sequencePuzzlePanel;

    public List<int> correctSequence = new List<int>();
    public List<int> currentSequence = new();

    public List<GameObject> feedbackImages = new();

    public GameObject image1 = null;
    public GameObject image2 = null;
    public GameObject image3 = null;

    public GameObject passedText;
    public GameObject failedText;

    // Start is called before the first frame update
    void Start()
    {
        passedText.SetActive(false);
        failedText.SetActive(false);
        sequencePuzzlePanel = GameObject.Find("SequencePuzzle"); //set the panel that will pop up
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSequence.SequenceEqual(correctSequence)) //do the sequences match?
        {
            StartCoroutine(PuzzleWon());
        }
        else if (buttonsPushed >= 5) //reset puzzle after we pushed all buttons
        {
            StartCoroutine(PuzzleFailed());
        }
    }

    public void CircleButton()
    {
        currentSequence.Add(1); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        feedbackImages.Add(image1);
    }

    public void SquareButton()
    {
        currentSequence.Add(2); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        feedbackImages.Add(image2);
    }

    public void TriangleButton()
    {
        currentSequence.Add(3); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        feedbackImages.Add(image3);
    }

    public IEnumerator PuzzleWon() //what happens when we win
    {
        gate.Play("OpenGate", 0, 0f);
        passedText.SetActive(true);
        yield return new WaitForSeconds(1.25f); //give the player a min to revel in victory, then move on
        sequencePuzzlePanel.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator PuzzleFailed()
    {
        failedText.SetActive(true);
        buttonsPushed = 0;
        currentSequence.Clear();
        yield return new WaitForSeconds(1.25f); //tell the player they failed, then reset everything
        failedText.SetActive(false);
        sequencePuzzlePanel.SetActive(false);

    }
}
