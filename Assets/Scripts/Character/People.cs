using UnityEngine;
using UnityEngine.UI;

public class People : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private Image SobrietyBar;
    [SerializeField] private Sprite AlertSprite;
    [SerializeField] private Image Alert;

    void Awake()
    {
        Alert.sprite = AlertSprite;
        Alert.gameObject.SetActive(false);
    }

    public float OriSobriety = 200f;
    public float sobriety;

    public float Sobriety
    {
        get { return sobriety; }
        set
        {
            sobriety = value;
            SobrietyBar.fillAmount = sobriety / OriSobriety;
            IsAwake = Sobriety <= 0.05f * OriSobriety;
        }
    }

    public bool isAwake;

    public bool IsAwake
    {
        get { return isAwake; }
        set
        {
            if (!isAwake && value)
            {
                if (ThiefInMyRoom)
                {
                    AudioManager.Instance.SoundPlay(CatchSound.name, false);
                    Manager.Instance.Flowchart.StopAllBlocks();
                    Manager.Instance.Flowchart.ExecuteBlock(CatchBlockName);
                    CatchTimes += 1;
                }
                else
                {
                    AudioManager.Instance.SoundPlay(AwakeSound.name, false);
                }

                AwakeTimes += 1;
            }

            isAwake = value;
            Alert.gameObject.SetActive(isAwake);
        }
    }

    [SerializeField] private string CatchBlockName;

    public bool ThiefInMyRoom = false;

    public int AwakeTimes = 0;
    public int CatchTimes = 0;

    [SerializeField] private AudioClip AwakeSound;
    [SerializeField] private AudioClip CatchSound;

    void Reset()
    {
        Sobriety = OriSobriety;
    }

    void Update()
    {
        if (Sobriety < OriSobriety)
        {
            Sobriety += (OriSobriety - Sobriety) * 0.2f * Time.deltaTime;
        }
    }

    public void ByNoise(Transform thief)
    {
        Sobriety -= Mathf.Min(OriSobriety * 20 / Vector3.Distance(thief.transform.position, transform.position), 3f);
    }
}