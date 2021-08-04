using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Spwaner : NetworkBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject unitPrefab = null;
    [SerializeField] Transform unitSpawnPoint = null;

    #region Server
    [Command]
    private void CmdSpawn()
    {
        GameObject unitInstance = Instantiate(unitPrefab, unitSpawnPoint.position, unitSpawnPoint.rotation);
        NetworkServer.Spawn(unitInstance, connectionToClient);
    }
    #endregion

    #region Client
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }
        if(!hasAuthority)
        {
            return;
        }
        CmdSpawn();
    }


    #endregion

}
