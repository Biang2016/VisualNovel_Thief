using UnityEngine;
using UnityEngine.UI;

public class GoodThing : MonoBehaviour
{
    public string GoodName;
    public int Price;
    public Button Button;
    [SerializeField] private string BlockName;

    void Awake()
    {
        Button.onClick.AddListener(OnClick);
    }

    public void GetThat()
    {
        Manager.Instance.TotalGetCoins += Price;
    }

    public void OnClick()
    {
        if (Vector3.Distance(Manager.Instance.Thief.transform.position, transform.position) < 30)
        {
            AudioManager.Instance.SoundPlayIsNoise("Coins");
            GetThat();
            gameObject.SetActive(false);
            Manager.Instance.GoodThingGet(this);
        }
        else
        {
            if (BlockName != "" && Manager.Instance.Flowchart.HasBlock(BlockName))
            {
                Manager.Instance.Flowchart.ExecuteBlock(BlockName);
            }
        }
    }
}