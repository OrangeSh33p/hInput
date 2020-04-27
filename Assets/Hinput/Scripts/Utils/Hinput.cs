﻿// Author : Henri Couvreur for hiloqo, 2019
// Contact : couvreurhenri@gmail.com, hiloqo.games@gmail.com

using System.Collections.Generic;
using HinputClasses;
using HinputClasses.Internal;

/// <summary>
/// The main class of the Hinput package, from which you can access gamepads.
/// </summary>
public static class Hinput {
	// --------------------
	// GAMEPADS
	// --------------------

	private static Gamepad _anyGamepad;
	/// <summary>
	/// A virtual gamepad that returns the inputs of every gamepad at once.<BR/> <BR/>
	/// Its name, full name, index and type are those of the gamepad that is currently being pushed (except if you use
	/// "internal" properties). This gamepad returns the biggest value for buttons and triggers, and averages every
	/// pushed stick. For instance:<BR/>
	/// - If player 1 pushed their A button and player 2 pushed their B button, both the A and the B button of
	/// anyGamepad will be pressed.<BR/>
	/// - If player 1 pushed their left trigger by 0.24 and player 2 pushed theirs by 0.46, the left trigger of
	/// anyGamepad will have a position of 0.46.<BR/>
	/// - If player 1 positioned their right stick at (-0.21, 0.88) and player 2 has theirs at (0.67, 0.26), the right
	/// stick of anyGamepad will have a position of (0.23, 0.57).
	/// </summary>
	public static Gamepad anyGamepad { 
		get { 
			Updater.CheckInstance();
			if (_anyGamepad == null) {
				_anyGamepad = new AnyGamepad();
			} else {
				Updater.UpdateGamepads ();
			}

			return _anyGamepad; 
		}
	}

	private static List<Gamepad> _gamepad;
	/// <summary>
	/// A list of 8 gamepads, labelled 0 to 7.
	/// </summary>
	/// <remarks>
	/// Gamepad disconnects are handled by the driver, and as such will yield different results depending on your operating system.
	/// </remarks>
	public static List<Gamepad> gamepad { 
		get {
			Updater.CheckInstance();
			if (_gamepad == null) {
				_gamepad = new List<Gamepad>();
				for (int i=0; i<Utils.maxGamepads; i++) _gamepad.Add(new Gamepad(i));
			} else {
				Updater.UpdateGamepads ();
			} 

			return _gamepad; 
		} 
	}
	
	/// <summary>
	/// A virtual button that returns every input of every gamepad at once.
	/// It shares its name, full name and gamepad with the input that is currently being pushed (except if you use
	/// "internal" properties).
	/// </summary>
	public static Pressable anyInput { get { return anyGamepad.anyInput; } }
}