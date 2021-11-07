using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Broccoli.Pipe {
	/// <summary>
	/// Girth transform element.
	/// </summary>
	[System.Serializable]
	public class GirthTransformElement : PipelineElement {
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
			get { return PipelineElement.ClassType.GirthTransform; }
		}
		/// <summary>
		/// Value used to position elements in the pipeline. The greater the more towards the end of the pipeline.
		/// </summary>
		/// <value>The position weight.</value>
		public override int positionWeight {
			get { return PipelineElement.structureTransformWeight + 20; }
		}
		/// <summary>
		/// The girth at top of the tree.
		/// </summary>
		public float girthAtTop = 0.05f;
		/// <summary>
		/// The girth at base of the tree.
		/// </summary>
		public float girthAtBase = 0.5f;
		/// <summary>
		/// The transition curve.
		/// </summary>
		public AnimationCurve curve = 
			AnimationCurve.Linear(0f, 0f, 1f, 1f);
		/// <summary>
		/// Enables hierarchy scaling for branches, depending on their position and length of the tree.
		/// </summary>
		public bool hierarchyScalingEnabled = false;
		/// <summary>
		/// The minimum hierarchy scaling.
		/// </summary>
		public float minHierarchyScaling = 1f;
		/// <summary>
		/// The maximum hierarchy scaling.
		/// </summary>
		public float maxHierarchyScaling = 1f;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Broccoli.Pipe.GirthTransformElement"/> class.
		/// </summary>
		public GirthTransformElement () {}
		#endregion

		#region Cloning
		/// <summary>
		/// Clone this instance.
		/// </summary>
		override public PipelineElement Clone() {
			GirthTransformElement clone = ScriptableObject.CreateInstance<GirthTransformElement> ();
			SetCloneProperties (clone);
			clone.girthAtTop = girthAtTop;
			clone.girthAtBase = girthAtBase;
			clone.curve = new AnimationCurve(curve.keys);
			clone.hierarchyScalingEnabled = hierarchyScalingEnabled;
			clone.maxHierarchyScaling = maxHierarchyScaling;
			clone.minHierarchyScaling = minHierarchyScaling;
			return clone;
		}
		#endregion
	}
}