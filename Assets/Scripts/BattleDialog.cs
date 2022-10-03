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

    private Entity refEntity;

    public void InitializeReward(Entity entity, bool isReward)
    {
        refEntity = entity;
        Title.text = "You Won!";
        if (!entity.IsEndOfContent)
        {
            Description.text = entity.LossDialog + "\n\nRewards:\nUnlocked A New Card!\nEarned " + entity.RewardAmount + " Corporate Bucks";
            ButtonText.text = "Collect";
        }
        else
        {
            Description.text = entity.LossDialog + "\n\nNotice:\nYou've been acquired by a much larger coporation!";
            ButtonText.text = "Play Again";
        }
        Icon.sprite = entity.EntitySprite;
        GameInstance.Instance.MainPlayer.ModifyCorporateBucksAmount(entity.RewardAmount);
        GameInstance.Instance.MainPlayer.AddCard(entity.RewardCard);
        gameObject.SetActive(true);
        this.isReward = isReward;        
    }

    public void InitializeGameOver()
    {
        Title.text = "You've Been Laid Off!";
        Description.text = "Not Everyone Can Hack It Here.";
        //Icon.sprite = entity.BattleSprite;
        ButtonText.text = "Reapply";
        gameObject.SetActive(true);
        this.isReward = false;
    }

    public void OnButtonPress()
    {
        if(isReward && refEntity != null && !refEntity.IsEndOfContent)
        {
            SceneManager.LoadScene("MapScene");
        }
        else
        {
            GameInstance.Instance.Reset();
            SceneManager.LoadScene("StartScene");
        }
    }
}
