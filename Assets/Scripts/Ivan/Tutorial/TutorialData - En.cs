using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialData
{
    public string[] StepText { get; private set; }

    public TutorialData()
    {
        StepText = new string[13];

        StepText[0] = "Direct the left stick to control Kos-6's movement \n \n Colorless" +
            " doors open automatically";

        StepText[1] = "To open doors that has a color, you" +
            " have to first pick up a key of a corresponding color \n \n All keys " +
            "you've picked up are shown at top left part of your screen";

        StepText[2] = "Now you can open the Blue Door";

        StepText[3] = "Stand still on portal's platfrom" +
            " to use it";

        StepText[4] = "Portals work in pairs. After entering a portal, you" +
            " appear in another portal on the level that is connected to it \n \n Portals are temporarily " +
            "deactivated after use";

        StepText[5] = "Now you can open all Yellow Doors";

        StepText[6] = "You can seen Energy that powers Kos-6's immortality system in front of you" +
            " - “NEEDLE” \n \n Picking it up, you add time to your counter at the top right part of your screen. " +
            "Kos-6 is Immortal while you have time, however, taking damage will deplete it" +
            "\n \n After timer reaches 0, any damage taken will kill Kos-6";

        StepText[7] = "-Sword KLAD- \n Tap the right stick to make an attack in a circle " +
            "around yourself, dealing 2 points damage. Enemy in front of Kos-6" +
            " will be dealt damage twice. This attack has 2 seconds cooldown \n \n If " +
            "you hold the right stick, Kos-6 will charge up an attack" +
            " for up to 3 seconds. When you let go of the stick" +
            " Kos-6 will dash in chosen direction passing through enemies, " +
            "while dealing from 2 to 8 points of damage depending on " +
            "charge up time \n \n Kos-6 is invulnerable " +
            "to damage during attacks";

        StepText[8] = "-Izlar Dual Pistols- \n Tap the right stick " +
            "to teleport Kos-6 in the direction " +
            "of his movement, passing through enemies, but not walls. This ability has " +
            "2 seconds of cooldown \n \n If you hold the right stick, Kos-6" +
            " will continuously shoot in the chosen direction, dealing 1 point" +
            " of damage in a small radius with each shot and destroying projectiles";

        StepText[9] = "Level ends when the last enemy has been eliminated" +
            ". To learn about all enemies current positions, you may press " +
            " “Discover” button underneath your keys display" +
            "\n \n Now you can open the Red Door and finish the" +
            " tutorial level";

        StepText[10] = "Time that remains on your Immortality counter defines " +
            "your level completion grade \n \n Time spent without Immortality " +
            "is subtracted from that result, so you shouldn't leave " +
            "“NEEDLE” Energy for later";

        StepText[11] = "Here you may choose a Weapon";

        StepText[12] = "-Heavy Blaster Furnace- \n Tap the right stick to launch " +
            "an explosive into the air above Kos-6. It'll fall to the ground" +
            " after 2 seconds and explode dealing 5 points of damage to both enemies and Kos-6." +
            " This attack has 4 seconds cooldown \n \n If you hold " +
            "the right stick, Kos-6 will charge up an attack" +
            "for up to 3 seconds. When you let go of the stick" +
            " Kos-6 will deal from 2 to 8 points of damage" +
            " to enemies in a cone in the chosen direction. Both width " +
            "of the cone and damage depend of charge up time";
    }
}

