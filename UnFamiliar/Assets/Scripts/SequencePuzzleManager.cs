using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SequencePuzzleManager : MonoBehaviour
{
    private int buttonsPushed = 0;
    [SerializeField] private Animator gate = null;
    
    // the panel and UI elements
    public GameObject sequencePuzzlePanel;
    public GameObject passedText;
    public GameObject failedText;

    public Image left; //the placeholders
    public Image middleLeft;
    public Image middle;
    public Image middleRight;
    public Image right;

    public Sprite circle; //fill in the blanks
    public Sprite square;
    public Sprite triangle;


    // the sequence we set in unity, and the sequence input by the player
    public List<int> correctSequence = new List<int>();
    public List<int> currentSequence = new();


    // Start is called before the first frame update
    void Start()
    {
        passedText.SetActive(false);
        failedText.SetActive(false);
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
        if (buttonsPushed == 1)
        {
            left.sprite = circle;
        }
        else if (buttonsPushed == 2)
        {
            middleLeft.sprite = circle;
        }
        else if (buttonsPushed == 3)
        {
            middle.sprite = circle;
        }
        else if (buttonsPushed == 4)
        {
            middleRight.sprite = circle;
        }
        else if (buttonsPushed == 5)
        {
            right.sprite = circle;
        }
    }

    public void SquareButton()
    {
        currentSequence.Add(2); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        if (buttonsPushed == 1)
        {
            left.sprite = square;
        }
        else if (buttonsPushed == 2)
        {
            middleLeft.sprite = square;
        }
        else if (buttonsPushed == 3)
        {
            middle.sprite = square;
        }
        else if (buttonsPushed == 4)
        {
            middleRight.sprite = square;
        }
        else if (buttonsPushed == 5)
        {
            right.sprite = square;
        }
    }

    public void TriangleButton()
    {
        currentSequence.Add(3); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        if (buttonsPushed == 1)
        {
            left.sprite = triangle;
        }
        else if (buttonsPushed == 2)
        {
            middleLeft.sprite = triangle;
        }
        else if (buttonsPushed == 3)
        {
            middle.sprite = triangle;
        }
        else if (buttonsPushed == 4)
        {
            middleRight.sprite = triangle;
        }
        else if (buttonsPushed == 5)
        {
            right.sprite = triangle;
        }
    }

    public IEnumerator PuzzleWon() //what happens when we win
    {
        gate.Play("OpenGate", 0, 0f);
        passedText.SetActive(true); //You Passed!
        yield return new WaitForSeconds(1.25f); //give the player a min to revel in victory, then move on
        if(sequencePuzzlePanel != null)
        {
            sequencePuzzlePanel.SetActive(false);
        }
        yield return new WaitForSeconds(.25f);
        Destroy(this.gameObject);
    }
    public IEnumerator PuzzleFailed()
    {
        failedText.SetActive(true);
        buttonsPushed = 0;
        currentSequence.Clear();
        yield return new WaitForSeconds(1.25f); //tell the player they failed, then reset everything
        failedText.SetActive(false);
        resetSprites();
    }
    
    public void resetSprites()
    {
        left.sprite = null;
        middleLeft.sprite = null;
        middle.sprite = null;
        middleRight.sprite = null;
        right.sprite = null;
    }
}
