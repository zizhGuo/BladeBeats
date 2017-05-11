using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    public GameObject genartor;
    public GameObject[] platform;
    public Transform playerPos;
    private TargetGenerator targetGenerator;
    private Vector2 touchAxis;

    public void SetTouchAxis(Vector2 data)
    {
        touchAxis = data;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetGenerator.playerPosIndex == 0)
        {
            if (touchAxis.x > 0 && targetGenerator.ableTeleport)
            {
                playerPos = platform[3].transform;
                targetGenerator.ableTeleport = false;
                targetGenerator.playerPosIndex = 3;
            }
            else
            {
                if (touchAxis.y > 0)
                {
                    playerPos = platform[2].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 2;
                }
                else
                {
                    playerPos = platform[1].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 1;
                }
            }
        }
        else if (targetGenerator.playerPosIndex == 1)
        {
            if (touchAxis.x > 0)
            {
                playerPos = platform[0].transform;
                targetGenerator.ableTeleport = false;
                targetGenerator.playerPosIndex = 0;
            }
            else
            {
                if (touchAxis.y > 0)
                {
                    playerPos = platform[3].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 3;
                }
                else
                {
                    playerPos = platform[2].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 2;
                }
            }
        }
        else if (targetGenerator.playerPosIndex == 2)
        {
            if (touchAxis.x > 0)
            {
                playerPos = platform[1].transform;
                targetGenerator.ableTeleport = false;
                targetGenerator.playerPosIndex = 1;
            }
            else
            {
                if (touchAxis.y > 0)
                {
                    playerPos = platform[0].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 0;
                }
                else
                {
                    playerPos = platform[3].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 3;
                }
            }
        }
        else if (targetGenerator.playerPosIndex == 3)
        {
            if (touchAxis.x > 0)
            {
                playerPos = platform[2].transform;
                targetGenerator.ableTeleport = false;
                targetGenerator.playerPosIndex = 2;
            }
            else
            {
                if (touchAxis.y > 0)
                {
                    playerPos = platform[1].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 1;
                }
                else
                {
                    playerPos = platform[0].transform;
                    targetGenerator.ableTeleport = false;
                    targetGenerator.playerPosIndex = 0;
                }
            }
        }
    }
}
