using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public FMODUnity.EventReference pickUpSnapRef;
    FMOD.Studio.EventInstance snapInstance;
    public FMODUnity.EventReference placeBuildingRef;
    FMOD.Studio.EventInstance placeBuildingInstance;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        snapInstance = FMODUnity.RuntimeManager.CreateInstance(pickUpSnapRef);
        placeBuildingInstance = FMODUnity.RuntimeManager.CreateInstance(placeBuildingRef);
    }
    public void PlaySnapSFX()
    {
        snapInstance.start();
    }
    public void PlayPlaceBuildingSFX()
    {
        snapInstance.start();
    }
    private void OnDestroy()
    {
        placeBuildingInstance.release();
        placeBuildingInstance.release();
    }

}
