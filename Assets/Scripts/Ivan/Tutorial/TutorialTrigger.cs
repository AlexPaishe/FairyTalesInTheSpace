using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private int _step;
    [SerializeField] private TutorialDisplay _tutorialDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            _tutorialDisplay.OnDisplay(_step);
            Destroy(gameObject);
        }
    }
}
