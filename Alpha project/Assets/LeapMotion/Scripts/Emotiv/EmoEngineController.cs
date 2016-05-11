using UnityEngine;
using System.Collections;
using Emotiv;

public class EmoEngineController
{
	EmoEngine engine = EmoEngine.Instance; 
	EdkDll.IEE_MentalCommandAction_t[] list_action =
		{
		EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL,
		EdkDll.IEE_MentalCommandAction_t.MC_PUSH
		};
	public EmoEngineController()
	{
		EmoEngine engine = EmoEngine.Instance;
	}

	public void SetupDelegate (HandController _handcontroller)
	{
		engine.EmoEngineConnected +=
			new EmoEngine.EmoEngineConnectedEventHandler(engine_EmoEngineConnected);
		engine.EmoEngineDisconnected +=
			new EmoEngine.EmoEngineDisconnectedEventHandler(engine_EmoEngineDisconnected);
		engine.UserAdded +=
			new EmoEngine.UserAddedEventHandler(engine_UserAdded);
		engine.UserRemoved +=
			new EmoEngine.UserRemovedEventHandler(engine_UserRemoved);
		engine.EmoStateUpdated +=
			new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);

		/*For mental command detection*/
		engine.MentalCommandTrainingCompleted += 
			new EmoEngine.MentalCommandTrainingCompletedEventHandler (_handcontroller.engine_MentalCommandTrainingCompleted);
		engine.MentalCommandTrainingRejected +=
			new EmoEngine.MentalCommandTrainingRejectedEventHandler (_handcontroller.engine_MentalCommandTrainingRejected);
		engine.MentalCommandTrainingReset +=
			new EmoEngine.MentalCommandTrainingResetEventHandler (_handcontroller.engine_MentalCommandTrainingReset);
		engine.MentalCommandTrainingStarted +=
			new EmoEngine.MentalCommandTrainingStartedEventEventHandler (_handcontroller.engine_MentalCommandTrainingStarted);
		engine.MentalCommandTrainingSucceeded +=
			new EmoEngine.MentalCommandTrainingSucceededEventHandler (_handcontroller.engine_MentalCommandTrainingSucceeded);
		engine.MentalCommandTrainingFailed +=
			new EmoEngine.MentalCommandTrainingFailedEventHandler (_handcontroller.engine_MentalCommandTrainingFailed);
		engine.MentalCommandTrainingDataErased +=
			new EmoEngine.MentalCommandTrainingDataErasedEventHandler (_handcontroller.engine_MentalCommandTrainingErased);
		engine.MentalCommandEmoStateUpdated +=
			new EmoEngine.MentalCommandEmoStateUpdatedEventHandler (_handcontroller.engine_MentalCommandEmoStateUpdated);
	}

	static void engine_EmoEngineConnected(object sender, EmoEngineEventArgs e)
	{
		Debug.LogWarning ("Engine Connected");
	}

	static void engine_EmoEngineDisconnected(object sender, EmoEngineEventArgs e)
	{
		
	}
	static void engine_UserAdded(object sender, EmoEngineEventArgs e)
	{
		Debug.LogWarning ("User Added");
	}
	static void engine_UserRemoved(object sender, EmoEngineEventArgs e)
	{
		Debug.LogWarning ("User Removed");
	}

	static void engine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
	{
		EmoState es = e.emoState;

	}  

	public void ConnectEngine()
	{
	    engine.Connect ();
	}

	public void ProcessEvent()
	{
		engine.ProcessEvents (1000);
	}

	public void TrainingAction(int index_action)
	{
		if (list_action[index_action] != EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL)
			engine.MentalCommandSetActiveActions ((uint)0, (uint)list_action[index_action]);
		engine.MentalCommandSetTrainingAction ((uint)0, list_action[index_action]);
		engine.MentalCommandSetTrainingControl (0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
	}

	public void isAcceptTraining(bool value)
	{
		if(value)
			engine.MentalCommandSetTrainingControl (0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_ACCEPT);
		else
			engine.MentalCommandSetTrainingControl (0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_REJECT);
	}

	public bool isTrainingNeutral()
	{
		uint trained_action = engine.MentalCommandGetTrainedSignatureActions (0);
		return (((trained_action) & (uint)EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL) != 0);
	}
		
}

