using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Broccoli.Pipe {
	/// <summary>
	/// Branch bender element.
	/// </summary>
	[System.Serializable]
	public class BranchBenderElement : PipelineElement {
		#region Vars
		/// <summary>
		/// Gets the type of the connection.
		/// </summary>
		/// <value>The type of the connection.</value>
		public override ConnectionType connectionType {
			get { return PipelineElement.ConnectionType.Transform; }
		}
		/// <summary>
		/// Gets the type of the element.
		/// </summary>
		/// <value>The type of the element.</value>
		public override ElementType elementType {
			get { return PipelineElement.ElementType.StructureTransform; }
		}
		/// <summary>
		/// Gets the type of the class.
		/// </summary>
		/// <value>The type of the class.</value>
		public override ClassType classType {
			get { return PipelineElement.ClassType.BranchBender; }
		}
		/// <summary>
		/// Value used to position elements in the pipeline. The greater the more towards the end of the pipeline.
		/// </summary>
		/// <value>The position weight.</value>
		public override int positionWeight {
			get { return PipelineElement.structureTransformWeight + 40; }
		}
		/// <summary>
		/// Gets a value indicating whether this <see cref="Broccoli.Pipe.BranchBenderElement"/> uses randomization.
		/// </summary>
		/// <value><c>true</c> if uses randomization; otherwise, <c>false</c>.</value>
		public override bool usesRandomization {
			get { return true; }
		}
		public bool applyJointSmoothing = true;
		public float smoothJointStrength = 0.75f;
		public bool applyDirectionalBending = true;
		public float forceAtTips = 0.5f;
		public float forceAtTrunk = 0f;
		public Vector3 direction = Base.GlobalSettings.gravityDirection;
		public AnimationCurve hierarchyDistributionCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);
		public bool applyBranchNoise = false;
		public float noiseAtTop = 0.5f;
		public float noiseAtBase = 0.2f;
		public float noiseScaleAtTop = 0.5f;
		public float noiseScaleAtBase = 0.2f;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Broccoli.Pipe.BranchBenderElement"/> class.
		/// </summary>
		public BranchBenderElement () {}
		#endregion

		#region Clone
		/// <summary>
		/// Clone this instance.
		/// </summary>
		override public PipelineElement Clone() {
			BranchBenderElement clone = ScriptableObject.CreateInstance<BranchBenderElement> ();
			SetCloneProperties (clone);
			clone.applyJointSmoothing = applyJointSmoothing;
			clone.smoothJointStrength = smoothJointStrength;
			clone.applyDirectionalBending = applyDirectionalBending;
			clone.forceAtTips = forceAtTips;
			clone.forceAtTrunk = forceAtTrunk;
			clone.direction = direction;
			clone.hierarchyDistributionCurve = new AnimationCurve (hierarchyDistributionCurve.keys);
			clone.applyBranchNoise = applyBranchNoise;
			clone.noiseAtBase = noiseAtBase;
			clone.noiseAtTop = noiseAtTop;
			clone.noiseScaleAtBase = noiseScaleAtBase;
			clone.noiseScaleAtTop = noiseScaleAtTop;
			return clone;
		}
		#endregion
	}
}