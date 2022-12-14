using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SizeBuff")]
public class SizeBuff : PowerUpEffect
{
    [Header("SizeBuff Settings")]
    [SerializeField]
    private float sizeMultiplier;
    [SerializeField]
    private float duration;

    Vector3 sizeMult;
    Vector3 sizeDiv;

    private void OnEnable()
    {
        sizeMult = new Vector3(sizeMultiplier, 1, 1);
        sizeDiv = new Vector3(1/sizeMultiplier, 1, 1);
    }

    public override void Apply(Ball ball)
    {
        PlayerController player = ScoresManager.Instance.player;

        player.transform.localScale = Vector3.Scale(player.transform.localScale, sizeMult);

        player.StartCoroutine(DisableBuff(player));

        player.PlayerUsedPowerUp.Invoke(powerUpIcon.texture, duration);
    }

    // Corrotina que desativa o Power Up depois de um tempo
    IEnumerator DisableBuff(PlayerController player)
    {
        yield return new WaitForSeconds(duration);
        player.transform.localScale = Vector3.Scale(player.transform.localScale, sizeDiv);
    }
}
