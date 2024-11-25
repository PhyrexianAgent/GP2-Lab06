using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private FloatEventChannel staminaChannel;
    [SerializeField, Min(0)] private float maxStamina, sprintDrain, walkingGain, standingGain;
    private float currentStamina;
    
    void Awake(){
        currentStamina = maxStamina;
    }
    void Start()
    {
        PublishStaminaPercentage();
    }
    public void ChangeStaminaFromMovement(bool isMoving, bool sprintPressed){
        if (isMoving){
            if (sprintPressed)
                currentStamina -= sprintDrain;
            else
                currentStamina += walkingGain;
        }
        else
            currentStamina += standingGain;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        PublishStaminaPercentage();
    }
    public bool CanRun() => currentStamina > 0;
    public bool IsFull() => currentStamina == maxStamina;

    void PublishStaminaPercentage(){
        staminaChannel?.Invoke(currentStamina / maxStamina);
    }
}
