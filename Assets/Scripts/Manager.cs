using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoSingleton<Manager>
{
    public Thief Thief;
    public Flowchart Flowchart;

    [SerializeField] private Text coinText;
    [SerializeField] private Animator GoodThingJumpOutAnimator;
    [SerializeField] private Image GoodThingJumpOutImage;
    [SerializeField] private Text GoodThingJumpOutText;
    [SerializeField] private Text GoodThingJumpOutNameText;

    private int totalGetCoins = 0;

    public int TotalGetCoins
    {
        get { return totalGetCoins; }
        set
        {
            totalGetCoins = value;
            coinText.text = totalGetCoins.ToString();
        }
    }

    public bool AdamSuspect()
    {
        People Adam = AudioManager.Instance.AllPeoples[0];
        if (Adam.CatchTimes >= 1)
        {
            return true;
        }

        return false;
    }

    public bool AdamDaughterSuspect()
    {
        People AdamDt = AudioManager.Instance.AllPeoples[1];
        if (AdamDt.CatchTimes >= 1)
        {
            return true;
        }

        return false;
    }

    public bool MartinSuspect()
    {
        People Martin = AudioManager.Instance.AllPeoples[2];
        if (Martin.CatchTimes >= 1)
        {
            return true;
        }

        return false;
    }

    public bool MartinSonSuspect()
    {
        People MartinSon = AudioManager.Instance.AllPeoples[3];
        if (MartinSon.CatchTimes >= 1)
        {
            return true;
        }

        return false;
    }

    public void EndGameCalculate()
    {
        Flowchart.SetBooleanVariable("OddAdamSuspect", AdamSuspect());
        Flowchart.SetBooleanVariable("OddAdamDtSuspect", AdamDaughterSuspect());
        Flowchart.SetBooleanVariable("CrazyMartinSuspect", MartinSuspect());
        Flowchart.SetBooleanVariable("CrazyMartinSonSuspect", MartinSonSuspect());

        bool evidenceAdam = Flowchart.GetBooleanVariable("EvidenceAdam");
        bool ladder = Flowchart.GetBooleanVariable("EvidenceAdamLadder");
        bool adamGateLocked = Flowchart.GetBooleanVariable("AdamGateLocked");
        evidenceAdam |= ladder || !adamGateLocked;
        Flowchart.SetBooleanVariable("EvidenceAdam", evidenceAdam);
        Flowchart.SetBooleanVariable("AdamSuspect", AdamSuspect() || AdamDaughterSuspect());

        bool evidenceMartin = Flowchart.GetBooleanVariable("EvidenceMartin");
        bool martinGateLocked = Flowchart.GetBooleanVariable("MartinGateLocked");
        evidenceMartin |= !martinGateLocked;
        Flowchart.SetBooleanVariable("EvidenceMartin", evidenceMartin);
        Flowchart.SetBooleanVariable("MartinSuspect", MartinSuspect() || MartinSonSuspect());
    }

    public void GoodThingGet(GoodThing gt)
    {
        GoodThingJumpOutAnimator.SetTrigger("JumpOut");
        GoodThingJumpOutImage.sprite = gt.Button.image.sprite;
        GoodThingJumpOutText.text = gt.Price.ToString();
        GoodThingJumpOutNameText.text = gt.GoodName.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}