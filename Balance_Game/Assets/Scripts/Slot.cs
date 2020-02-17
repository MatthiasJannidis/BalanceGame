using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    int blocksUp = 0;
    int blocksDown = 0;
    float spriteHalfHeight = .0f;
    float upBlockHalfHeight = .0f;
    float downBlockHalfHeight = .0f;

    public enum Direction : int
    {
        Up = 1,
        Down = -1
    }

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteHalfHeight = spriteRenderer.sprite.GetBoundsHalfHeight();

        upBlockHalfHeight = settings.upBlockSprite.GetBoundsHalfHeight();
        downBlockHalfHeight = settings.downBlockSprite.GetBoundsHalfHeight();
    }

    void Update()
    {
        Vector3 up = Vector3.up * blocksDown * settings.downBlockWeight;
        Vector3 down = Vector3.down * blocksUp * settings.upBlockWeight; 
        transform.Translate((up + down) * settings.slotSpeed * Time.deltaTime);

        //todo : communicate this to a game controller-like object
        if(transform.position.y > settings.slotBoundaries) 
        {
            Debug.Log("UP PLAYER WON");
        }
        if(transform.position.y < -settings.slotBoundaries) 
        {
            Debug.Log("DOWN PLAYER WON");
        }
    }

    public void AddUpBlock() 
    {
        blocksUp++;
    }

    public void AddDownBlock() 
    {
        blocksDown++;
    }

    public bool InRangeUp(float givenY) 
    {
        float y = (transform.worldToLocalMatrix * new Vector4(transform.position.x, givenY, transform.position.z, 1.0f)).y;
        return y <= NextBlockYUp;
    }

    public float NextBlockYUp 
    { 
        get 
        {
            return (float)blocksUp*upBlockHalfHeight + spriteHalfHeight; 
        } 
    }

    public bool InRangeDown(float givenY)
    {
        float y = (transform.worldToLocalMatrix * new Vector4(transform.position.x, givenY, transform.position.z, 1.0f)).y;
        return y >= NextBlockYDown;
    }

    public float NextBlockYDown
    { 
        get 
        {
            return -((float)blocksDown * downBlockHalfHeight + spriteHalfHeight);
        } 
    }

    
}
