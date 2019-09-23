using UnityEngine;
using UnityEngine.UI;

public class GoodThing : MonoBehaviour
{
    [SerializeField] private string GoodName;
    [SerializeField] private int Price;
    [SerializeField] private Button Button;
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