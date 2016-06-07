// *************************************************************************** //
// ************************** Upgraded Wheel System ************************** //
// *************************************************************************** //

// Mod is developed for From The Depths ************************************** //

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

using BrilliantSkies.FromTheDepths.Planets ; // This gets us InstanceSpecification.
using BrilliantSkies.FromTheDepths.Game.UserInterfaces ;
using System ;
using System.Collections ;
using System.Collections.Generic ;
using UnityEngine ;

// **************** Upgraded Power Wheel Blocks Definition ****************** //

public class x4SmallWheel_Upg : DriveWheel_Upg
{
	
	
	public override void BlockStart()
	{
		this.WheelCollidersCount = 2 ;
		
		this.WheelsMultipler = 1 ;
		this.WCSpread = new Vector3 (0,0,0.0f) ;
		
		this.Radius = 0.9f ;
		this.SuspensionDistance = 1f ; // 1m
		
		//this.RuntimeIdList () ;
		
		base.BlockStart();
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 5f; // default 5
			
		}
	}
}

public class HugeWheel_Upg : DriveWheel_Upg
{
	
	public override void BlockStart()
	{
		this.WheelsMultipler = 3 ;
		
		this.WheelCollidersCount = 2 ;
		this.WCSpread = new Vector3 (0.05f,0,2.5f) ;
		
		this.Radius = 3.6f ;
		this.SuspensionDistance = 4f ; // 1m

		//this.RuntimeIdList () ;

		base.BlockStart();
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 20f; // default 5
			
		}
	}
}

public class LargeWheel_Upg : DriveWheel_Upg
{
	
	public override void BlockStart()
	{
		this.WheelsMultipler = 2 ;
		
		this.WheelCollidersCount = 2 ;
		this.WCSpread = new Vector3 (0.05f, 0, 1.5f) ;
		
		this.Radius = 2.7f ;
		this.SuspensionDistance = 3f ; // 1m

		//this.RuntimeIdList () ;

		base.BlockStart();
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 15f; // default 5
			
		}
	}
}

public class MediumWheel_Upg : DriveWheel_Upg
{
	
	public override void BlockStart()
	{		
		this.WheelsMultipler = 1 ;
		
		this.WheelCollidersCount = 1 ;
		this.WCSpread = new Vector3 (0,0,0.0f) ;
		
		this.Radius = 1.8f ;
		this.SuspensionDistance = 2f ; // 2m

		//this.RuntimeIdList () ;

		base.BlockStart();
		//this.WC.transform.localPosition.x = 20;
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 10f; // default 5
			
		}
	}
	
}

public class StandardWheel_Upg : DriveWheel_Upg
{
	
	public override void BlockStart()
	{		
		this.WheelsMultipler = 1 ;
		
		this.WheelCollidersCount = 1 ;
		this.WCSpread = new Vector3 (0,0,0.0f) ;
		
		this.Radius = 1.35f ;
		this.SuspensionDistance = 1.5f ; // 2m
		
		//this.RuntimeIdList () ;
		
		base.BlockStart();
		//this.WC.transform.localPosition.x = 20;
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 7.5f; // default 5
			
		}
	}
	
}

public class SmallWheel_Upg : DriveWheel_Upg
{
	
	public override void BlockStart()
	{		
		this.WheelsMultipler = 1 ;
		
		this.WheelCollidersCount = 1 ;
		this.WCSpread = new Vector3 (0,0,0.0f) ;
		
		this.Radius = 0.9f ;
		this.SuspensionDistance = 1f ; // 1m
		
		//this.RuntimeIdList () ;

		base.BlockStart();
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 5f; // default 5
			
		}
	}
}

public class DriveWheel_Upg : BlockWithPropulsion, ITurnWheel
{
	
	protected CarriedObjectReference wheel;

	public float motorTorque;
	
	public float brakeTorque;
	
	public float maxMotorTorque = 100f; // was 10
	
	public float minMotorTorque = -100f; // was -10
	
	
	public float steerAngle;

	public float MirroredOrientation = 0 ;
	
	public float maxSteerAngle = 45 ; //50f;
	
	public float minSteerAngle = -45 ; //-50f;
	
	private float rotation;
	
	public float TurningFactor = 2f ;
	
	public int WheelCollidersCount = 1 ;
	public List<WheelCollider> WC = new List<WheelCollider>() ;
	
	public bool WCisGrounded = false ;
	
	public WheelFrictionCurve wheelFrictionCurve ;
	
	public JointSpring suspensionSpring ;
	
	
	private float lastUsed;
	
	public float Radius = 1.8f ; // default 0.9
	
	public float SuspensionDistance = 2f ; // 0.5
	
	private float DamperInit = 4f ; // 2			public float DamperInit = 4f ; // 2
	
	private float SpringInit = 8f ; // 5			public float SpringInit = 8f ; // 5
	
	private float DamperScaled = 4f ; // DamperInit * ( DamperScaled / 10 )		
	
	public float SpringScaled = 8f ; // SpringInit * ( SpringScaled / 10 )		
	
	public float DamperScalar = 10f ; // 0-100 divided by 10; defult 10 as neutral scalar of 1		
	
	public float SpringScalar = 10f ; // 0-100 divided by 10; defult 10 as neutral scalar of 1
	
	public float SpringAntiSway = 0f ;
	
	public float sidewaysFrictionStiffenessDefault = 0.01f ;
	
	public float sidewaysFrictionStiffeness = 0.02f ;
	
	public float forwardFrictionStiffeness = 0.20f ;

	
	
	
	private float PropulsionRequest ;
	
	public float MaxThrustMultipler = 10f ;
	
	public float AdjustMaxSpeedFraction = 10f ;  // 0 to 100
	
	public float AdjustTractionFraction = 10 ;
	
	public float AdjustBrakeFraction = 10 ;
	
	//public float Acceleration = 1 ; // not used yet
	
	private Vector3 PropulsionDragRequest = new Vector3(0,0,0) ;
	
	//private float TailsMultiplier = 1f ; // this is to give a traction to the ground
	
	private float ForcePerSpeed = 0.2f; // simulate x number of tailplanes (Tail Multipler)
	

	
	//public List <int> WheelComponentRuntimeIdList = new List <int>() ; // list of IDs for same type of wheel, for different variances
	public List <Guid> WheelComponentGuidList = new List <Guid>() ; // list of IDs for same type of wheel, for different variances
		
	public float WheelsMultipler = 1f ; // for now only up to two are working correctly
	
	public Vector3 WCSpread = new Vector3 (0.1f,0,0) ;
	
	private List<Vector3> ProposedWheelPos = new List<Vector3>() ;
	private Vector3 WheelPos ;
	
	private List <float> HitDistance = new List<float>() ;
	//private float HitDistance = 0f ;
	//private List<float> WheelPosSmoothing = new List<float> ;
	
	private Vector3 WheelInitPos ;
	
	public List<float> WheelTouchPoint = new List<float>() ;
	//private float WheelTouchPoint ;
	private List<Vector3> WCLocalPositionInit = new List<Vector3>() ;
	
	// required for tyre suspension animation
	private List <RaycastHit> Hit = new List<RaycastHit>() ;
	//private RaycastHit hit = new RaycastHit();
	
	private Vector3 FacingDirection = new Vector3 (0,0,0); // facing
	public float FacingDirectionFloat = 0 ;
	
	private float AntiSwayForceMultipler = 1 ;
	
	
	private bool BrakeEnabled = false;
		
	public float WheelMode = 0 ; // for saving/loading

	public bool TrackModeEnabled = false;
	public bool DriveWheelModeEnabled = false;
	public bool SteerWheelModeEnabled = false;
	
	//private Boolean DragEnabled = true ;
	
	private float RollTorque ;
	private float RollTorqueFactor = 1 ;
	
	
	private int WheelsCount = 64767 ;
	private int MemorisedWheelCount = 0 ;
	
	private float LastLiftTime = 0f ;
	private float LastLiftTimeDeadBand = 100 ; // number of time samples
	
	private float steerAngleStrength = 1f ;
	
	List<Block> ThisWheelsList = new List<Block>() ;
	//ThisWheelsList = MainConstruct.iBlockTypeStorageSpecific.EntireBlockCatalogue.GetBlockListingByRuntimeIdIfWeKnowIt(485) ;
	
	private float FixUpdateDelayBy = 2 ;
	private float FixUpdateDelayCount = 1 ;
	
	private float ChecerTimeCount = 0 ;
	
	private float AngularWheelSpeed = 500 ;
	
	private float WheelRotationAngle = 0 ;
	
	public float MassPerWheel = 1 ; // appropriate mass is assigned, by dividing amount of wheels by total construct mass
	
	private List <Vector2> OptionsScrollArea = new List<Vector2>() ;
	private List <float> OptionsScrollPosition = new List<float>() ;
	
	private bool BlockAtBackOrFront = false ; // false = on the back of construct, true = on the middle, or front of the construct
	
	// to be removed
	//this.PropulsionDragRequest.x
	//this.PropulsionDragRequest.y
	//this.PropulsionDragRequest.z
	
	
	public override void ItemSet()
	{
		base.ItemSet();
		//this.ForcePerSpeed = this.item.Code.Variables.GetFloat("ForcePerSpeedBy100", this.ForcePerSpeed ) / 100 ;
		//this.TailsMultiplier = this.item.Code.Variables.GetFloat("TailsMultiplier", this.TailsMultiplier ) ;
		this.MaxThrustMultipler = this.item.Code.Variables.GetFloat("MaxThrustMultiplerBy100", this.MaxThrustMultipler ) / 100 ;
		//this.SuspensionDistance = this.item.Code.Variables.GetFloat("SuspensionDistanceBy10", this.SuspensionDistance ) / 10 ;
		
		this.sidewaysFrictionStiffeness = this.item.Code.Variables.GetFloat("SidewaysFrictionStiffenessBy100", this.sidewaysFrictionStiffeness ) / 100 ;
		this.forwardFrictionStiffeness = this.item.Code.Variables.GetFloat("ForwardFrictionStiffenessBy100", this.forwardFrictionStiffeness ) / 100 ;
		
		//this.maxSteerAngle = this.item.Code.Variables.GetFloat("MaxSteerAngle", this.maxSteerAngle ) ;
		//this.minSteerAngle = -this.maxSteerAngle;
		
		this.maxMotorTorque = this.item.Code.Variables.GetFloat("MaxMotorTorque", this.maxMotorTorque ) ;
		this.minMotorTorque = -this.maxMotorTorque;
		
		this.AntiSwayForceMultipler = this.item.Code.Variables.GetFloat("AntiSwayForceMultiplerBy10000", this.AntiSwayForceMultipler ) / 10000 ;
		this.TurningFactor = this.item.Code.Variables.GetFloat("TurningFactorBy10", this.TurningFactor ) / 10 ;
		//this.Radius = this.item.Code.Variables.GetFloat("RadiusBy10", this.Radius ) / 10 ;
		//if (this.item.Code.Variables.GetFloat("DragEnabledBool", 0) == 0)
		//{
		//	this.DragEnabled = false ;
		//}
		//else 
		//{
		//	this.DragEnabled = true ;
		//}
		
		this.RollTorqueFactor = this.item.Code.Variables.GetFloat("RollTorqueFactorBy100", this.RollTorqueFactor) / 100 ;
		
		this.steerAngleStrength = this.item.Code.Variables.GetFloat("steerAngleStrengthBy100", this.steerAngleStrength ) / 100 ;
		
		//this.AngularWheelSpeed = this.item.Code.Variables.GetFloat("AngularWheelSpeedBy100", this.AngularWheelSpeed ) / 100 ;
		
	}

	public override void LoadWithoutState ()
	{
		// Called after block start but before SetExtraInfo.
		// Allows us to clear things like energy in batteries if we should not have any.
		//AProperty = 0 ; 
		// This method is mainly called in vehicle designer (fresh copies of vehicles loaded each time) and when a fresh blueprint is spawned.
		// It is not ALWAYS called.
	}

	// prepare for saving blueprint
	public override void GetExtraInfo(ExtraInfoArrayWritePackage v)
	{
		//v.WriteNextFloat(this.AProperty);

		base.GetExtraInfo(v);
		v.AddDelimiterOpen(DelimiterType.Drill);

		// GetParameters1()
		v.WriteNextFloat(this.DamperScalar);
		v.WriteNextFloat(this.SpringScalar);
		v.WriteNextFloat(this.AdjustTractionFraction);
		v.WriteNextFloat(this.AdjustBrakeFraction);

		// GetParameters2()

		this.WheelMode = this.GetWheelMode (this.TrackModeEnabled, this.DriveWheelModeEnabled, this.SteerWheelModeEnabled) ;
		
		this.FacingDirectionFloat = this.GetFacingDirection ( this.FacingDirection ) ;

		v.WriteNextFloat(this.AdjustMaxSpeedFraction);
		v.WriteNextFloat(this.WheelMode);
		v.WriteNextFloat(this.FacingDirectionFloat);
		// spare // v.WriteNextFloat(this.AdjustBrakeFraction);
		// spare
		// spare
		// spa ...

		v.AddDelimiterClose(DelimiterType.Drill);

	}

	//prepare for loading blueprint
	public override void SetExtraInfo(ExtraInfoArrayReadPackage v)
	{
		// this.AProperty = v.GetNextFloat() ;

		base.SetExtraInfo(v);
		v.FindDelimiterAndSpoolToIt(DelimiterType.Drill);
		int num = v.ElementsToDelimiterIfThereIsOneOrEndOfArrayIfNot(DelimiterType.Drill);

		// SetParameters1()
		this.DamperScalar = v.GetNextFloat();
		this.SpringScalar = v.GetNextFloat();
		this.AdjustTractionFraction = v.GetNextFloat();
		this.AdjustBrakeFraction = v.GetNextFloat();

		// SetParameters2()
		this.AdjustMaxSpeedFraction = v.GetNextFloat();
		this.WheelMode = v.GetNextFloat();
		this.SetWheelMode ( this.WheelMode ) ;
		this.FacingDirectionFloat = v.GetNextFloat();

		// spare
		//this.f = v.GetNextFloat();
		//this.g = v.GetNextFloat();
		//this.h = v.GetNextFloat();
		//this.i = v.GetNextFloat();
		//this.j = v.GetNextFloat();

		this.StuffChangedSyncIt();

		this.SetFacingDirection ( this.FacingDirectionFloat ) ;
		
		//Debug.Log ("Loaded Parameter W: " + this.FacingDirection.ToString() ) ;
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			
			// checked if wheel is upside down
			if ( this.FacingDirection.z == -1 ) 
			{
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (180f, Vector3.up) ;
			}
			
			/*
			// checked if wheel is facing backwards
			if ( this.FacingDirection.y == -1 ) 
			{
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (180f, Vector3.right) ;
			}

			if ( this.FacingDirection.x == -1 ) 
			{
				// checked if wheel is facing left
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (-90, Vector3.right) ;
			} 
			else if ( this.FacingDirection.x == 1 ) 
			{
				// checked if wheel is facing right
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (90, Vector3.right) ;
			}
			*/
		}
		
		this.DamperSpringScaling () ;
		
		this.ApplyInitSuspentionParam () ;
		
		this.StuffChangedSyncIt();

	}

	/*
	// prepare for saving blueprint
	public override Vector4 GetParameters1()
	{		
		return new Vector4(this.DamperScalar, this.SpringScalar, this.AdjustTractionFraction, this.AdjustBrakeFraction);
	}

	public override Vector4 GetParameters2()
	{	
		this.WheelMode = this.GetWheelMode (this.TrackModeEnabled, this.DriveWheelModeEnabled, this.SteerWheelModeEnabled) ;

		this.FacingDirectionFloat = this.GetFacingDirection ( this.FacingDirection ) ;

		return new Vector4( this.AdjustMaxSpeedFraction, WheelMode, 0, this.FacingDirectionFloat ) ;
	}
	*/

	public float GetFacingDirection( Vector3 FacingDirection )
	{
		float num = 0 ;

		//Debug.Log ("Saving Parameter W: " + this.FacingDirection.ToString() ) ;
		// checked if wheel is facing froward/backwards
		if ( this.FacingDirection.z == -1 ) 
		{
			num += 1 ;
		}
		else
		{
			num += 0 ;
		}
		
		
		// checked if wheel is upside down
		if ( this.FacingDirection.y == -1 ) 
		{
			num += 2 ;
		}
		else
		{
			num += 0 ;
		}
		
		// checked if wheel is facing left/right
		if ( this.FacingDirection.x == -1 ) 
		{
			num += 4 ;
		}
		else
		{
			num += 0 ;
		}

		return num ;
	}

	public float GetWheelMode (bool TrackModeEnabled, bool DriveWheelModeEnabled, bool SteerWheelModeEnabled)
	{
		WheelMode = (TrackModeEnabled ? 1f : 0f) * 1 + (this.DriveWheelModeEnabled ? 1f : 0f) * 2 + (this.SteerWheelModeEnabled ? 1f : 0f) * 4 ;
		return WheelMode ;
	}

	/*
	//prepare for loading blueprint
	public override void SetParameters1(Vector4 parameters)
	{
		this.DamperScalar = parameters.x ;
		this.SpringScalar = parameters.y ;
		this.AdjustTractionFraction = parameters.z ;
		this.AdjustBrakeFraction = parameters.w ;

		this.StuffChangedSyncIt();
	}
	
	public override void SetParameters2(Vector4 parameters)
	{
		this.AdjustMaxSpeedFraction = parameters.x ;

		this.WheelMode = parameters.y ;

		this.SetWheelMode ( this.WheelMode ) ;


		this.FacingDirectionFloat = parameters.w ;

		this.SetFacingDirection ( this.FacingDirectionFloat ) ;

		//Debug.Log ("Loaded Parameter W: " + this.FacingDirection.ToString() ) ;
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			
			// checked if wheel is upside down
			if ( this.FacingDirection.z == -1 ) 
			{
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (180f, Vector3.up) ;
			}
	*/		
			/*
			// checked if wheel is facing backwards
			if ( this.FacingDirection.y == -1 ) 
			{
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (180f, Vector3.right) ;
			}

			if ( this.FacingDirection.x == -1 ) 
			{
				// checked if wheel is facing left
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (-90, Vector3.right) ;
			} 
			else if ( this.FacingDirection.x == 1 ) 
			{
				// checked if wheel is facing right
				this.WC[WCi].transform.localRotation = Quaternion.AngleAxis (90, Vector3.right) ;
			}
			*/
	/*
		}
		
		this.DamperSpringScaling () ;
		
		this.ApplyInitSuspentionParam () ;
		
		this.StuffChangedSyncIt();
	}
	*/

	public void SetWheelMode ( float WheelMode )
	{

		switch ((int)WheelMode)
		{
		case 0:
			// simply rolling wheel
			
			this.TrackModeEnabled = false ;
			this.DriveWheelModeEnabled = false ;
			this.SteerWheelModeEnabled = false ;
			
			break;
		case 1:
			
			this.TrackModeEnabled = true ;
			this.DriveWheelModeEnabled = false ;
			this.SteerWheelModeEnabled = false ;
			
			break;
		case 2:
			
			this.TrackModeEnabled = false ;
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = false ;
			
			break;
		case 3:
			
			this.TrackModeEnabled = true ;
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = false ;
			
			break;
		case 4:
			
			this.TrackModeEnabled = false ;
			this.DriveWheelModeEnabled = false ;
			this.SteerWheelModeEnabled = true ;
			
			break;
			//case 5:
			
			// condition not allowed
			//this.TrackModeEnabled = true ;
			//this.DriveWheelModeEnabled = false ;
			//this.SteerWheelModeEnabled = true ;
			
			//break;
		case 6:
			
			this.TrackModeEnabled = false ;
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = true ;
			
			break;
		case 7:
			
			this.TrackModeEnabled = true ;
			this.DriveWheelModeEnabled = true ;
			this.SteerWheelModeEnabled = true ;
			
			break;
		default :
			
			this.TrackModeEnabled = false ;
			this.DriveWheelModeEnabled = false ;
			this.SteerWheelModeEnabled = false ;
			
			break ;
			
			
		}
	}

	public void SetFacingDirection( float FacingDirectionFloat )
	{
		switch ( (int)FacingDirectionFloat )
		{
		case 0:
			
			// checked if wheel is facing forward
			this.FacingDirection.x = 0 ;
			this.FacingDirection.y = 1 ;
			this.FacingDirection.z = 1 ;
			this.MirroredOrientation = 0 ;
			
			break;
		case 1:
			
			// checked if wheel is facing backwards
			this.FacingDirection.x = 0 ;
			this.FacingDirection.y = 1 ;
			this.FacingDirection.z = -1 ;
			this.MirroredOrientation = 180 ;
			
			break;
		case 2:			
			
			this.FacingDirection.x = 0 ;
			this.FacingDirection.y = -1 ;
			this.FacingDirection.z = 1 ;
			
			break;
		case 3:
			
			this.FacingDirection.x = 0 ;
			this.FacingDirection.y = -1 ;
			this.FacingDirection.z = -1 ;
			
			break;
		case 4:
			
			this.FacingDirection.x = -1 ;
			this.FacingDirection.y = 1 ;
			this.FacingDirection.z = 1 ;
			
			break;
		case 5:
			
			this.FacingDirection.x = -1 ;
			this.FacingDirection.y = 1 ;
			this.FacingDirection.z = -1 ;
			
			break;
		case 6:
			
			this.FacingDirection.x = -1 ;
			this.FacingDirection.y = -1 ;
			this.FacingDirection.z = 1 ;
			
			break;
		case 7:
			
			this.FacingDirection.x = -1 ;
			this.FacingDirection.y = -1 ;
			this.FacingDirection.z = -1 ;
			
			break;	
		default :
			
			// checked if wheel is facing forward
			this.FacingDirection.x = 0 ;
			this.FacingDirection.y = 1 ;
			this.FacingDirection.z = 1 ;
			
			break ;
			
			
		}
	}
	
	public override float PowerUsePerFixedUpdate
	{
		get
		{
			// return base.PowerUsePerFixedUpdate * 15f; // huge propeller example
			return 5f * 10f; // default 5
			
		}
	}
	
	public override float SpaceRequiredBehindPropulsion
	{
		get
		{
			return 0f;
		}
	}
	
	public override PropulsionBlockType Type
	{
		get
		{
			return PropulsionBlockType.Land;
		}
	}
	
	
	public override float MaxThrust
	{
		get
		{
			// return base.MaxThrust * 20f; // huge propeller example
			return 150f; // was 150f // default value
		}
	}
	
	public override string Name
	{
		get
		{
			return "Wheel";
		}
	}
	
	protected override bool CanRunInReverse
	{
		get
		{
			return true;
		}
	}
	
	protected override PowerRequestType PowerRequestType
	{
		get
		{
			return PowerRequestType.Propulsion;
		}
	}
	
	public override bool ShallIApplyCollisionDamage()
	{
		return false;
	}
	
	
	
	public float stoppedUntil;
	
	
	public override void BlockStart()
	{
		this.wheel = base.CarryThisWithUs(0);
		
		//CarriedObjectReference carriedObjectReference1 = base.CarryEmptyWithUs();
		//carriedObjectReference1.SetName("Drive Wheel Collider");
		List<CarriedObjectReference> carriedObjectReference = new List <CarriedObjectReference> () ;
		
		//Debug.Log ("WheelCollidersCount: " + this.WheelCollidersCount.ToString() );
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			
			carriedObjectReference.Add ( base.CarryEmptyWithUs() ) ;
			carriedObjectReference[WCi].SetName("Drive Wheel Collider " + WCi);
			
			//Debug.Log ("WCi: " + WCi ) ;
			
			this.WC.Add( carriedObjectReference[WCi].ObjectItself.AddComponent<WheelCollider>() );

			// get block's orientation, if not set
			if ( WCi == 0 ) 
			{
				// if block just have been placed
				if ( this.FacingDirection == new Vector3 (0,0,0) )
				{
					int temp = (int)Mathf.Round( this.WC[0].transform.localRotation.eulerAngles.y ) ;
					
					// facing
					switch ( temp )
					{
					case 0:
						this.FacingDirection.z = 1; // front
						//this.MirroredOrientation = 0 ;
						break ;
					case 180:
						this.FacingDirection.z = -1; // back
						//this.MirroredOrientation = 180 ;
						break ;
					case 270:
						this.FacingDirection.x = -1; // left
						break ;
					case 90:
						this.FacingDirection.x = 1; // right
						break ;
						
					}
					
					
					if ( this.FacingDirection.y == 0 ) 
					{
						temp = (int)Mathf.Round( Mathf.Round( this.WC[0].transform.localRotation.eulerAngles.z ) ) ;
						// facing
						switch ( temp )
						{
						case 0:
							this.FacingDirection.y = 1; // down
							break ;
						case 180:
							this.FacingDirection.y = -1; // up
							
							break ;
						}
					} 
				}

			}

			if ( this.WheelCollidersCount > 1 ) 
			{
				// comlex wheels, with more than one collider

				// get initial position of the wheel collider, before repositioning
				this.WCLocalPositionInit.Add (this.WC[WCi].transform.localPosition) ;

				float ColliderOffsetX = 0.5f ;

				// set wheel colliders new position, inrespect to the local position
				// assuming, wheel is not turned
				// also, when there is more than one collider per wheel, spread these colliders appart
				switch (WCi)
				{
				case 0 :

					// this.WC[WCi].transform.localPosition += (this.WCSpread + new Vector3 (0.7f, 0f, 0f) ) ;

					if ( this.FacingDirection.z != -1 )
					{
						// block facing front 
						this.WC[WCi].transform.localPosition += ( this.WCSpread + new Vector3 (ColliderOffsetX, 0f, 0f) ) ;
					
					}
					else 
					{
						// block facing back 
						this.WC[WCi].transform.localPosition -= ( this.WCSpread + new Vector3 (-ColliderOffsetX, 0f, 0f) ) ;
					}

					break ;
				case 1 :

					//this.WC[WCi].transform.localPosition -= (this.WCSpread + new Vector3 (-0.7f, 0f, 0f) ) ;

					if ( this.FacingDirection.z != -1 )
					{
						// block facing front 
						this.WC[WCi].transform.localPosition -= ( this.WCSpread + new Vector3 (-ColliderOffsetX, 0f, 0f) ) ;
					}
					else
					{
						// block facing back 
						this.WC[WCi].transform.localPosition = ( this.WCSpread + new Vector3 (ColliderOffsetX, 0f, 0f) ) ;
					}

					break ;
				case 2 :
					//this.WC[WCi].transform.localPosition -= this.WCSpread ;
					break ;
				}
			} 
			else if ( this.WheelCollidersCount < 1 )
			{
				// for small wheels, or with one collider
				this.WheelCollidersCount = 1 ;
			}
			
			//Debug.Log ("WCi: " + WCi + ": " + this.WC[WCi].transform.localPosition.ToString() );
			
			
			this.HitDistance.Add (0f) ;
			this.Hit.Add( new RaycastHit() ) ;
			
		}

		RuntimeIdList () ;

		this.wheel.SetName("Drive Wheel");
		
		this.ThisWheelsList = this.MainConstruct.iBlockTypeStorageSpecific.EntireBlockCatalogue.GetBlockListingByRuntimeIdIfWeKnowIt(this.item.ComponentId.RuntimeId) ;
		//this.ThisWheelsList.Add(this);
		
		//this.WC.sidewaysFriction.extremumSlip = 1;
		//this.WC.sidewaysFriction.extremumValue = 20000;
		//this.WC.sidewaysFriction.asymptoteSlip = 1;
		//this.WC.sidewaysFriction.asymptoteValue = 10000;
		//this.WC.sidewaysFriction.stiffness = 1;
		
		//this.WC.forwardFriction.extremumSlip = 1;
		//this.WC.forwardFriction.extremumValue = 19999;
		///this.WC.forwardFriction.asymptoteSlip = 1;
		//this.WC.forwardFriction.asymptoteValue = 10001;
		//this.WC.forwardFriction.stiffness = 0f;
		
		this.ApplyInitSuspentionParam () ;
		
		// tailplane
		if (!base.IsOnSubConstructable)
		{
			base.LocalRotation = Quaternion.identity;
		}
		
		this.WheelPos = this.wheel.ObjectItself.transform.localPosition ;
		this.WheelInitPos = this.WheelPos ;
		
		// to smooth wheel movement up/down
		//for (int i = 0; i < 10; i++)
		//{
		//	this.WheelPosSmoothing.Add(WheelPos);
		//}
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			this.WheelTouchPoint.Add ( this.WC[WCi].suspensionDistance + this.WC[WCi].radius ) ;
			//this.WheelTouchPoint[WCi] = this.WC[WCi].suspensionDistance + this.WC[WCi].radius;
			
			this.ProposedWheelPos.Add (this.WheelPos);
		}
		
		//Debug.Log ("BlockStarting: " + this.FacingDirection.ToString() ) ;
		
		//Debug.Log ("Wheel Local Scale: " + this.wheel...ObjectItself.transform.localScale.ToString() );
		//Debug.Log ("Wheel gameObject Local Scale: " + this.wheel.ObjectItself.gameObject.transform.localScale.ToString() );

		
		this.OptionsScrollArea.Add(new Vector2(0,0)) ; // scroll area 1
		this.OptionsScrollArea.Add(new Vector2(0,0)) ; // scroll area 2
		this.OptionsScrollPosition.Add(0f);
		this.OptionsScrollPosition.Add(0f);
		
		base.BlockStart();
		base.Hot = new BlockModule_Hot(this);
		
		this.Propulsion.OrientationWithRespectToConstruct = StaticMaths.DetermineBlockOrientation(this.LocalForward);
		
		
		
	}
	
	
	public void RuntimeIdList()
	{

		//bool found = Configured.i.Items.Find("My Block Name", out found).ModDirectoryWithSlash ;
		//		Configured.i.Items.Components.Count;
		
		//string ThisItemName = this.item.ComponentId.Name.ToLower ; 
		string ThisItemClassName = this.item.Code.ClassName ; 
		Debug.Log ("ThisItemClassName: " + ThisItemClassName ) ;
		Debug.Log ("ThisItemRuntimeId: " + this.item.ComponentId.RuntimeId ) ;
		Debug.Log ("ThisItemGuid: " + this.item.ComponentId.Guid ) ;
		// set list of items, with same name, for same wheel type (mirrored / or not)
		// add first item = index 0
		//this.WheelComponentRuntimeIdList.Add ( this.item.ComponentId.RuntimeId ) ;
		this.WheelComponentGuidList.Add ( this.item.ComponentId.Guid ) ;
		
		//String IteratedItemName = "" ; // ToLower
		String IteratedItemClassName = "" ;
		
		foreach (ItemDefinition IteratedItem in Configured.i.Items.Components)
		{
			// get current item Runtime ID
			//int IteratedItemRuntimeId = IteratedItem.ComponentId.RuntimeId ;
			Guid IteratedItemGuid = IteratedItem.ComponentId.Guid ;
			
			// get current item name of iterated components
			//IteratedItemName = IteratedItem.ComponentId.Name.ToLower ;
			IteratedItemClassName = IteratedItem.Code.ClassName ;
			
			
			// check if found iterated item, has same name as the main item
			//if ( IteratedItemName == ThisItemName )
			if ( IteratedItemClassName == ThisItemClassName )
			{
				Debug.Log ("IteratedItemClassName: " + ThisItemClassName ) ;
				//Debug.Log ("IteratedItemRuntimeId: " + IteratedItemRuntimeId ) ;
				Debug.Log ("IteratedItemGuid: " + IteratedItemGuid ) ;
				
				bool ExistingRuntimeIdFound = false ;
				
				// iterate throgh list of wheels, of current name
				//foreach (int ItemRuntimeId in this.WheelComponentRuntimeIdList )
				foreach (Guid ItemGuid in this.WheelComponentGuidList )
				{
					// check if this item's Runtime ID is different than already in the list
					//if ( ItemRuntimeId == IteratedItemRuntimeId )
					if ( ItemGuid == IteratedItemGuid )
					{
						ExistingRuntimeIdFound = true ;
						break ;
					}
					
				}
				
				// this Runtime ID doesn't exist yet int he List
				// Add found runtime Runtime ID
				if ( !ExistingRuntimeIdFound )
				{
					//this.WheelComponentRuntimeIdList.Add( IteratedItem.ComponentId.RuntimeId );
					this.WheelComponentGuidList.Add( IteratedItem.ComponentId.Guid );
				}
				
			} // if
			
		} // foreach 

	}
	
	public override void EmissionUpdate(float dt)
	{

	}
	
	public void DamperSpringInit ()		
	{		
		this.ThisWheelsList = this.MainConstruct.iBlockTypeStorageSpecific.EntireBlockCatalogue.GetBlockListingByRuntimeIdIfWeKnowIt(this.item.ComponentId.RuntimeId) ;		
		
		this.WheelsCount = this.ThisWheelsList.Count ;	
		
		//Debug.Log ("Wheels Count : " + ThisWheelsList.Count.ToString() ) ;
		
		float ConstructMass = this.MainConstruct.iMainPhysics.iTotalMass.TotalMass ;		
		this.MassPerWheel = ConstructMass / this.WheelsCount ;		
		
		this.SpringInit = this.MassPerWheel * 2 ;		
		this.DamperInit = this.SpringInit / 5 ;	
		
		// this is as per standard HUI for the propulsion, power scallar
		this.Propulsion.PowerScale = this.AdjustMaxSpeedFraction / 100 * this.WheelsMultipler ;
	}		
	
	public void DamperSpringScaling ()		
	{		
		this.DamperScaled = this.DamperInit * this.DamperScalar / 10 ; 		
		this.SpringScaled = this.SpringInit * this.SpringScalar / 10 ; 		
	}
	
	
	public void ApplyInitSuspentionParam () 
	{
		this.forwardFrictionStiffeness = Mathf.Clamp ( this.sidewaysFrictionStiffenessDefault * (this.AdjustTractionFraction / 100 * 50) , 0.01f, 0.5f ) ; // 0.01 to 0.5
		
		WheelCollider ThisWC ;
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			ThisWC = this.WC[WCi] ;
			
			this.wheelFrictionCurve = ThisWC.forwardFriction;
			this.wheelFrictionCurve.stiffness = this.forwardFrictionStiffeness ;
			ThisWC.forwardFriction = this.wheelFrictionCurve;
			
			ThisWC.radius = this.Radius ;
			ThisWC.suspensionDistance = this.SuspensionDistance;
			
			this.WC[WCi] = ThisWC ;
		}
		
		ApplySuspentionParam () ;
		
	}
	
	public void ApplySuspentionParam () 
	{
		this.sidewaysFrictionStiffeness = Mathf.Clamp ( this.sidewaysFrictionStiffenessDefault * (this.AdjustTractionFraction / 100 * 50) , 0.01f, 0.5f ) ; // 0.01 to 0.5
		
		this.wheelFrictionCurve.stiffness = this.sidewaysFrictionStiffeness ;
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			
			WheelCollider ThisWC = this.WC[WCi] ;
			
			ThisWC.sidewaysFriction = this.wheelFrictionCurve;
			
			JointSpring suspensionSpring = ThisWC.suspensionSpring;
			suspensionSpring.damper = this.DamperScaled ;
			
			suspensionSpring.spring = this.SpringScaled ;
			ThisWC.suspensionSpring = suspensionSpring;
			
			this.WC[WCi] = ThisWC ;
		}
		
		//this.ForcePerSpeed = 0.2f * this.TailsMultiplier * this.AdjustTractionFraction ;
		// force to pull wheel down to the ground
		this.ForcePerSpeed = 0.5f * this.Radius;
		
		
		
	}
	
	public override void RunPropulsion()
	{	
		int AnimationSpeedTime = 40 ; // x times per seconds
		
		// delay evry one scan
		// to limit amount of calculations
		if ( this.FixUpdateDelayCount < this.FixUpdateDelayBy) 
		{
			this.FixUpdateDelayCount++ ;
		} 
		else 
		{
			this.FixUpdateDelayCount = 1 ;
		}
		
		
		//Debug.Log ("RunPropulsion : Requested") ;
		
		if ( this.isAlive && this.IsNotDeleted && this.FixUpdateDelayCount == 1 )
		{
			
			Vector3 LocalDragForce = new Vector3 (0,0,0);
			
			float EstimatedTopSpeed = this.MainConstruct.iSpecialInfo.TopSpeed;
			
			float ForwardVelocityRatio = 0 ; //= this.MainConstruct.iMainPhysics.iVelocities.ForwardVelocity / EstimatedTopSpeed ;
			
			float CalculatedMaxPower = this.Propulsion.GetForceToApplyAssumingFullPower() * this.MaxThrustMultipler * this.AdjustMaxSpeedFraction;
			float MaxPowerAtFrwBwrd = CalculatedMaxPower * this.Power.FractionOfPowerRequestedThatWasProvided ;
			this.PropulsionRequest = this.Propulsion.Request.LastDrive * MaxPowerAtFrwBwrd * this.WheelsMultipler ;
			
			// wheel touching the ground
			if (this.WCisGrounded)		
			{
				
				this.GripToGround () ; // make sure construct is pulled to the ground. Preventing from flying into air.
				
				if (!this.BrakeEnabled) 
				{
					// applt forwar propulsion
					if ( this.PropulsionRequest != 0f && this.DriveWheelModeEnabled )
					{
						
						this.lastUsed = Time.time;
						
						if ( this.Propulsion.Request.LastDrive >= 0 )
						{
							//is moving forward
							this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldForwards * this.PropulsionRequest, base.GameWorldPosition, enumForceType.Propulsion);
						}
						else
						{
							// make sure is moving backwards
							this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldForwards * (-Math.Abs (this.PropulsionRequest)), base.GameWorldPosition, enumForceType.Propulsion);
						}
						
						
						// turning (steering wheel)
						if ( this.SteerWheelModeEnabled )
						{
							// increase propulsion request when turning in track mode
							float PropulsionRequest4Turn = this.steerAngle / this.maxSteerAngle * this.WheelsMultipler ;
							
							float ForceRequest4Turn = 0;
							
							if ( this.TrackModeEnabled ) 
							{
								// track mode enabled
								ForceRequest4Turn = PropulsionRequest4Turn * MaxPowerAtFrwBwrd * this.TurningFactor ;
							} 
							else
							{
								// turning in wheel (none track) mode
								ForceRequest4Turn = PropulsionRequest4Turn * this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z * this.TurningFactor * 100 ;
							}
							
							
							if ( MaxPowerAtFrwBwrd != 0 && this.TrackModeEnabled || !this.TrackModeEnabled && this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z != 0 )
							{
								// moving forward/backwards
								// turning left/right
								
								if ( this.BlockAtBackOrFront )
								{
									// on the front, or middle
									//turn left push force
									this.MainConstruct.iMainPhysics.RequestForce(GameWorldRight * (ForceRequest4Turn), base.GameWorldPosition, enumForceType.Propulsion);
									
								} 
								else
								{
									// on the back
									//turn right push force
									this.MainConstruct.iMainPhysics.RequestForce(GameWorldRight * (-ForceRequest4Turn), base.GameWorldPosition, enumForceType.Propulsion);
								}
								
								
							}
							
							
						} // SteerWheelModeEnabled
						
						// Power usage
						//this.MainConstruct.iPowerUsageCreationAndFuel.po
						//this.Hot.AddUsage(Mathf.Abs(this.Power.FractionOfPowerUsePerFixedStepThatWasProvided));
						
					} // propulsion requested && // drive wheel enabled
					
				} // brake not enabled
				
				
				
				
				// aply factor of brakes, in respect of full available power
				
				float BrakeFraction = 1f * this.AdjustBrakeFraction / 10 ; // 0 to 100, is scalled 0 to 10
				
				//float DragForceLimit = CalculatedMaxPower * BrakeFraction ;
				float DragForceLimit = this.AdjustTractionFraction / 10 ; // 0 to 100, is scalled 0 to 10
				
				LocalDragForce = this.MainConstruct.iMainPhysics.LocalDragForce ;
				
				// side way grip friction
				// prevents from sliding sideway
				LocalDragForce.x = Mathf.Clamp(LocalDragForce.x * DragForceLimit / 7, -DragForceLimit, DragForceLimit ) ;
				//LocalDragForce.x *= this.WheelsMultipler ;
				
				if ( MaxPowerAtFrwBwrd > 0 && this.TrackModeEnabled || !this.TrackModeEnabled && this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z > 0 )
				{
					
					if ( this.BlockAtBackOrFront )
					{
						// on the front, or middle
						//turn left/right push force
						
						if ( this.steerAngle > 0 && LocalDragForce.x < 0)
						{
							// don't disturb turning right
							LocalDragForce.x = 0 ;
						}
						else if ( this.steerAngle < 0 && LocalDragForce.x > 0)
						{
							// don't disturb turning left
							LocalDragForce.x = 0 ;
						}
						
						
					} 
					else
					{
						// on the back
						//turn left/right push force
						
						if ( this.steerAngle > 0 && LocalDragForce.x > 0)
						{
							// don't disturb turning right
							LocalDragForce.x = 0 ;
						}
						else if ( this.steerAngle < 0 && LocalDragForce.x < 0)
						{
							// don't disturb turning left
							LocalDragForce.x = 0 ;
						}
						
					}
					
				}
				else if ( MaxPowerAtFrwBwrd < 0 && this.TrackModeEnabled || !this.TrackModeEnabled && this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z < 0 )
				{
					
					if ( this.BlockAtBackOrFront )
					{
						// on the front, or middle
						//turn left/right push force
						
						if ( this.steerAngle > 0 && LocalDragForce.x > 0)
						{
							// don't disturb turning right
							LocalDragForce.x = 0 ;
						}
						else if ( this.steerAngle < 0 && LocalDragForce.x < 0)
						{
							// don't disturb turning left
							LocalDragForce.x = 0 ;
						}
						
						
					} 
					else
					{
						// on the back
						//turn left/right push force
						
						if ( this.steerAngle > 0 && LocalDragForce.x < 0)
						{
							// don't disturb turning right
							LocalDragForce.x = 0 ;
						}
						else if ( this.steerAngle < 0 && LocalDragForce.x > 0)
						{
							// don't disturb turning left
							LocalDragForce.x = 0 ;
						}
						
					}
				}
				
				// vertical grip friction
				LocalDragForce.y = Mathf.Clamp(LocalDragForce.y * DragForceLimit / 7, -DragForceLimit, DragForceLimit );
				//LocalDragForce.y *= this.WheelsMultipler ;
				
				float PowerOverUnderShoot = 0;
				float ToleranceBeforeApplyingBrakes = 0.2f ;
				
				ForwardVelocityRatio = this.MainConstruct.iMainPhysics.iVelocities.ForwardVelocity / EstimatedTopSpeed ;
				
				if ( this.Propulsion.Request.LastDrive > 0) 
				{
					
					if (this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z < 0)
					{
						// if moving backwards, while requesting moving forward
						// apply brakes
						//PowerOverUnderShoot = - 1;
					}
					else {
						
						// if estimated maximus speed, to current speed ratio is higher, than LastDrive Ration
						// then apply braking (must be negative to brakes)
						PowerOverUnderShoot = - ( ForwardVelocityRatio * ToleranceBeforeApplyingBrakes - this.Propulsion.Request.LastDrive ) ;
					}
				} 
				else if (this.Propulsion.Request.LastDrive < 0)
				{
					if (this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z > 0)
					{
						// if moving forward, while requesting moving backward
						// apply brakes
						//PowerOverUnderShoot = - 1;
					}
					else {
						
						// if estimated maximus speed, to current speed ratio is lower, than LastDrive Ration
						// then apply braking drag
						PowerOverUnderShoot = - ( -ForwardVelocityRatio * ToleranceBeforeApplyingBrakes +	 this.Propulsion.Request.LastDrive ) ;
					}
				} 
				else 
				{
					// no over/undershoot
					PowerOverUnderShoot = 0 ;
				}
				
				//this.PowerOverUnderShootTest = PowerOverUnderShoot;
				
				// current propulsion request, in respect to the actual velocity
				float ConstructRoll = this.GameWorldRotation.eulerAngles.z ;
				bool AntiRollBrake = false ;
				
				if (ConstructRoll > 45 & ConstructRoll < 315 )
				{
					AntiRollBrake = true ;
				}
				
				
				// enable brakes, if conditions are met
				if ( (PowerOverUnderShoot < 0 || this.Propulsion.Request.LastDrive == 0f) && this.steerAngle == 0 || AntiRollBrake)
				{
					// maximum possible slowing down
					// braking when undershoot
					LocalDragForce.z = 1 ;
					this.BrakeEnabled = true;
				}
				else 
				{
					LocalDragForce.z = 0 ;
					this.BrakeEnabled = false;
				}
				
				LocalDragForce.z = Mathf.Clamp(LocalDragForce.z * DragForceLimit, -DragForceLimit, DragForceLimit ) * 2 * this.Radius * BrakeFraction;
				//LocalDragForce.z *= this.WheelsMultipler ;
				
				// applay drag or force, in relevant local axis
				// this is to stop
				Vector3 AppliedLocalDragForce = new Vector3 (
					LocalDragForce.x, 
					LocalDragForce.y, 
					//LocalDragForce.z * CalculatedMaxPower * BrakeFraction
					LocalDragForce.z
					) ;
				
				//  0 < backwards, 0 = stop, 0 > forwards
				float VelocityDirection = this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z ;
				
				this.PropulsionDragRequest.z = TractionAtAxis(AppliedLocalDragForce.z, VelocityDirection, base.GameWorldForwards) ;
				
				//  0 < left, 0 = stop, 0 > right
				VelocityDirection = this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.x ;
				
				// apply dragg (sideways)
				this.PropulsionDragRequest.x = TractionAtAxis(AppliedLocalDragForce.x, VelocityDirection, base.GameWorldRight) ;
				
				//  0 < down, 0 = stop, 0 > up
				VelocityDirection = this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.y ;
				
				// apply dragg (verticaly)
				this.PropulsionDragRequest.y = TractionAtAxis(AppliedLocalDragForce.y, VelocityDirection, base.GameWorldUp) ;
				
			} // is touching the ground
			else 
			{
				// wheel is floating
				
				if (  this.LastLiftTimeDeadBand > this.LastLiftTime )
				{
					this.LastLiftTime++ ;
					this.GripToGround () ;
				}
				
				//this.PropulsionDragRequest *= 0 ; // clear the vector
			}
			
			float AngularRoation = 0f ; // this to be removed later from main scope. Is here just for testing
			
			// Animation for wheel angular rotation
			// when is not braking, so wheels are not stopped
			if ( !this.BrakeEnabled )
			{
				
				float WheelDiameter = this.Radius * 2 * Mathf.PI ;
				float RotationsPerMeter = 1 / WheelDiameter ; 
				float RotationsPer40ofSec = RotationsPerMeter / AnimationSpeedTime ; // every x sec? fix scan?
				
				if ( this.DriveWheelModeEnabled && this.Propulsion.Request.LastDrive > 0.1 && this.Propulsion.Request.LastDrive * 0.9 > ForwardVelocityRatio ) 
				{
					// simulate wheel spin/skidd
					AngularRoation = EstimatedTopSpeed * RotationsPer40ofSec; // * this.FacingDirection.y ; 
				} 
				else if ( this.DriveWheelModeEnabled && this.Propulsion.Request.LastDrive < -0.1 && this.Propulsion.Request.LastDrive * 0.9 < ForwardVelocityRatio)
				{
					AngularRoation = -EstimatedTopSpeed * RotationsPer40ofSec ; // * this.FacingDirection.y ; 
				}
				else 
				{
					// adjust to the current velocity
					AngularRoation = this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z * RotationsPer40ofSec ; // this.FacingDirection.y ; 
				} 
				
				
				// turning in track mode
				if (this.TrackModeEnabled && this.SteerWheelModeEnabled)
				{
					
					if ( MaxPowerAtFrwBwrd > 0 )
					{
						if ( this.MainConstruct.iPhysics.iMass.LCOM.x > 0 ) 
						{
							// right tracks
							
							AngularRoation += -AngularRoation * (this.steerAngle / this.maxSteerAngle) ;
							
						} 
						else if ( this.MainConstruct.iPhysics.iMass.LCOM.x < 0 )
						{
							// left tracks
							
							AngularRoation += AngularRoation *  this.steerAngle / this.maxSteerAngle ;
						}
					}
					else if ( MaxPowerAtFrwBwrd < 0 )
					{
						if ( this.MainConstruct.iPhysics.iMass.LCOM.x > 0 ) 
						{
							// right tracks
							
							AngularRoation += AngularRoation * (this.steerAngle / this.maxSteerAngle) ;
							
						} 
						else if ( this.MainConstruct.iPhysics.iMass.LCOM.x < 0 )
						{
							// left tracks
							
							AngularRoation += AngularRoation *  this.steerAngle / this.maxSteerAngle ;
						}
					}
				}
				//Vector3 rollingStones = this.MainConstruct.iMainPhysics.Forces.CalculatedForce.Torque
				
			}
			else 
			{
				AngularRoation = 0;
			}
			
			
			//float AngularRoation = this.MainConstruct.iMainPhysics.iVelocities.VelocityMagnitude * 2f * this.FacingDirection.y ; 
			//this.wheel.SetLocalRotation(Quaternion.Euler(AngularRoation, 0, 0f));						
			this.AnimateRotation(AngularRoation * this.AngularWheelSpeed * FacingDirection.z);
			//Debug.Log ("AnimateRotation: " + this.FacingDirection.ToString() ) ;
		} // block is alive
		
	}
	
	public void AnimateRotation(float d)
	{
		//if ( this.isAlive && this.IsNotDeleted )
		//{
		
		//if (this.WC.isGrounded)
		//{
		
		if (this.SteerWheelModeEnabled && !this.TrackModeEnabled)
		{
			// animeate turning (steering) left/right wheel
			this.WheelRotationAngle += Time.timeScale * d ;
			
			if ( this.BlockAtBackOrFront )
			{
				// is at the front, or middle
				this.wheel.SetLocalRotation(Quaternion.Euler(this.WheelRotationAngle, this.steerAngle + this.MirroredOrientation, 0f));
				
				this.WCTSteeringLocalPosition (1) ;
				
				
			}
			else
			{
				// is at the back
				this.wheel.SetLocalRotation(Quaternion.Euler(this.WheelRotationAngle, -this.steerAngle + this.MirroredOrientation, 0f));
				
				this.WCTSteeringLocalPosition (-1) ;				
			}
			
			
			//colliders angular position
			
		}
		else
		{
			// animate rolling and turning wheel (no steering)
			this.WheelRotationAngle += Time.timeScale * d ;
			this.wheel.SetLocalRotation(Quaternion.Euler(this.WheelRotationAngle, this.MirroredOrientation, 0f));
		}		

		//}
		//this.wheel.RotateAroundLocalAxis(Vector3.right, Time.timeScale * d);
		//this.wheel.SetLocalRotation(Quaternion.Euler(0f, this.steerAngle, 0f));
	}
	
	
	public void WCTSteeringLocalPosition (int BackFront)
	{
		
		if ( this.WheelCollidersCount > 1 && false) 
		{
			
			Vector3 LocalAngularWheelPosition ;
			
			if ( Mathf.Abs ( this.steerAngle ) > 0.01f )
			{
				float deg2rad = (float)(this.steerAngle / 180f * Math.PI) ;
				
				LocalAngularWheelPosition = new Vector3 (Mathf.Sin(deg2rad) * this.WCSpread.z * BackFront, 0, Mathf.Cos(deg2rad) * this.WCSpread.z) ;
			}
			else 
			{
				LocalAngularWheelPosition = new Vector3 (this.WCSpread.z * BackFront, 0, this.WCSpread.z) ;
			}
			
			WheelCollider ThisWC ;
			
			for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
			{
				ThisWC = this.WC[WCi] ;
				
				//Debug.Log ("WC " + WCi.ToString() + "; Back/Front: " + BackFront.ToString() + "; Grounded: " + ThisWC.isGrounded.ToString() + "; Prime Local pos: " + ThisWC.transform.localPosition.ToString() ) ;
				
				if ( WCi == 0 ) // forward direction of the wheel
				{
					ThisWC.transform.localPosition = this.WCLocalPositionInit[WCi] + LocalAngularWheelPosition ;
				}
				else if ( WCi == 1 ) // backward direction of the wheel
				{
					ThisWC.transform.localPosition = this.WCLocalPositionInit[WCi] - LocalAngularWheelPosition ;
				}
				
				//Debug.Log ("WC " + WCi.ToString() + "; Back/Front: " + BackFront.ToString() + "; Grounded: " + ThisWC.isGrounded.ToString() + "; Post Local pos: " + ThisWC.transform.localPosition.ToString() ) ;
				
				this.WC[WCi] = ThisWC ;
				
			} // for
			
		} // if
		
	}
	
	
	public void AnimateSuspension (float dt)
	{
		if ( this.isAlive && this.IsNotDeleted )		
		{

			
			
			if ( (this.LocalPosition - this.MainConstruct.iPhysics.iMass.LCOM).z >= 0 )
			{
				this.BlockAtBackOrFront = true ;
			} 
			else
			{
				this.BlockAtBackOrFront = false ;
			}



			this.WheelPos = new Vector3(); ;
			WheelCollider ThisWC ;
			
			List<Ray> DownRay = new List<Ray>() ;
			
			RaycastHit hit = new RaycastHit();

			for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
			{
				ThisWC = this.WC[WCi] ;
				
				// distance of the suspension and tyre
				DownRay.Add ( new Ray (ThisWC.transform.position, -Vector3.up) ) ;
				
				// check raycast for the hit with a surface
				//if (Physics.Raycast (DownRay, out hit, this.WheelTouchPoint) && this.WC.isGrounded )
				
				//Debug.Log ("Hit Dist for WCi: " + WCi+ ": " + this.HitDistance[WCi] + "; WClocalPosition: " + this.WC[WCi].transform.localPosition.ToString()) ;
				
				//if ( Physics.Raycast (DownRay[WCi], out this.Hit[WCi], this.WheelTouchPoint[WCi] ) && ThisWC.isGrounded )
				if ( Physics.Raycast (DownRay[WCi], out hit, this.WheelTouchPoint[WCi] ) && ThisWC.isGrounded )
				{
					
					//Debug.Log ("DownRayOrient: " + DownRay[WCi].direction.ToString() + "; Get new hit Dist: " + hit.distance.ToString() + "; his.WheelTouchPoint: " + this.WheelTouchPoint[WCi].ToString() + "; previous Hit Distance: " + this.HitDistance[WCi].ToString() + "; WC distance: " + ThisWC.suspensionDistance.ToString() ) ;
					//Debug.Log ("DownRayOrient: " + DownRay[WCi].direction.ToString() + "; Get new hit Dist: " + hit.distance.ToString() + "; his.WheelTouchPoint: " + this.WheelTouchPoint[WCi].ToString() + "; previous Hit Distance: " + this.HitDistance[WCi].ToString() + "; WC distance: " + ThisWC.suspensionDistance.ToString() ) ;
					
					// smoothing wheel jumping up/down
					// by limiting, by how much wheel can animate up/down displacement
					this.HitDistance[WCi] += Mathf.Clamp ((hit.distance - this.HitDistance[WCi]) / 10, -ThisWC.suspensionDistance / 10, ThisWC.suspensionDistance / 10) ;
					
					//Debug.Log ("clamped hit Dist: " + HitDistance[WCi].ToString() ) ;
					
					float WheelDist = Mathf.Clamp(this.HitDistance[WCi] - ThisWC.radius, 0, ThisWC.suspensionDistance ) * this.FacingDirection.y;
					
					//Debug.Log ("Weel distance Dist: " + WheelDist.ToString() ) ;
					
					//this.WheelPos = new Vector3 ( this.WheelInitPos.x, this.WheelInitPos.y - WheelDist, this.WheelInitPos.z);
					this.ProposedWheelPos[WCi] = new Vector3 ( this.WheelInitPos.x, this.WheelInitPos.y - WheelDist, this.WheelInitPos.z) ;
					
					//Debug.Log ("WheelInitPos: " + this.WheelInitPos.ToString() + "; ProposedWheelPos: " + this.ProposedWheelPos[WCi].ToString() ) ;
					
				}
				else 
				{
					// wheel is freely hanging
					
					// last known position
					
					//float WheelPositionSetpoint = ThisWC.suspensionDistance / 2 + ThisWC.radius ;
					//this.HitDistance[WCi] += Mathf.Clamp ((WheelPositionSetpoint - this.HitDistance[WCi]) / 10, -ThisWC.suspensionDistance / 10, ThisWC.suspensionDistance / 10) ;
					
					// smoothing wheel jumping up/down
					//float WheelDist = Mathf.Clamp(this.HitDistance[WCi] - ThisWC.radius, 0, ThisWC.suspensionDistance ) * ThisWC.FacingDirection.y;
					
					//this.WheelPos = new Vector3 ( this.WheelInitPos.x, this.WheelInitPos.y - WheelDist, this.WheelInitPos.z);
				}
				
				this.WheelPos += this.ProposedWheelPos[WCi] ;
				
				this.WC[WCi] = ThisWC ;
			}
			
			this.WheelPos /= this.WheelCollidersCount ;
			
			//Debug.Log ("Final WheelPos: " + this.WheelPos.ToString() ) ;
			
			// apply new wheel position
			this.wheel.ObjectItself.transform.localPosition = this.WheelPos ; //new Vector3 (WheelPosXYZ, this.WheelPos, WheelPosXYZ) ;
			
		}
		
		//Debug.Log ("Animate suspenssion: " + this.FacingDirection.ToString() ) ;
	}
	
	
	public void AntiSwayBar (float dt)
	{
		// anti-sway bars (anti-roll bars)
		
		if ( this.isAlive && this.IsNotDeleted )
		{
			// wheel touching the ground
			if ( this.WCisGrounded )		
			{
				// roll : - right (180 to 360) , + left (0 to 180)
				float ConstructRoll = this.GameWorldRotation.eulerAngles.z ;
				float rollAllowedLim = 60 ;
				
				float ClampedTorque = Mathf.Clamp ( this.MainConstruct.iMainPhysics.Forces.CalculatedForce.Torque.z, -this.MainConstruct.iPhysics.iMass.TotalMass, this.MainConstruct.iPhysics.iMass.TotalMass ) ;
				
				this.RollTorque = ClampedTorque / this.WheelsCount * this.RollTorqueFactor;
				
				if ( ( this.LocalPosition - this.MainConstruct.iPhysics.iMass.LCOM).x > 0f )
				{
					// is on the right
					
					// roll : - right (180 to 360) , + left (0 to 180)
					if ( ConstructRoll > 0 && ConstructRoll <= rollAllowedLim )
					{
						// rolling left
						this.SpringAntiSway = -Mathf.Abs ( this.SpringInit * ( ConstructRoll / 180f ) * this.AntiSwayForceMultipler )  ;
						this.RollTorque = -Mathf.Abs (this.RollTorque) ;
					}
					else if ( ConstructRoll >= 360 - rollAllowedLim && ConstructRoll < 360 )
					{
						// rolling right
						
						this.SpringAntiSway = Mathf.Abs ( this.SpringInit * ( 1 - (ConstructRoll / 360f) ) * 2 * this.AntiSwayForceMultipler ) ;
						this.RollTorque = Mathf.Abs (this.RollTorque) ;
						
					}
					else 
					{
						this.SpringAntiSway = 0;
						this.RollTorque = 0 ;
					}
					
				}
				else if ( ( this.LocalPosition - this.MainConstruct.iPhysics.iMass.LCOM).x < 0f )
				{
					// is on the left
					
					// roll : - right (180 to 360) , + left (0 to 180)
					if ( ConstructRoll > 0 && ConstructRoll <= rollAllowedLim )
					{
						// rolling left
						this.SpringAntiSway = Mathf.Abs ( this.SpringInit * ( ConstructRoll / 180f ) * this.AntiSwayForceMultipler );
						
						// must be positive to give force up
						this.RollTorque = Mathf.Abs (this.RollTorque) ;
						
					}
					else if ( ConstructRoll >= 360 - rollAllowedLim && ConstructRoll < 360 )
					{
						// rolling right
						this.SpringAntiSway = -Mathf.Abs (  this.SpringInit * ( 1 - (ConstructRoll / 360f) ) * 2 * this.AntiSwayForceMultipler )  ;
						this.RollTorque *= -1 ;
						this.RollTorque = -Mathf.Abs (this.RollTorque) ;
						
					}
					else 
					{
						this.SpringAntiSway = 0;
						this.RollTorque = 0 ;
					}
					
				}
				else 
				{
					this.SpringAntiSway = 0;
					this.RollTorque = 0 ;
				}
				
				// raise to by power n, keeping the sign
				if (this.SpringAntiSway < 0 )
				{
					this.SpringAntiSway = -1f * (float)Math.Pow (this.SpringAntiSway,2) ;
				} 
				else if (this.SpringAntiSway > 0 )
				{
					this.SpringAntiSway = (float)Math.Pow (this.SpringAntiSway,2) ;
				}
				
				// aplly current force
				float NewAntiSwayForce = this.SpringAntiSway + this.RollTorque ;
				
				if ( this.MainConstruct.iMainPhysics.iVelocities.VelocityMagnitude < 1 && Mathf.Abs ( this.Propulsion.Request.LastDrive ) < 0.1 )
				{
					NewAntiSwayForce *= 0.2f ;
				}
				else if ( this.MainConstruct.iMainPhysics.iVelocities.VelocityMagnitude < 5 && Mathf.Abs ( this.Propulsion.Request.LastDrive ) < 0.1 )
				{
					NewAntiSwayForce *= 0.5f ;
				}
				
				this.MainConstruct.iMainPhysics.RequestForce(GameWorldUp * NewAntiSwayForce, base.GameWorldPosition, enumForceType.Propulsion);
				
				LastLiftTime = 0;
				
			} // wheel is grounded
			else 
			{
				// wheel is floating
				
			}
		} // is alive
	}
	
	
	public float TractionAtAxis(float AppliedLocalDragForce, float VelocityDirection, Vector3 GameWorldDirection)
	{
		
		float PropulsionDragRequestAtAxis = 0 ;
		
		// -1 backwards, 0 = stop, 1 = forwards
		// -1 down, 0 = stop, 1 = up
		// -1 left, 0 = stop, 1 = right
		float MovingDirection = VelocityDirection ; //this.MainConstruct.iMainPhysics.iVelocities.LocalVelocityVector.z ;
		
		float MovingDirectionAbs = Mathf.Abs(MovingDirection) ;
		
		if ( MovingDirectionAbs > 0.001f)
		{
			
			// preventing jittering
			if ( MovingDirectionAbs < 0.05f)
			{
				AppliedLocalDragForce *= 0.5f ;
			}
			else if ( MovingDirectionAbs >= 0.05f && MovingDirectionAbs < 0.2f )
			{
				AppliedLocalDragForce *= 0.7f ;
			}
			else if ( MovingDirectionAbs >= 0.2f && MovingDirectionAbs < 0.5f )
			{
				AppliedLocalDragForce *= 0.9f ;
			}
			
			if ( MovingDirection > 0f )
			{
				PropulsionDragRequestAtAxis = -AppliedLocalDragForce ;
			} 
			else if ( MovingDirection < 0f )
			{
				PropulsionDragRequestAtAxis = AppliedLocalDragForce ;
			} 	
			
			
			// apply drag in desired axis
			//if ( this.DragEnabled )
			//{
			this.MainConstruct.iMainPhysics.RequestForce(GameWorldDirection * PropulsionDragRequestAtAxis * this.WheelsMultipler , base.GameWorldPosition, enumForceType.Propulsion);
			//}
			
		}
		
		return PropulsionDragRequestAtAxis ;
	}
	
	
	
	public bool IsThrusterModeMain()
	{
		return this.Propulsion.DriveMode == enumPropulsionDriveModes.main;
	}
	
	public override float GetPriority()
	{
		return 1f;
	}
	
	
	// ****************************** Tank Tracks Mode ************************** // 
	
	private void RunFixed(float dt)
	{
		// flip (roll) limit angle
		
		if ( this.isAlive && this.IsNotDeleted )
		{
			/*
			if ( this.BlockAtBackOrFront )
			{
				// at the front, or middle
				this.WCTSteeringLocalPosition (1) ;
			}
			else 
			{
				// at the back 
				this.WCTSteeringLocalPosition (-1) ;
			}
			*/

			this.WCisGrounded = false ;
			for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
			{
				//WheelCollider ThisWC = this.WC[WCi] ;
				this.WCisGrounded |= this.WC[WCi].isGrounded ;
			}
			
			
			if (this.WCisGrounded)
			{
				
				float RollLimitAtTurning = 10 ; // degrees
				float RollAngularVelocity = this.MainConstruct.iPhysics.iVelocities.LocalAngularVelocityVector.z ; // -0.3 to 0.3 may be dangerous, before trip over
				float RollAngularVelocityLimit = 0.2f ;
				
				if (this.steerAngle > 0f )
				{
					// when turning right 
					
					if ( RollAngularVelocity > RollAngularVelocityLimit && this.GameWorldRotation.eulerAngles.z > RollLimitAtTurning && this.GameWorldRotation.eulerAngles.z < 180 ) 
					{				
						// prevent from turning right, when rolling to the left is too big
						this.steerAngle -= (this.steerAngleStrength * 2);
					}
					else
					{
						this.steerAngle -= (this.steerAngleStrength / 2);
					}
					
				}
				else if (this.steerAngle < 0f)
				{
					// when turning left
					
					if ( RollAngularVelocity < -RollAngularVelocityLimit && this.GameWorldRotation.eulerAngles.z > 180 && this.GameWorldRotation.eulerAngles.z < 360 - RollLimitAtTurning ) 
					{				
						// prevent from turning right, when rolling to the left is too big
						this.steerAngle += (this.steerAngleStrength * 2) ;
					}
					else
					{				
						this.steerAngle += (this.steerAngleStrength / 2);
					}
					
				}


				//if ( this.TrackModeEnabled )
				//{
					//WheelCollider arg_63_0 ;
					float num;
					for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
					{
						//WheelCollider ThisWC = this.WC[WCi] ;
						//this.WCisGrounded |= this.WC[WCi].isGrounded ;
					

						// standard turning wheel
						//arg_63_0 = this.WC[WCi] ;
						num = this.steerAngle;
						
						if ( !BlockAtBackOrFront )
						{
							num *= -1 ; // on the back of construct
						}
						
						this.WC[WCi].steerAngle = num;
						//arg_63_0.steerAngle = num;

						//if (this.WCisGrounded)
						//{

						//}

						this.rotation += this.MainConstruct.iMainPhysics.iVelocities.VelocityMagnitude * 2f ;
					} // for

				//} // if
				
			} // this.WCisGrounded
			//else 
			//{
				// wheel in the air
				// reset steer angle
				//this.steerAngle  = 0;
			//}

		}

	}
	
	
	public void Left(float f)
	{
		// returning turning wheel to the position
		// turn left request
		if (this.steerAngle > this.steerAngleStrength)
		{
			// what if turn is still to the right
			this.steerAngle -= this.steerAngleStrength;
		}
		this.steerAngle = Mathf.Clamp(this.steerAngle - this.steerAngleStrength, this.minSteerAngle, this.maxSteerAngle);
	}

	public void Right(float f)
	{
		// returning turning wheel to the position
		// turn right request
		if (this.steerAngle < this.steerAngleStrength)
		{
			// what if turn is still to the left
			this.steerAngle += this.steerAngleStrength;
		}
		this.steerAngle = Mathf.Clamp(this.steerAngle + this.steerAngleStrength, this.minSteerAngle, this.maxSteerAngle);
	}
	
	
	
	
	// ****************************** Grip The surface *************************** // 
	
	
	private void GripToGround ()
	{
		
		float forwardVelocity = Mathf.Abs (this.MainConstruct.iMainPhysics.iVelocities.ForwardVelocity) ;
		float factor = 1f;
		
		this.MainConstruct.iMainPhysics.RequestForce(this.MainConstruct.worldUp * factor * (-forwardVelocity) * this.ForcePerSpeed, base.GameWorldPosition, enumForceType.ControlSurface);
		
	}
	
	public override BlockTechInfo GetTechInfo()
	{
		return new BlockTechInfo().AddSpec("Up/Down force per speed", this.ForcePerSpeed).AddStatement("Always orientated with vehicle-forwards direction");
	}
	
	
	
	
	
	// ****************************** State Changed ********************************* //
	
	public override void StateChanged(IBlockStateChange change)
	{
		base.StateChanged(change);
		if (change.IsAvailableToConstruct)
		{
			this.MainConstruct.iScheduler.RegisterFor1PerSecond(new Action<float>(this.PeriodicalCheck)) ;
			this.MainConstruct.iScheduler.RegisterFor20PerSecond(new Action<float>(this.AnimateSuspension)) ; // 20 times per second
			this.MainConstruct.iScheduler.RegisterFor20PerSecond(new Action<float>(this.AntiSwayBar)); // 
			
			this.MainConstruct.iControls.TurnWheelStore.Add(this);
			this.MainConstruct.iScheduler.RegisterForFixedUpdate(new Action<float>(this.RunFixed));
		}
		else if (change.IsLostToConstructOrConstructLost)
		{
			this.MainConstruct.iScheduler.UnregisterFor20PerSecond(new Action<float>(this.PeriodicalCheck)) ;
			this.MainConstruct.iScheduler.UnregisterFor20PerSecond(new Action<float>(this.AnimateSuspension)); // 20 times per second
			this.MainConstruct.iScheduler.UnregisterFor20PerSecond(new Action<float>(this.AntiSwayBar)); // 
			
			
			this.MainConstruct.iControls.TurnWheelStore.Remove(this);
			this.MainConstruct.iScheduler.UnregisterForFixedUpdate(new Action<float>(this.RunFixed));
		}
	}
	
	private void PeriodicalCheck (float dt)
	{
		// check if number of wheels has changed

		if ( this.isAlive && this.IsNotDeleted )
		{

			if ( this.ChecerTimeCount > 3 ) {
				
				this.ChecerTimeCount = 0 ;
				
				this.ThisWheelsList = this.MainConstruct.iBlockTypeStorageSpecific.EntireBlockCatalogue.GetBlockListingByRuntimeIdIfWeKnowIt(this.item.ComponentId.RuntimeId) ;		
				this.WheelsCount = this.ThisWheelsList.Count ;	
				
				if ( this.WheelsCount != this.MemorisedWheelCount )
				{			
					this.DamperSpringInit() ;
					this.DamperSpringScaling() ;
					this.ApplyInitSuspentionParam() ;
					
					this.MemorisedWheelCount = this.WheelsCount ;
					
					this.StuffChangedSyncIt();
				}
			} 
			else 
			{
				this.ChecerTimeCount++ ;
			}

		}
	}
	
	
	
	
	
	// ****************** GUI - Player Interaction with block ******************** //
	
	
	public override InteractionReturn Secondary()
	{
		int index = 0 ;
		
		string[] array = new string[22];
		
		
		array[index] = "PropulsionRequest: " + this.PropulsionRequest.ToString() + "; Request.LastDrive: " + this.Propulsion.Request.LastDrive +  "; roll: " + this.GameWorldRotation.eulerAngles.z.ToString() + "; steerAngle: " + this.steerAngle.ToString() + "; WheelRotationAngle: " + this.WheelRotationAngle.ToString() ;
		index++ ;
		
		//this.WheelsCount = this.ThisWheelsList.Count ;
		
		//array[index] = "Component ID: " + this.item.ComponentId.Guid.ToString() + "; Name : " + this.item.ComponentId.Name  + "; RuntimeID : " + this.item.ComponentId.RuntimeId.ToString() + "; Valid : " + this.item.ComponentId.IsValid.ToString() + "; Wheels : " +  this.WheelsCount ;
		//index++ ;
		
		//Debug.Log (array[index - 1]);
		
		//float ConstructMass = this.MainConstruct.iMainPhysics.iTotalMass.TotalMass ;
		//this.MassPerWheel = ConstructMass / this.WheelsCount ;
		
		//array[index] = "Mass: " + ConstructMass.ToString() + "; Mass/Wheel: " + this.MassPerWheel.ToString() + "; Wheels Count: "  + this.WheelsCount.ToString() ;
		//index++ ;
		
		array[index] = "Prop: " + this.MainConstruct.iMainPhysics.Forces.CalculatedForce.Force ;
		index++ ;
		
		//array[index] = "BrakeEnabled: " + this.BrakeEnabled.ToString() + "wheelFrictionCurve.stiffness: " + this.wheelFrictionCurve.stiffness.ToString() ; ;
		//index++ ;
		
		//array[index] = "Torque: " + this.MainConstruct.iMainPhysics.Forces.CalculatedForce.Torque.ToString() + "; FacingDirection: " + this.FacingDirection.ToString() ;
		//index++ ;
		
		array[index] = "PropulsionDragRequest: " + this.PropulsionDragRequest.ToString() + "; LocalDragForce: " + this.MainConstruct.iMainPhysics.LocalDragForce.ToString();
		index++ ;
		
		//array[index] = "SpringAntiSway: " + this.SpringAntiSway.ToString() + "; RollTorque: " + this.RollTorque.ToString() ;
		//index++ ;
		
		//array[index] = "LocalAngularVelocityVector: " + this.MainConstruct.iPhysics.iVelocities.LocalAngularVelocityVector.ToString() + "; AngularVelocity: " + this.MainConstruct.iPhysics.iVelocities.AngularVelocity.ToString() ;
		//index++ ;

		array[index] = "Guid: " ;

		//foreach (int RuntimeId in this.WheelComponentRuntimeIdList)
		foreach (Guid ItemGuid in this.WheelComponentGuidList)		
		{
			array[index] += ItemGuid + "; ";
		}

		index++ ;
		
		/*
		 * // forum pos reference
		 * // http://www.fromthedepthsgame.com/forum/showthread.php?tid=19235&pid=215503#pid215503
		 * // by Nick 2016-04-22, 03:35 PM Post: #9

MainConstruct.iBlockTypeStorage.EntireBlockCatalogue.GetBlockListingByRuntimeIdI​fWeKnowIt(this.item.ComponentId.RuntimeId) ;
MainConstruct.iBlockTypeStorageSpecific.EntireBlockCatalogue.GetBlockListingByRu​ntimeIdIfWeKnowIt(this.item.ComponentId.RuntimeId) ;
if (IsOnSubConstructable)
{
    GetConstructableOrSubConstructable().iBlockTypeStorageSpecific.EntireBlockC​atalogue.GetBlockListingByRuntimeIdIfWeKnowIt(this.item.ComponentId.RuntimeId) ;
}

		*/
		array[index] = "hitDistance/Grounded: " ;
		index++ ;

		WheelCollider ThisWC;
		List<Ray> DownRay = new List<Ray>() ;
		
		RaycastHit hit = new RaycastHit();
		
		for (int WCi = 0; WCi < this.WheelCollidersCount; WCi++ )
		{
			ThisWC = this.WC[WCi] ;
			
			// distance of the suspension and tyre
			
			DownRay.Add ( new Ray (ThisWC.transform.position, -Vector3.up) ) ;
			
			//float hitDistance;
			
			//float travel  = 1.0f ;
			//if ( Physics.Raycast (DownRay[WCi], out this.hit, this.WheelTouchPoint[WCi] ) && ThisWC.isGrounded )
			//{
			//	hitDistance = this.hit.distance; //Mathf.Clamp(this.hit.distance - this.WC.radius, 0, this.WC.suspensionDistance ) * this.FacingDirection.y;
			//}
			//else 
			//{
			// wheel is freely hanging
			//	hitDistance = ThisWC.suspensionDistance + this.Radius;
			//}
			
			//if ( Physics.Raycast (DownRay[WCi], out this.Hit[WCi], this.WheelTouchPoint[WCi] ) && ThisWC.isGrounded )
			if ( Physics.Raycast (DownRay[WCi], out hit, this.WheelTouchPoint[WCi] ) && ThisWC.isGrounded )
			{
				//Debug.Log ("DownRayOrient: " + DownRay[WCi].direction.ToString() + "; Get new hit Dist: " + hit.distance.ToString() + "; his.WheelTouchPoint: " + this.WheelTouchPoint[WCi].ToString() + "; previous Hit Distance: " + this.HitDistance[WCi].ToString() + "; WC distance: " + ThisWC.suspensionDistance.ToString() ) ;
				array[index] += "; [" + WCi + "]: " + this.HitDistance[WCi].ToString() + "/" + ThisWC.isGrounded.ToString() ;
				//array[index] += "; DownRayOrient: " + DownRay[WCi].direction.ToString() + "; Get new hit Dist: " + hit.distance.ToString() + "; his.WheelTouchPoint: " + this.WheelTouchPoint[WCi].ToString() + "; previous Hit Distance: " + this.HitDistance[WCi].ToString() + "; WC distance: " + ThisWC.suspensionDistance.ToString() ;
				array[index] += "; New HitDist: " + hit.distance.ToString() + this.WheelTouchPoint[WCi].ToString() + "; Prev HitDist: " + this.HitDistance[WCi].ToString() + "; WC Dist: " + ThisWC.suspensionDistance.ToString() ;
				array[index] += "; WClocPos: " + this.WC[WCi].transform.localPosition.ToString() ;
				
				index++ ;
			}
			
			this.WC[WCi] = ThisWC ;
		}
		
		array[index] = "Press Q For Settings" ;
		index++ ;
		
		
		array[index] = "Is Grounded (colides): " + this.WCisGrounded.ToString() ;
		index++ ;
		
		return new InteractionReturn(array);	
	}
	
	
	public override void Secondary(Transform T)
	{
		// standard GUI
		//	new WheelGUI().ActivateGui( this.Propulsion, GuiActivateType.Standard ) ;
		//new WheelGUI().ActivateGui( this, GuiActivateType.Standard ) ;
		//new PropulsionGUI().ActivateGui( this.Propulsion, GuiActivateType.Standard ) ;
		
		// custom GUI
		new GenericBlockGUI().ActivateGui(this, GuiActivateType.Standard);
		//new ControllableBlockGui().ActivateGui(this.Control, GuiActivateType.Standard) ;
	}
	
	
	
	/*
	 * 
	 * Nick Smart Wrote:
I've added 
Code:
if (_focus.User.ExtraGUI())
{
    DeactivateGui() ;
    return ;
}

to the PropulsionGUI so that it will make a call out to ExtraGUI of your block.
Use

Code:
public override bool ExtraGUI()
{
// your code here
}

to create you UI and change your values.

You don't need to use GetParameters and SetParameters and everything should work if you are writing your code in ExtraGUI now.


This is included in next release. (22/23 April 2016)
	 * 
	 */
	
	//public override void OnGui()
	public override bool ExtraGUI()
	{
		//GUILayout.BeginArea(new Rect(20f, 400f, 500f, 390f), "Wheel Settings GUI: " + this.name, GUI.skin.window);
		GUILayout.BeginArea(new Rect(20f, 100f, 500f, 590f), "Wheel Settings GUI: " + this.name, GUI.skin.window);
		
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
		//GUILayout.EndArea();
		/*
		ListGUI.checkScrollWheel();
		ListGUI.scrollbarValue = GUI.VerticalScrollbar(
			new Rect(ScrollAreaX, ScrollAreaY, ScrollAreaWidth, ScrollAreaHeight - 5f), 
			this.OptionsScrollArea[1].x,
			1f,
			ScrollAreaHeight - 10f,
			ButtonHeight * ButtonIndex + 10f
			);
			*/
		
		GUI.EndScrollView();
		//GUILayout.EndArea();
		
		
		/*
		// Default buttons settings
		GUILayout.BeginArea(new Rect(40f, 280f, 220f, 90f), "", GUI.skin.box);
		
		if (GUILayout.Button("Offroader ", new GUILayoutOption[0]))
		{
			this.DamperScalar = 10 ;
			this.SpringScalar = 10 ;
		}
		if (GUILayout.Button("Stiff", new GUILayoutOption[0]))
		{
			this.DamperScalar = 50 ;
			this.SpringScalar  = 50 ;
		}


		GUILayout.EndArea() ;
		*/
		
		
		/*
		GUILayout.BeginArea(new Rect(260f, 280f, 220f, 90f), "", GUI.skin.box);

		if (GUILayout.Button("Setting3 ", new GUILayoutOption[0]))		
		{
			this.DamperScalar = 10 ;		
			this.SpringScalar = 30 ;
		}

		if (GUILayout.Button("Setting4", new GUILayoutOption[0]))
		{
			this.DamperScalar = 10 ;		
			this.SpringScalar = 80 ;
		}

		GUILayout.EndArea() ;
	

		GUILayout.BeginArea(new Rect(260f, 280f, 220f, 90f), "", GUI.skin.box);

		GUILayout.VerticalScrollbar ();

		GUILayout.EndArea() ;
		*/
		
		ScrollAreaX = 255f ;
		
		//GUILayout.BeginArea(new Rect(ScrollAreaX, ScrollAreaY, ScrollAreaWidth, ScrollAreaHeight), "", GUI.skin.verticalScrollbar);
		//this.OptionsScrollPosition[1] = GUILayout.VerticalScrollbar(this.OptionsScrollPosition[1], 1.0f, 0.0f, 10.0f, new GUILayoutOption[0]) ;
		//this.OptionsScrollArea[1] = new Vector2 ( this.OptionsScrollArea[1].x, this.OptionsScrollPosition[1] ) ;
		//this.OptionsScrollArea[1] = GUILayout.BeginScrollView(this.OptionsScrollArea[1], new GUILayoutOption[0]);
		//GUILayout.BeginScrollView(this.OptionsScrollArea[1], new GUILayoutOption[0]);
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
		
		//GUILayout.EndArea();
		
		//GUILayout.BeginArea(this._s.R_HelpPanel, title, this._s.STYLE_Panel);
		//this.OptionsScrollArea[1] = GUILayout.BeginScrollView(this.OptionsScrollArea[1], new GUILayoutOption[0]);
		/*
		ListGUI.checkScrollWheel();
		ListGUI.scrollbarValue = GUI.VerticalScrollbar(
			new Rect(ScrollAreaX, ScrollAreaY, ScrollAreaWidth, ScrollAreaHeight - 5f), 
			this.OptionsScrollArea[1].x,
			1f,
			ScrollAreaHeight - 10f,
			ButtonHeight * 6 + 10f
			);
			*/
		
		
		
		GUI.EndScrollView();
		//GUILayout.EndArea();
		//GUILayout.EndScrollView();
		//GUILayout.EndArea();


		

		//float ScrollAreaY = 290f ;
		//float ScrollAreaWidth = 200f ;
		//float ScrollAreaHeight = 90f ;
		
		
		//float ButtonWidth = ScrollAreaWidth - 20;
		//float ButtonHeight = 30f;
		//float ButtonIndex = 0 ;
		
		//float ButtonPosX = 0f ;
		//float ButtonPosY = ButtonHeight ;

		ScrollAreaX = 40f ;

		float SaveLoadButtonY =  ScrollAreaY + ScrollAreaHeight + 50 ;

		//if (GUI.Button(new Rect(0f, 200f, 150f, 50f), "Copy to clipboard!"))
		if (GUI.Button(new Rect(ScrollAreaX, SaveLoadButtonY, ScrollAreaWidth, ButtonHeight), "Copy to clipboard!"))		
		{

			this.WheelMode = this.GetWheelMode (this.TrackModeEnabled, this.DriveWheelModeEnabled, this.SteerWheelModeEnabled) ;
			
			this.FacingDirectionFloat = this.GetFacingDirection ( this.FacingDirection ) ;

			// based on shield Clipboard
			//DriveWheel_UpgClipboard.SaveAsDefault(this._focus);
			DriveWheel_UpgClipboard.SaveAsDefault(this);
		}

		//ScrollAreaX = 255f ;

		if (DriveWheel_UpgClipboard.default_saved)
		{
			//if (GUI.Button(new Rect(300f, 250f, 150f, 50f), "Paste from clipboard!"))
			if (GUI.Button(new Rect(ScrollAreaX + ScrollAreaWidth + 20, SaveLoadButtonY, ScrollAreaWidth, ButtonHeight), "Paste from clipboard!"))		
			{
				//DriveWheel_UpgClipboard.LoadDefault(this._focus);
				DriveWheel_UpgClipboard.LoadDefault(this);

				this.SetWheelMode ( this.WheelMode ) ;
				
				this.SetFacingDirection ( this.FacingDirectionFloat ) ;
				
				this.DamperSpringInit() ;
				this.DamperSpringScaling() ;
				this.ApplyInitSuspentionParam() ;
				
				// P.SetShieldSizeAndPosition();
				this.StuffChangedSyncIt();
			}
		}

		// set sttings
		if (GUI.Button(new Rect(ScrollAreaX, SaveLoadButtonY + 50, ScrollAreaWidth, ButtonHeight), "Set"))		
		{
			this.DamperSpringInit () ;
			
			this.DamperSpringScaling () ;
			
			//this.StuffChangedSyncIt() ;

			this.ApplyInitSuspentionParam () ;
		
			
			this.WheelMode = this.GetWheelMode (this.TrackModeEnabled, this.DriveWheelModeEnabled, this.SteerWheelModeEnabled) ;
			
			this.FacingDirectionFloat = this.GetFacingDirection ( this.FacingDirection ) ;


			this.StuffChangedSyncIt();
		}

		// spread settings to other components, of the same type
		if (GUI.Button(new Rect(ScrollAreaX + ScrollAreaWidth + 20, SaveLoadButtonY + 50, ScrollAreaWidth, ButtonHeight), "Spread To Similar"))		
		{
			this.DamperSpringInit () ;
			
			this.DamperSpringScaling () ;
			
			//this.StuffChangedSyncIt() ;
			
			this.ApplyInitSuspentionParam () ;
			
			
			this.WheelMode = this.GetWheelMode (this.TrackModeEnabled, this.DriveWheelModeEnabled, this.SteerWheelModeEnabled) ;
			
			this.FacingDirectionFloat = this.GetFacingDirection ( this.FacingDirection ) ;


			this.StuffChangedSyncIt();


			// spread settings to other components, of the same type
			foreach ( Guid ItemGuid in this.WheelComponentGuidList )
			{
				// GetBlockListingByItemGuid
				List <Block> ConstructBlocksList = this.MainConstruct.iBlockTypeStorageSpecific.EntireBlockCatalogue.GetBlockListingByItemGuid ( ItemGuid );
				
				foreach (Block SelectedBlock in ConstructBlocksList) 
				{
					//SelectedBlock.GetParameters1().x = 1f ; // = new Vector4(this.DamperScalar, this.SpringScalar, this.AdjustTractionFraction, this.AdjustBrakeFraction);
					
					DriveWheel_Upg MyBlock = SelectedBlock as DriveWheel_Upg ;
					
					if (null != MyBlock )
					{
						MyBlock.AdjustMaxSpeedFraction = this.AdjustMaxSpeedFraction ;
						MyBlock.AdjustTractionFraction = this.AdjustTractionFraction ;
						MyBlock.AdjustBrakeFraction = this.AdjustBrakeFraction ;
						MyBlock.DamperScalar = this.DamperScalar ;
						MyBlock.SpringScalar = this.SpringScalar ;
						MyBlock.DamperSpringScaling () ;
						MyBlock.WheelMode = this.WheelMode ;
						MyBlock.TrackModeEnabled = this.TrackModeEnabled ;
						MyBlock.DriveWheelModeEnabled = this.DriveWheelModeEnabled ;
						MyBlock.SteerWheelModeEnabled = this.SteerWheelModeEnabled ;
						MyBlock.FacingDirectionFloat = this.FacingDirectionFloat ;
						MyBlock.ApplyInitSuspentionParam () ;

						MyBlock.StuffChangedSyncIt() ;
						
					} // if
					
				} // foreach
				
			} // foreach

		}


		bool result = false ;

		if (GuiCommon.DisplayCloseButton(500))
		{
			result = true ;

		}

		GUILayout.EndArea() ;
		
		//Debug.Log ("Null Ref 11");
		
		return result ;
		
	}
	
	
	// self balancing sliders
	// sliders total sum is above 100% 
	private float BalancingSliderHigh (float ValueIn, float ParametersSum, int TotalSliderCount, int SliderId)
	{
		// divide parameters to match 100;
		if (ParametersSum > 100f)
		{
			int sliderRef = TotalSliderCount - SliderId;
			
			// too much
			float TooMuch = ParametersSum - 100;
			
			if (ValueIn > TooMuch / sliderRef && sliderRef > 1 )
			{ 
				TooMuch /= sliderRef;
				ValueIn -= Mathf.Round( TooMuch * 100 ) / 100;
			}
			else if ( TooMuch > 0 && sliderRef == 1 )
			{ 
				ValueIn -= Mathf.Round( TooMuch * 100 ) / 100;
			}
			else 
			{
				ValueIn = 0;
			}
			
		}
		return ValueIn;
	}
	
	
	// sliders total sum is below 100%
	private float BalancingSliderLow (float ValueIn, float ParametersSum, int TotalSliderCount, int SliderId)
	{
		// divide parameters to match 100;
		if (ParametersSum < 100f)
		{
			int sliderRef = TotalSliderCount - SliderId ;
			
			float TooLittle = 100 - ParametersSum ;
			
			TooLittle /= sliderRef ;
			
			// too little
			if (100 - ValueIn > TooLittle)
			{
				ValueIn += Mathf.Round( ( TooLittle ) * 100 ) / 100 ;
			}
			else 
			{
				ValueIn = 100 ;
			}
		}
		return ValueIn;
	}
	
	
}

public class CarSpoiler : Block
{
	private float Lift = 0.5f;
	
	private AttributeSkyCaptain A_ = new AttributeSkyCaptain(0);
	
	private enumBlockOrientations BlockOrientation ;
	
	public override void ItemSet()
	{
		base.ItemSet();
		
		this.Lift = this.item.Code.Variables.GetFloat("LiftBy100", this.Lift ) / 100 ;
	}
	
	public override void BlockStart()
	{
		this.A_ = this.MainConstruct.iAvatarModifiers.GetSkyCaptain();
		base.BlockStart();
		
		this.BlockOrientation = StaticMaths.DetermineBlockOrientation(this.LocalForward) ;
		
		Planet planet = new Planet() ;
		
	}
	
	private void FixedUpdatePhysics(float dt)
	{
		float VelocityInDirection = this.MainConstruct.iMainPhysics.iVelocities.VelocityInParticularDirection(base.GameWorldForwards);
		
		float CombinedAirDensityFraction = StaticMaths.TwoPointInterpolate(
			new Vector2(WorldSpecification.i.Physics.AirDensityBeings,1),
			new Vector2(WorldSpecification.i.Physics.AirDensityEnds,0f),
			this.AltitudeAboveMeanSeaLevel) ;
		
		
		// enumForceType.ControlSurface
		if ( this.MainConstruct.iMainPhysics.iVelocities.VelocityVector.z > 0 )
		{
			// acting force in forward direction
			if ( this.BlockOrientation == enumBlockOrientations.forwards )
			{
				this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * -this.Lift * VelocityInDirection * CombinedAirDensityFraction * this.A_.ControlSurfaceForce.CurrentValue, base.GameWorldPosition, enumForceType.LiftSurface);
				//this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * -this.Lift * VelocityInDirection * CombinedAirDensityFraction * this.A_.tailplaneForcePerSpeedMultiplier, base.GameWorldPosition, enumForceType.LiftSurface);
			}
			else 
			{
				// acting lift force in backwards is much smaller
				this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * (-this.Lift / 10) * VelocityInDirection * CombinedAirDensityFraction * this.A_.ControlSurfaceForce.CurrentValue, base.GameWorldPosition, enumForceType.LiftSurface);
				//this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * (-this.Lift / 10) * VelocityInDirection * CombinedAirDensityFraction * this.A_.tailplaneForcePerSpeedMultiplier, base.GameWorldPosition, enumForceType.LiftSurface);
			}
			
		}
		else 
		{
			
			// acting force in reverse direction
			if ( this.BlockOrientation == enumBlockOrientations.backwards )
			{
				this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * -this.Lift * VelocityInDirection * CombinedAirDensityFraction * this.A_.ControlSurfaceForce.CurrentValue, base.GameWorldPosition, enumForceType.LiftSurface);
				//this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * -this.Lift * VelocityInDirection * CombinedAirDensityFraction * this.A_.tailplaneForcePerSpeedMultiplier, base.GameWorldPosition, enumForceType.LiftSurface);
			}
			else 
			{
				// acting lift force in backwards is much smaller
				this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * (-this.Lift / 10) * VelocityInDirection * CombinedAirDensityFraction * this.A_.ControlSurfaceForce.CurrentValue, base.GameWorldPosition, enumForceType.LiftSurface);
				//this.MainConstruct.iMainPhysics.RequestForce(base.GameWorldUp * (-this.Lift / 10) * VelocityInDirection * CombinedAirDensityFraction * this.A_.tailplaneForcePerSpeedMultiplier, base.GameWorldPosition, enumForceType.LiftSurface);
			}
		}
	}
	
	public override void StateChanged(IBlockStateChange change)
	{
		base.StateChanged(change);
		if (change.IsAvailableToConstruct)
		{
			base.GetConstructableOrSubConstructable().iScheduler.RegisterForFixedUpdate(new Action<float>(this.FixedUpdatePhysics));
		}
		else if (change.IsLostToConstructOrConstructLost)
		{
			base.GetConstructableOrSubConstructable().iScheduler.UnregisterForFixedUpdate(new Action<float>(this.FixedUpdatePhysics));
		}
	}
	
}

/*
MeshDefinition testMesh = new MeshDefinition();
Mesh mesh0 = this.Mesh;
//mesh0.UploadMeshData()
testMesh.Mesh = this.Mesh;
//testMesh.Source
*/
