using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Broccoli.Pipe {
	/// <summary>
	/// Branch mapper element.
	/// </summary>
	[System.Serializable]
	public class BranchMapperElement : PipelineElement {
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
			get { return PipelineElement.ElementType.MeshTransform; }
		}
		/// <summary>
		/// Gets the type of the class.
		/// </summary>
		/// <value>The type of the class.</value>
		public override ClassType classType {
			get { return PipelineElement.ClassType.BranchMapper; }
		}
		/// <summary>
		/// Value used to position elements in the pipeline. The greater the more towards the end of the pipeline.
		/// </summary>
		/// <value>The position weight.</value>
		public override int positionWeight {
			get {
				return PipelineElement.mapperWeight;
			}
		}
		/// <summary>
		/// True to use a custom material on the branches.
		/// </summary>
		public bool useCustomMaterial = false;
		/// <summary>
		/// The custom material.
		/// </summary>
		public Material customMaterial;
		/// <summary>
		/// The main texture.
		/// </summary>
		public Texture2D mainTexture;
		/// <summary>
		/// The normal map texture.
		/// </summary>
		public Texture2D normalTexture;
		/// <summary>
		/// The mapping X displacement.
		/// </summary>
		public float mappingXDisplacement = 0f;
		/// <summary>
		/// The mapping Y displacement.
		/// </summary>
		public float mappingYDisplacement = 0f;
		/// <summary>
		/// The UV mapping is sensitive to branch girth changes..
		/// </summary>
		public bool isGirthSensitive = false;
		/// <summary>
		/// If true the UV mapping on children branches gets an offset from ther position on their parent branch.
		/// </summary>
		public bool applyMappingOffsetFromParent = false;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Broccoli.Pipe.BranchMapperElement"/> class.
		/// </summary>
		public BranchMapperElement () {}
		#endregion

		#region Validation
		/// <summary>
		/// Validate this instance.
		/// </summary>
		public override bool Validate () {
			log.Clear ();
			if (useCustomMaterial) {
				if (customMaterial == null) {
					log.Enqueue (LogItem.GetWarnItem ("No custom material has been assigned to this mapper."));
				}
			} else {
				if (mainTexture == null) {
					log.Enqueue (LogItem.GetWarnItem ("No main texture has been assigned to this mapper."));
				}
			}
			return true;
		}
		#endregion

		#region Cloning
		/// <summary>
		/// Clone this instance.
		/// </summary>
		override public PipelineElement Clone() {
			BranchMapperElement clone = ScriptableObject.CreateInstance<BranchMapperElement> ();
			SetCloneProperties (clone);
			clone.useCustomMaterial = useCustomMaterial;
			clone.customMaterial = customMaterial;
			clone.mainTexture = mainTexture;
			clone.normalTexture = normalTexture;
			clone.mappingXDisplacement = mappingXDisplacement;
			clone.mappingYDisplacement = mappingYDisplacement;
			clone.isGirthSensitive = isGirthSensitive;
			clone.applyMappingOffsetFromParent = applyMappingOffsetFromParent;
			return clone;
		}
		#endregion
	}
}