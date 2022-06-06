using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorForTutor : OpenDoor, IDoorFromTutor
{
    public int step;
    [SerializeField] TutorialDisplay _tutorialDisplay;

    public bool OpeningAllowed { get; set; }

    public override void Open()
    {
        if(OpeningAllowed == true)
        {
            base.Open();
            _tutorialDisplay.OnDisplayToTrigger(step);
        }
    }
}
