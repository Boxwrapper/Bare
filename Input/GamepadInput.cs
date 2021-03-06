using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BareKit.Input
{
	public class GamepadInput : Input
	{
		GamePadState previousState;
		GamePadState currentState;
	    readonly Buttons button;

        /// <summary>
        /// Initializes a new instance of the GamepadInput class.
        /// </summary>
		public GamepadInput() : base(InputState.Unknown)
		{
			previousState = currentState = GamePad.GetState(PlayerIndex.One);
		}

        /// <summary>
        /// Initializes a new instance of the GamepadInput class.
        /// </summary>
        /// <param name="inputState">The state the input device needs to be in for the event to trigger.</param>
        /// <param name="button">The button the GampadInput is listening to.</param>
		public GamepadInput(InputState inputState, Buttons button) : base(inputState)
		{
			previousState = currentState = GamePad.GetState(PlayerIndex.One);
			this.button = button;
		}

		public override void Update()
		{
			base.Update();

			if (currentState.IsConnected)
			{
				switch (TriggerState)
				{
					case InputState.Pressed:
						if (previousState.IsButtonUp(button) && currentState.IsButtonDown(button))
							Trigger();
						break;
					case InputState.Released:
						if (currentState.IsButtonUp(button) && previousState.IsButtonDown(button))
							Trigger();
						break;
					case InputState.Down:
						if (currentState.IsButtonDown(button))
							Trigger();
						break;
				    case InputState.Moved:
				        break;
				    case InputState.Unknown:
				        break;
				    default:
				        throw new ArgumentOutOfRangeException();
				}
			}

			previousState = currentState;
			currentState = GamePad.GetState(PlayerIndex.One);
		}

        /// <summary>
        /// Returns the value indicating whether the gampad is connected.
        /// </summary>
		public bool IsConnected => currentState.IsConnected;

	    /// <summary>
        /// Returns the gampads left stick position vector.
        /// </summary>
		public Vector2 LeftStick => currentState.IsConnected ? currentState.ThumbSticks.Left : new Vector2(0);

	    /// <summary>
        /// Returns the gampads right stick position vector.
        /// </summary>
		public Vector2 RightStick => currentState.IsConnected ? currentState.ThumbSticks.Right : new Vector2(0);

	    /// <summary>
        /// Returns the gampads left trigger position value.
        /// </summary>
		public float LeftTrigger => currentState.IsConnected ? currentState.Triggers.Left : 0;

	    /// <summary>
        /// Returns the gampads right trigger position value.
        /// </summary>
		public float RightTrigger => currentState.IsConnected ? currentState.Triggers.Right : 0;
	}
}
