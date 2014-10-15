using UnityEngine;

/// <summary>
/// A custom handler that also hides the wireframe-renderer in the smart terrain
/// </summary>
public class TrackingHint : MonoBehaviour,
                                            ITrackableEventHandler
{
    private StateManager SM;

    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    
    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        SM = GameObject.Find("Manager").GetComponent<StateManager>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
    	//ARHint.SetActive(false);
        SM.ToggleInstructions(false);

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    private void OnTrackingLost()
    {
    	//ARHint.SetActive(true);
        SM.ToggleInstructions(true);
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    #endregion // PRIVATE_METHODS
}
