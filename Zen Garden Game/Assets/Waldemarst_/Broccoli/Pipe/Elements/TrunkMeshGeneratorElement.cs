using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Broccoli.Pipe {
	/// <summary>
	/// Girth transform element.
	/// </summary>
	[System.Serializable]
	public class TrunkMeshGeneratorElement : PipelineElement {
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
			get { return PipelineElement.ElementType.MeshGenerator; }
		}
		/// <summary>
		/// Gets the type of the class.
		/// </summary>
		/// <value>The type of the class.</value>
		public override ClassType classType {
			get { return PipelineElement.ClassType.TrunkMeshGenerator; }
		}
		/// <summary>
		/// Value used to position elements in the pipeline. The greater the more towards the end of the pipeline.
		/// </summary>
		/// <value>The position weight.</value>
		public override int positionWeight {
			get { return PipelineElement.meshGeneratorWeight + 10; }
		}
		/// <summary>
		/// How much the trunk mesh spreads across the main trunk structure, minimum range to use in randomization.
		/// </summary>
		[Range (0,1)]
		public float minSpread = 0.2f;
		/// <summary>
		/// How much the trunk mesh spreads across the main trunk structure, maximum range to use in randomization.
		/// </summary>
		[Range (0,1)]
		public float maxSpread = 0.4f;
		[Range (3, 10)]
		public int minDisplacementPoints = 3;
		[Range (3, 10)]
		public int maxDisplacementPoints = 6;
		[Range (0f, 0.5f)]
		public float minDisplacementAngleVariance = 0.1f;
		[Range (0f, 1f)]
		public float maxDisplacementAngleVariance = 0.5f;
		[Range (-2f, 2f)]
		public float minDisplacementTwirl = 0f;
		[Range (-2f, 2f)]
		public float maxDisplacementTwirl = 0f;
		/// <summary>
		/// Scaling factor to use at the base of the trunk, minimum value in the randomized range.
		/// </summary>s
		[Range (1f,3f)]
		public float minDisplacementScaleAtBase = 1.2f;
		/// <summary>
		/// Scaling factor to use at the base of the trunk, maximum value in the randomized range.
		/// </summary>
		[Range (1f,3f)]
		public float maxDisplacementScaleAtBase = 1.8f;
		/// <summary>
		/// The transition curve for scale.
		/// </summary>
		public AnimationCurve scaleCurve = 
			AnimationCurve.Linear(0f, 0f, 1f, 1f);
		/// <summary>
		/// How much the trunk ripples reflect on the mesh.
		/// </summary>
		[Range (0,1)]
		public float strength = 0.3f;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Broccoli.Pipe.TrunkMeshGeneratorElement"/> class.
		/// </summary>
		public TrunkMeshGeneratorElement () {}
		#endregion

		#region Cloning
		/// <summary>
		/// Clone this instance.
		/// </summary>
		override public PipelineElement Clone() {
			TrunkMeshGeneratorElement clone = ScriptableObject.CreateInstance<TrunkMeshGeneratorElement> ();
			SetCloneProperties (clone);
			clone.minSpread = minSpread;
			clone.maxSpread = maxSpread;
			clone.minDisplacementPoints = minDisplacementPoints;
			clone.maxDisplacementPoints = maxDisplacementPoints;
			clone.minDisplacementAngleVariance = minDisplacementAngleVariance;
			clone.maxDisplacementAngleVariance = maxDisplacementAngleVariance;
			clone.minDisplacementTwirl = minDisplacementTwirl;
			clone.maxDisplacementTwirl = maxDisplacementTwirl;
			clone.minDisplacementScaleAtBase = minDisplacementScaleAtBase;
			clone.maxDisplacementScaleAtBase = maxDisplacementScaleAtBase;
			clone.scaleCurve = new AnimationCurve(scaleCurve.keys);
			clone.strength = strength;
			return clone;
		}
		#endregion
	}
}