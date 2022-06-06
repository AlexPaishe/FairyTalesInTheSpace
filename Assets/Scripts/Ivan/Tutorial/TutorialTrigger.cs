using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public int step;
    [SerializeField] private TutorialDisplay _tutorialDisplay;

    private bool _isWorked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isWorked == false)
        {
            if (other.transform.GetComponent<Player>())
            {
                _tutorialDisplay.OnDisplayToTrigger(step);
                _isWorked = true;
            }
        }
    }
}
