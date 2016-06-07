// *************************************************************************** //
// ***************************** GUI for Wheel ******************************* //
// *************************************************************************** //

// This is attachement to WheelGUI class ***  ******************************** //

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


using BrilliantSkies.FromTheDepths.Game.UserInterfaces ;
using System ;
using UnityEngine ;

//using System;
//namespace DriveWheel_Upg
//{

//namespace DriveWheel_Upg
//{

/*
	public class DriveWheel_UpgGUI
	{

		//public float imaginary = 0;

		//public bool GUI ()
		//{

	public bool OnGui2()
	//public override bool ExtraGUI()
	{


		GUILayout.BeginArea(new Rect(20f, 400f, 500f, 390f), "Wheel Settings GUI: " + this.name, GUI.skin.window);
		
		GUISliders.TotalWidthOfWindow = 500;
		GUISliders.TextWidth = 140;
		GUISliders.UpperMargin = 40;
		GUISliders.DecimalPlaces = 2;
		
		int GUISIndex = 0;

		this.DamperScalar = GUISliders.DisplaySlider (GUISIndex, "Damper [%]: ", this.DamperScalar, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;
		this.SpringScalar = GUISliders.DisplaySlider (GUISIndex, "Spring [%]: ", this.SpringScalar, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;
		
		this.DriveWheelModeEnabled = GUI.Toggle(new Rect(40f + 0f * 0.5f, 250, 150f, 30f), this.DriveWheelModeEnabled , "Drive Wheel");
		this.SteerWheelModeEnabled = GUI.Toggle(new Rect(40f + 300f * 0.5f, 250, 150f, 30f), this.SteerWheelModeEnabled , "Steering Wheel");
		this.TrackModeEnabled = GUI.Toggle(new Rect(40f + 600f * 0.5f, 250, 150f, 30f), this.TrackModeEnabled , "Tank Track");
		// self balancing sliders
		
		// condition not allowed
		if (this.TrackModeEnabled && !this.DriveWheelModeEnabled & this.SteerWheelModeEnabled)
		{
			// auto enable 
			this.DriveWheelModeEnabled = true ;
		}
		
		
		float ParametersSum;
		int TotalSliderCount = 3 ; // 1 is minimum
		int SliderId ; // 0 is minimum
		
		if ( this.DriveWheelModeEnabled )
		{
			
			// sliders total sum is above 100%
			ParametersSum = this.AdjustTractionFraction + this.AdjustMaxSpeedFraction + this.AdjustBrakeFraction;
			SliderId = 0 ;
			this.AdjustBrakeFraction = BalancingSliderHigh ( this.AdjustBrakeFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			ParametersSum = this.AdjustTractionFraction + this.AdjustMaxSpeedFraction + this.AdjustBrakeFraction;
			SliderId++ ;
			this.AdjustMaxSpeedFraction = BalancingSliderHigh ( this.AdjustMaxSpeedFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			ParametersSum = this.AdjustTractionFraction + this.AdjustMaxSpeedFraction + this.AdjustBrakeFraction;
			SliderId++;
			this.AdjustTractionFraction = BalancingSliderHigh ( this.AdjustTractionFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			// sliders total sum is below 100%
			ParametersSum = this.AdjustTractionFraction + this.AdjustMaxSpeedFraction + this.AdjustBrakeFraction;
			SliderId = 0 ;
			this.AdjustTractionFraction = BalancingSliderLow ( this.AdjustTractionFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			ParametersSum = this.AdjustTractionFraction + this.AdjustMaxSpeedFraction + this.AdjustBrakeFraction;
			SliderId++ ;
			this.AdjustMaxSpeedFraction = BalancingSliderLow ( this.AdjustMaxSpeedFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			ParametersSum = this.AdjustTractionFraction + this.AdjustMaxSpeedFraction + this.AdjustBrakeFraction;
			SliderId++ ;
			this.AdjustBrakeFraction = BalancingSliderLow ( this.AdjustBrakeFraction, ParametersSum, TotalSliderCount, SliderId) ;
		}
		else // DriveWheelMode Disabled
		{
			// sliders total sum is above 100%
			ParametersSum = this.AdjustTractionFraction + this.AdjustBrakeFraction;
			SliderId = 0 ;
			this.AdjustBrakeFraction = BalancingSliderHigh ( this.AdjustBrakeFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			ParametersSum = this.AdjustTractionFraction + this.AdjustBrakeFraction;
			SliderId++;
			this.AdjustTractionFraction = BalancingSliderHigh ( this.AdjustTractionFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			// sliders total sum is below 100%
			ParametersSum = this.AdjustTractionFraction + this.AdjustBrakeFraction;
			SliderId = 0 ;
			this.AdjustTractionFraction = BalancingSliderLow ( this.AdjustTractionFraction, ParametersSum, TotalSliderCount, SliderId) ;
			
			ParametersSum = this.AdjustTractionFraction + this.AdjustBrakeFraction;
			SliderId++ ;
			this.AdjustBrakeFraction = BalancingSliderLow ( this.AdjustBrakeFraction, ParametersSum, TotalSliderCount, SliderId) ;
		}
		
		this.AdjustTractionFraction = Mathf.Clamp (this.AdjustTractionFraction, 0.00f, 100.00f) ;
		this.AdjustMaxSpeedFraction = Mathf.Clamp (this.AdjustMaxSpeedFraction, 0.00f, 100.00f) ;
		this.AdjustBrakeFraction = Mathf.Clamp (this.AdjustBrakeFraction, 0.00f, 100.00f) ;
		
		this.AdjustTractionFraction = Mathf.Round (this.AdjustTractionFraction * 100) / 100 ;
		this.AdjustMaxSpeedFraction = Mathf.Round (this.AdjustMaxSpeedFraction * 100) / 100 ;
		this.AdjustBrakeFraction = Mathf.Round (this.AdjustBrakeFraction * 100) / 100 ;
		
		
		
		
		this.AdjustTractionFraction = GUISliders.DisplaySlider (GUISIndex, "Traction [%]: ", this.AdjustTractionFraction, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;
		if ( this.DriveWheelModeEnabled )
		{
			this.AdjustMaxSpeedFraction = GUISliders.DisplaySlider (GUISIndex, "Max Speed [%]: ", this.AdjustMaxSpeedFraction, 0f, 100f, enumMinMax.none, null) ;
			GUISIndex++;
		}
		this.AdjustBrakeFraction = GUISliders.DisplaySlider (GUISIndex, "Brake Force [%]: ", this.AdjustBrakeFraction, 0f, 100f, enumMinMax.none, null) ;
		GUISIndex++;
		
		
		
		
		if ( this.AdjustMaxSpeedFraction <= 0f )
		{
			this.AdjustMaxSpeedFraction = 0.01f ;
		} 
		if ( this.AdjustTractionFraction <= 0f )
		{
			this.AdjustTractionFraction = 0.01f ;
		} 
		//else
		//{
		//Debug.Log ("Null Ref 2");
		//}
		
		float ScrollAreaX = 40f ;
		float ScrollAreaY = 290f ;
		float ScrollAreaWidth = 200f ;
		float ScrollAreaHeight = 90f ;
		
		
		float ButtonWidth = ScrollAreaWidth - 20;
		float ButtonHeight = 30f;
		float ButtonIndex = 0 ;
		
		float ButtonPosX = 0f ;
		float ButtonPosY = ButtonHeight ;
		
		
		//this.OptionsScrollArea[0] = new Vector3 (0.5f, 0.5f );
		//GUILayout.BeginArea(new Rect(ScrollAreaX, ScrollAreaY, ScrollAreaWidth, ScrollAreaHeight), "", GUI.skin.verticalScrollbar);
		//this.OptionsScrollPosition[1] = GUILayout.VerticalScrollbar(this.OptionsScrollPosition[1], 20.0f, 0.0f, 10.0f, new GUILayoutOption[0]) ;
		//this.OptionsScrollArea[0] = new Vector2(this.OptionsScrollArea[0].x, GUILayout.VerticalScrollbar(this.OptionsScrollArea[0].y, 1.0f, 0.0f, 10.0f, new GUILayoutOption[0]) ) ;
		//this.Options1Scroll = GUILayout.BeginScrollView(this.Options1Scroll, new GUILayoutOption[0]);
		this.OptionsScrollArea[0] = GUI.BeginScrollView(new Rect (ScrollAreaX,ScrollAreaY, ScrollAreaWidth, ScrollAreaHeight), this.OptionsScrollArea[0], new Rect (0, 0, ButtonWidth, ButtonHeight * 4) ) ;
		
		//GUILayout.BeginArea(new Rect(0, 0, 800, 1600), "", GUI.skin.scrollView);
		ButtonIndex = 0 ;
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Racer"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 15 ;
			this.SpringScalar = 20 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Smooth"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 15f ;
			this.SpringScalar  = 18 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Humpy Road"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 5f ;
			this.SpringScalar  = 22 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "On Rubbles"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 2.5f ;
			this.SpringScalar  = 18 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Damped"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 15 ;
			this.SpringScalar  = 40 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Hard"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 30 ;
			this.SpringScalar  = 40 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Springy"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 2.5f ;
			this.SpringScalar  = 30 ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Bouncy"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DamperScalar = 1 ;
			this.SpringScalar  = 80 ;
		}
		ButtonIndex++ ;

		GUI.EndScrollView();
		
		ScrollAreaX = 255f ;
		this.OptionsScrollArea[1] = GUI.BeginScrollView(new Rect (ScrollAreaX,ScrollAreaY, ScrollAreaWidth,ScrollAreaHeight), this.OptionsScrollArea[1], new Rect (0, 0, ButtonWidth, ButtonHeight * 6) ) ;
		
		
		//GUILayout.BeginArea(new Rect(0, 0, 800, 1600), "", GUI.skin.box);
		
		ButtonIndex = 0 ;
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Rolling Wheel"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = false ;
			this.SteerWheelModeEnabled = false ;
			this.TrackModeEnabled = false ;
			this.AdjustTractionFraction = 5 ;
			this.AdjustMaxSpeedFraction = 0 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Steering Wheel"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = false ;
			this.SteerWheelModeEnabled = true ;
			this.TrackModeEnabled = false ;
			this.AdjustTractionFraction = 5 ;
			this.AdjustMaxSpeedFraction = 0 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Driving Wheel"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = false ;
			this.TrackModeEnabled = false ;
			this.AdjustTractionFraction = 10 ;
			this.AdjustMaxSpeedFraction = 81 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Driving Steer Wheel"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = true ;
			this.TrackModeEnabled = false ;
			this.AdjustTractionFraction = 5 ;
			this.AdjustMaxSpeedFraction = 81 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Track Mode"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = true ;
			this.TrackModeEnabled = true ;
			this.AdjustTractionFraction = 40 ;
			this.AdjustMaxSpeedFraction = 40 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Power Track"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = false ;
			this.TrackModeEnabled = true ;
			this.AdjustTractionFraction = 40 ;
			this.AdjustMaxSpeedFraction = 40 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		if (GUI.Button(new Rect(ButtonPosX, ButtonPosY * ButtonIndex, ButtonWidth, ButtonHeight), "Climber Track"))
		{
			GUISoundManager.GetSingleton().PlayBeep();
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = false ;
			this.TrackModeEnabled = true ;
			this.AdjustTractionFraction = 75 ;
			this.AdjustMaxSpeedFraction = 10 ;
			this.AdjustBrakeFraction = 100 - this.AdjustTractionFraction - this.AdjustMaxSpeedFraction ;
		}
		ButtonIndex++ ;
		
		GUI.EndScrollView();
		//GUILayout.EndArea();
		//GUILayout.EndScrollView();
		//GUILayout.EndArea();
		
		
		
		if (GUI.Button(new Rect(1030f, 600f, 150f, 30f), "Copy to clipboard!"))
		{
			ShieldProjectorClipboard.SaveAsDefault(this._focus);
		}
		if (ShieldProjectorClipboard.default_saved)
		{
			if (GUI.Button(new Rect(1030f, 650f, 150f, 50f), "Paste from clipboard!"))
			{
				ShieldProjectorClipboard.LoadDefault(this._focus);
			}
		}
		
		
		this.DamperSpringInit () ;
		
		this.DamperSpringScaling () ;
		
		this.StuffChangedSyncIt() ;
		
		
		
		bool result = false ;
		
		this.ApplyInitSuspentionParam () ;
		
		this.StuffChangedSyncIt();
		
		if (GuiCommon.DisplayCloseButton(500))
		{
			result = true ;
			
			this.DamperSpringInit() ;
			
			this.DamperSpringScaling() ;
			
			this.ApplyInitSuspentionParam () ;
			
			this.StuffChangedSyncIt();
			
			this.WheelMode = this.GetWheelMode (this.TrackModeEnabled, this.DriveWheelModeEnabled, this.SteerWheelModeEnabled) ;
			
			this.FacingDirectionFloat = this.GetFacingDirection ( this.FacingDirection ) ;
			
		}
		GUILayout.EndArea() ;
		
		//Debug.Log ("Null Ref 11");

		return result ;
	}
}
*/
//	}

//}

