using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float quickAccelerateMultiplier = 20f;
    [SerializeField] private Movement playerCharacter;

    [Tooltip("The transform used to define where the water level is for this scene, if any.")]
    [SerializeField] private Transform waterLevel;

    private Vector3 playerStartLocation;
    private bool debugQuickAccelerate;
    private float defaultFixedDeltaTime;

    private void Start()
    {
        if (playerCharacter != null)
        {
            playerStartLocation = playerCharacter.transform.position;
            playerCharacter.WaterLevel = waterLevel;
        }
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        // If going below 1.0, also adjust fixed delta time so we continue updating smoothly
        // At higher speeds we need to keep it the same so we update more times (avoid collision trouble)
        Time.fixedDeltaTime = Mathf.Min(defaultFixedDeltaTime, defaultFixedDeltaTime * timeScale);
    }

    private void FixedUpdate()
    {
        if (debugQuickAccelerate)
        {
            if (playerCharacter != null && !playerCharacter.IsSpinDashing)
            {
                if (playerCharacter.Grounded)
                {
                    float acceleration = playerCharacter.CurrentMovementSettings.GroundAcceleration * quickAccelerateMultiplier;
                    playerCharacter.GroundSpeed = Mathf.Clamp(playerCharacter.GroundSpeed + (playerCharacter.FacingDirection * acceleration) * Time.deltaTime, -playerCharacter.GlobalSpeedLimit, playerCharacter.GlobalSpeedLimit);
                }
                else
                {
                    float acceleration = playerCharacter.CurrentMovementSettings.AirAcceleration * quickAccelerateMultiplier;
                    Vector2 newVelocity = playerCharacter.Velocity;
                    newVelocity.x = Mathf.Clamp(newVelocity.x + (playerCharacter.FacingDirection * acceleration) * Time.deltaTime, -playerCharacter.GlobalSpeedLimit, playerCharacter.GlobalSpeedLimit);
                    playerCharacter.Velocity = newVelocity;
                }
            }
        }
    }
}