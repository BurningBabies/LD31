using UnityEngine;
using System.Collections;

public enum Rule {
    None,
    NoScope360,
    DoubleDamage,
    Glitch,
    CantShoot,
    TooSlow,
    GottaGoFast,
    OneShot
}

public class GameController : MonoBehaviour {
    public UnityEngine.UI.Text ruleText;
    public UnityEngine.UI.Text scoreText;
    public Rule rule = Rule.None;

    ScreenFader fader;
    ScoreController sc;

    void Start() {
        fader = GetComponent<ScreenFader>();
        sc = ScoreController.Get();
    }

    void Update() {
        scoreText.text = "SCORE: " + sc.score.ToString("0");

        if(rule == Rule.TooSlow)
            Time.timeScale = 0.75f;
        else if(rule == Rule.GottaGoFast)
            Time.timeScale = 1.25f;
        else
            Time.timeScale = 1.0f;
    }

    public void ChangeRule() {
        Rule newRule = Rule.None;

        do {
            newRule = (Rule)Random.Range(0, 8);
        } while (rule == newRule || newRule == Rule.None);

        rule = newRule;

        string text = "";
        switch (rule) {
            case Rule.NoScope360:
                text = "CONFUSED, AREN'T YOU?";
                break;
            case Rule.DoubleDamage:
                text = "DOUBLE DAMAGE";
                break;
            case Rule.Glitch:
                text = "GLITCHIN', HUH?";
                break;
            case Rule.CantShoot:
                text = "CAN'T SHOOT";
                break;
            case Rule.TooSlow:
                text = "2 SLOW";
                break;
            case Rule.GottaGoFast:
                text = "GOTTA GO FAST";
                break;
            case Rule.OneShot:
                text = "ONE SHOT ONE KILL";
                break;
            default:
                break;
        }

        ruleText.text = text;
    }

    public void Fail() {
        fader.FadeToBlack();
    }

    public static GameController Get() {
        return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
}
