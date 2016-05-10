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
			new EmoEngine.MentalCommandTrainingCompletedEventHandler (engine_MentalCommandTrainingCompleted);
		engine.MentalCommandTrainingRejected +=
			new EmoEngine.MentalCommandTrainingRejectedEventHandler (engine_MentalCommandTrainingRejected);
		engine.MentalCommandTrainingReset +=
			new EmoEngine.MentalCommandTrainingResetEventHandler (engine_MentalCommandTrainingReset);
		engine.MentalCommandTrainingStarted +=
			new EmoEngine.MentalCommandTrainingStartedEventEventHandler (engine_MentalCommandTrainingStarted);
		engine.MentalCommandTrainingSucceeded +=
			new EmoEngine.MentalCommandTrainingSucceededEventHandler (engine_MentalCommandTrainingSucceeded);
		engine.MentalCommandTrainingFailed +=
			new EmoEngine.MentalCommandTrainingFailedEventHandler (engine_MentalCommandTrainingFailed);
		engine.MentalCommandTrainingDataErased +=
			new EmoEngine.MentalCommandTrainingDataErasedEventHandler (engine_MentalCommandTrainingErased);
		engine.MentalCommandEmoStateUpdated +=
			new EmoEngine.MentalCommandEmoStateUpdatedEventHandler (engine_MentalCommandEmoStateUpdated);
		
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

	static void engine_MentalCommandTrainingStarted(object sender, EmoEngineEventArgs e)
	{
		
	}

	static void engine_MentalCommandTrainingSucceeded(object sender, EmoEngineEventArgs e)
	{
		
	}

	static void engine_MentalCommandTrainingFailed(object sender, EmoEngineEventArgs e)
	{

	}

	static void engine_MentalCommandTrainingCompleted(object sender, EmoEngineEventArgs e)
	{
		
	}

	static void engine_MentalCommandTrainingRejected(object sender, EmoEngineEventArgs e)
	{
		
	}

	static void engine_MentalCommandTrainingErased(object sender, EmoEngineEventArgs e)
	{

	}

	static void engine_MentalCommandTrainingReset(object sender, EmoEngineEventArgs e)
	{

	}

	static void engine_MentalCommandEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
	{
		
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
			EdkDll.IEE_MentalCommandSetActiveActions (0, (uint)list_action[index_action]);
		EdkDll.IEE_MentalCommandSetTrainingAction (0, list_action[index_action]);
		EdkDll.IEE_MentalCommandSetTrainingControl (0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
	}
		
}

