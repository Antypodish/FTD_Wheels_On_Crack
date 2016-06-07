// *************************************************************************** //
// ***************************** GUI for Wheel ******************************* //
// *************************************************************************** //

// This class is based on PropulsionGUI class ******************************** //

// *************************************************************************** //

// Developed by: ************************************************************* //
// Dobromil Duda ************************************************************* //
// Aproximite Time: ********************************************************** // 
// April 2016 **************************************************************** //

// *************************************************************************** //

// Thank you all for the support in this project and providing Modding Tool ** //

// *************************************************************************** //

// Licence ******************************************************************* //
// This code can be freerly modified and redistribiuted. ********************* //
// Code do not guarntee that is free of error ******************************** //

// *************************************************************************** //

using BrilliantSkies.FromTheDepths.Game.UserInterfaces;
using System;
using UnityEngine;


/*
namespace DriveWheel_Upg
{
	public class WheelGui
	{
		public WheelGui ()
		{
		}
	}
}
*/

//namespace BrilliantSkies.FromTheDepths.Game.UserInterfaces
//namespace DriveWheel_Upg.FromTheDepths.Game.UserInterfaces
//{
public class WheelGUI : ThrowAwayObjectGui<IPropulsionModule>
//public class WheelGUI : ThrowAwayObjectGui<>
{

	public DriveWheel_Upg anc = new DriveWheel_Upg();

	public override void SetGuiSettings()
	{
		this.GuiSettings.QGui = true;
	}

	public override void OnGui()
	{
		GUILayout.BeginArea(new Rect(20f, 20f, 500f, 350f), "Propulsion Block GUI", GUI.skin.window);
		float num = 150f;
		bool flag = false;
		bool flag2 = false;

		if (!this._focus.User.IsOnSubConstructable)
		{
			if (this._focus.OrientationWithRespectToConstruct == enumBlockOrientations.forwards || this._focus.OrientationWithRespectToConstruct == enumBlockOrientations.backwards)
			{
				this._focus.DriveMode = enumPropulsionDriveModes.main;
			}
			else
			{
				flag = GUI.Toggle(new Rect(40f, 40f, num, 30f), this._focus.DriveMode == enumPropulsionDriveModes.thruster, "Thruster");
				flag2 = GUI.Toggle(new Rect(40f + num, 40f, num, 30f), this._focus.DriveMode == enumPropulsionDriveModes.thrusterreverse, "Thruster reverse");
			}
		}
		bool flag3 = GUI.Toggle(new Rect(40f + num + num, 40f, num, 30f), this._focus.DriveMode == enumPropulsionDriveModes.main, "Main");
		bool flag4 = false;
		bool flag5 = false;
		if (!this._focus.User.IsOnSubConstructable && (this._focus.OrientationWithRespectToConstruct == enumBlockOrientations.up || this._focus.OrientationWithRespectToConstruct == enumBlockOrientations.down))
		{
			flag4 = GUI.Toggle(new Rect(40f + num * 0.5f, 70f, num, 30f), this._focus.DriveMode == enumPropulsionDriveModes.roll, "roll (LHS)");
			flag5 = GUI.Toggle(new Rect(40f + num * 0.5f + num, 70f, num, 30f), this._focus.DriveMode == enumPropulsionDriveModes.rollreverse, "roll reverse (RHS)");
		}
		if (flag && this._focus.DriveMode != enumPropulsionDriveModes.thruster)
		{
			this._focus.DriveMode = enumPropulsionDriveModes.thruster;
		}
		else if (flag2 && this._focus.DriveMode != enumPropulsionDriveModes.thrusterreverse)
		{
			this._focus.DriveMode = enumPropulsionDriveModes.thrusterreverse;
		}
		else if (flag3 && this._focus.DriveMode != enumPropulsionDriveModes.main)
		{
			this._focus.DriveMode = enumPropulsionDriveModes.main;
		}
		else if (flag4 && this._focus.DriveMode != enumPropulsionDriveModes.roll)
		{
			this._focus.DriveMode = enumPropulsionDriveModes.roll;
		}
		else if (flag5 && this._focus.DriveMode != enumPropulsionDriveModes.rollreverse)
		{
			this._focus.DriveMode = enumPropulsionDriveModes.rollreverse;
		}
		string text = null;
		enumPropulsionDriveModes driveMode = this._focus.DriveMode;
		if (driveMode == enumPropulsionDriveModes.thruster)
		{
			text = this.ThrusterDescription();
		}
		else if (driveMode == enumPropulsionDriveModes.thrusterreverse)
		{
			text = this.ThrusterReverseDescription();
		}
		else if (driveMode == enumPropulsionDriveModes.roll)
		{
			text = this.RollDescription();
		}
		else if (driveMode == enumPropulsionDriveModes.rollreverse)
		{
			text = this.RollReverseDescription();
		}
		else if (driveMode == enumPropulsionDriveModes.main)
		{
			text = "Runs with the main forwards facing propulsion systems";
		}
		string text2 = string.Concat(new object[]
		                             {
			StaticMaths.R2(this._focus.DirectForceFraction * 100f),
			" % applied directly behind the centre of mass.\n",
			StaticMaths.R2((1f - this._focus.DirectForceFraction) * 100f),
			"% applied from the block's position"
		});
		string text3 = StaticMaths.R2(this._focus.PlacementForceFraction * 100f) + "% of maximum force attainable due to placement of this block";
		GUI.Label(new Rect(40f, 100f, 400f, 100f), text);
		GUI.Label(new Rect(40f, 180f, 400f, 100f), text2);
		GUI.Label(new Rect(40f, 280f, 400f, 100f), text3);
		GUISliders.TotalWidthOfWindow = 500;
		GUISliders.TextWidth = 180;
		GUISliders.DecimalPlaces = 1;
		GUISliders.UpperMargin = 320;
		this._focus.PowerScale = GUISliders.DisplaySlider(0, "Drive fraction:", this._focus.PowerScale, 0f, 1f, enumMinMax.none, new ToolTip("Adjust the thrust (and power usage) of this engine. Useful for fine balancing of aircraft", 12, false));
		if (GUI.Button(new Rect(40f, 470f, 100f, 60f), "Copy to clipboard"))
		{
			PropulsionModuleClipboard.CopyPropulsionToClipboard(this._focus);
		}
		if (PropulsionModuleClipboard.default_propulsion_set)
		{
			if (GUI.Button(new Rect(160f, 470f, 100f, 60f), "Paste from clipboard"))
			{
				PropulsionModuleClipboard.PastePropulsionFromClipboard(this._focus);
			}
		}
		else
		{
			GUI.Button(new Rect(160f, 470f, 100f, 60f), "Paste from clipboard", "buttongrey");
		}
		if (GUI.Button(new Rect(380f, 470f, 100f, 60f), "Exit"))
		{
			this.DeactivateGui(GuiDeactivateType.Standard);
		}

		GUILayout.EndArea();


		/*
		//WheelSettingsGUI.WheelSettingsGui( );


		//GUILayout.BeginArea(new Rect(20f, 20f, 500f, 450f), "Propulsion Block GUI", GUI.skin.window);
		GUILayout.BeginArea(new Rect(20f, 500f, 500f, 300f), "Whhel Settings GUI: " + this._focus.User.name, GUI.skin.window);
		//GUILayout.BeginArea(new Rect(10f, 40f, 600, 300f), "Color", GUI.skin.window) ;
		
		GUISliders.TotalWidthOfWindow = 500;
		GUISliders.TextWidth = 100;
		GUISliders.UpperMargin = 40;
		GUISliders.DecimalPlaces = 2;
		//float OtherVal = 0.1f ;
		//this.SetBlue (GUISliders.DisplaySlider (2, "Blue: ", this._blue, 0f, 1f, enumMinMax.none, null), true);
		//this.imaginary (GUISliders.DisplaySlider (2, "Blue: ", this.imaginary, 0f, 1f, enumMinMax.none, null), true);
		
		int GUISIndex = 0;

		float SuspensionDistance = this._focus.User.GetParameters1().x ; 
		//this.anc = this._focus.

		this.anc.MaxThrustMultipler = GUISliders.DisplaySlider (GUISIndex, "MaxThrustMultipler: ", this.anc.MaxThrustMultipler, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;
		this.anc.Spring = GUISliders.DisplaySlider (GUISIndex, "Spring: ", this.anc.Spring, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;
		SuspensionDistance = GUISliders.DisplaySlider (GUISIndex, "Suspension Distance: ", SuspensionDistance, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;

		this._focus.User.SetParameters1(new Vector4 (SuspensionDistance, this._focus.User.GetParameters1().y, this._focus.User.GetParameters1().z, this._focus.User.GetParameters1().w)) ;


		//bool result = false ;
		
		//this.ApplySuspentionParam () ;
		
		//if (GuiCommon.DisplayCloseButton(360))
		//{
		//	result = true ;
		//}


		GUILayout.EndArea() ;
		//return result ;
		*/





			



		/*
		if (_focus.User.ExtraGUI())
		{
			DeactivateGui() ;
			return ;
		}
		*/

		if (this._focus.OptionalControlModule != null && ControllableBlockGUIPanel.InputPanel(this._focus.OptionalControlModule, true))
		{
			this.DeactivateGui(GuiDeactivateType.Standard);
		}
	}
	
		public string ThrusterDescription()
		{
		string result = string.Empty;
		enumBlockOrientations orientationWithRespectToConstruct = this._focus.OrientationWithRespectToConstruct;
		if (orientationWithRespectToConstruct == enumBlockOrientations.up)
		{
			result = "This upwards facing " + this._focus.Name + " will be activated with \"U\".";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.down)
		{
			result = "This downwards facing " + this._focus.Name + " will be activated with \"J\".";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.forwards)
		{
			result = "Given the forwards orientation of this " + this._focus.Name + " the mode makes no difference.";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.left)
		{
			result = "This left facing " + this._focus.Name + " will be activated with \"H\" in water mode or \"Y\" in air mode";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.right)
		{
			result = "This right facing " + this._focus.Name + " will be activated with \"K\" in water mode or \"I\" in air mode";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.backwards)
		{
			result = "Given the backwards facing orientation of this " + this._focus.Name + " it cannot be controlled in thruster mode.";
		}
		return result;
	}
	
	public string ThrusterReverseDescription()
	{
		string result = string.Empty;
		enumBlockOrientations orientationWithRespectToConstruct = this._focus.OrientationWithRespectToConstruct;
		if (orientationWithRespectToConstruct == enumBlockOrientations.up)
		{
			result = "This upwards facing " + this._focus.Name + " will be activated with \"J\".";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.down)
		{
			result = "This downwards facing " + this._focus.Name + " will be activated with \"U\".";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.forwards)
		{
			result = "Given the forwards orientation of this " + this._focus.Name + " the mode makes no difference.";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.left)
		{
			result = "This left facing " + this._focus.Name + " will be activated with \"K\" in water mode or \"I\" in air mode.";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.right)
		{
			result = "This right facing " + this._focus.Name + " will be activated with \"H\" in water mode or \"Y\" in air mode.";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.backwards)
		{
			result = "Given the backwards facing orientation of this " + this._focus.Name + " it cannot be controlled in reverse thruster mode.";
		}
		return result;
	}
	
	public string RollDescription()
	{
		string result = string.Empty;
		enumBlockOrientations orientationWithRespectToConstruct = this._focus.OrientationWithRespectToConstruct;
		if (orientationWithRespectToConstruct == enumBlockOrientations.up)
		{
			result = "This upwards facing " + this._focus.Name + " will be positively activated with \"H\" and negatively activated with \"K\". Use for components on the left hand side of the vehicle";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.down)
		{
			result = "This downwards facing " + this._focus.Name + " will be positively activated with \"K\" and negatively activated with \"H\". Use for components on the left hand side of the vehicle";
		}
		return result;
	}
	
	public string RollReverseDescription()
	{
		string result = string.Empty;
		enumBlockOrientations orientationWithRespectToConstruct = this._focus.OrientationWithRespectToConstruct;
		if (orientationWithRespectToConstruct == enumBlockOrientations.up)
		{
			result = "This upwards facing " + this._focus.Name + " will be activated with \"K\" and negatively activated with \"H\". Use for components on the right hand side of the vehicle";
		}
		else if (orientationWithRespectToConstruct == enumBlockOrientations.down)
		{
			result = "This downwards facing " + this._focus.Name + " will be activated with \"H\" and negatively activated with \"K\". Use for components on the right hand side of the vehicle";
		}
		return result;
	}
}
//}


