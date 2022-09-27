using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public FMODUnity.EventReference pickUpSnapRef;
    FMOD.Studio.EventInstance snapInstance;
    public FMODUnity.EventReference placeBuildingRef;
    FMOD.Studio.EventInstance placeBuildingInstance;
    public FMODUnity.EventReference ambienceRef;
    FMOD.Studio.EventInstance ambienceInstance;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        snapInstance = FMODUnity.RuntimeManager.CreateInstance(pickUpSnapRef);
        placeBuildingInstance = FMODUnity.RuntimeManager.CreateInstance(placeBuildingRef);
        PlayAmbienceSFX(); //Remove this when you can switch between gameplay states.
                           //Maybe call this function from another script
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
    public void PlayAmbienceSFX()
    {
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(ambienceRef);
        ambienceInstance.start();
    }
}
