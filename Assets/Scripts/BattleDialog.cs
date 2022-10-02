using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private Image Icon;
    [SerializeField] private TMP_Text ButtonText;
    private bool isReward;

    public void InitializeReward(Entity entity, bool isReward)
    {
            Title.text = "You Won!";
            Description.text = entity.LossDialog + "\n\nRewards:\nUnlocked A New Card!\nEarned " + entity.RewardAmount + " Corporate Bucks";
            Icon.sprite = entity.BattleSprite;
            ButtonText.text = "Collect";
            GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount += entity.RewardAmount;
            gameObject.SetActive(true);
            this.isReward = isReward;        
    }

    public void InitializeGameOver()
    {
            Title.text = "You've Been Laid Off!";
            Description.text = "Not Everyone Can Hack It Here.";
            //Icon.sprite = entity.BattleSprite;
            ButtonText.text = "Click Here To Try Again";
            gameObject.SetActive(true);
            this.isReward = false;        
    }

    public void OnButtonPress()
    {
        if(isReward)
        {
            SceneManager.LoadScene("MapScene");
        }
        else
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
