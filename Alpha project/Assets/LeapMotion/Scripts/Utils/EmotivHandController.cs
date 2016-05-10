using UnityEngine;
using System.Collections.Generic;

public class EmotivHandController : MonoBehaviour
{

	public HandModel leftGraphicsModel;
	/** The GameObject containing colliders to use for the left hand or both hands if separateLeftRight is false. */
	//public HandModel leftPhysicsModel;
	/** The graphics hand model to use for the right hand. */
	public HandModel rightGraphicsModel;
	/** The physics hand model to use for the right hand. */
	//public HandModel rightPhysicsModel;
	// If this is null hands will have no parent
	public Transform handParent = null;

	public bool mirrorZAxis = false;

	protected Dictionary<int, HandModel> hand_graphics_;

	protected HandModel CreateHand(HandModel model) {
		HandModel hand_model = Instantiate(model, transform.position, transform.rotation)
			as HandModel;
		hand_model.gameObject.SetActive(true);
		if (handParent != null) {
			hand_model.transform.SetParent(handParent.transform);
		}
		return hand_model;
	}
	// Use this for initialization
	void Start ()
	{
		hand_graphics_ = new Dictionary<int, HandModel>();
		HandModel new_hand = CreateHand(leftGraphicsModel);
		new_hand.MirrorZAxis(mirrorZAxis);

		float hand_scale = 3;
		new_hand.transform.localScale = hand_scale * transform.lossyScale;

		new_hand.InitHand();
		hand_graphics_ [0] = new_hand;
		//new_hand.SetController(this);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public HandModel[] GetAllGraphicsHands() {
		if (hand_graphics_ == null)
			return new HandModel[0];

		HandModel[] models = new HandModel[hand_graphics_.Count];
		hand_graphics_.Values.CopyTo(models, 0);
		return models;
	}
}

