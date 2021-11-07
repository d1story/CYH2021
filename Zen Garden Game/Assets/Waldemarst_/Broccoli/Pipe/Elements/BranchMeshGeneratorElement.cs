using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Broccoli.Builder;

namespace Broccoli.Pipe {
	/// <summary>
	/// Branch mesh generator element.
	/// </summary>
	[System.Serializable]
	public class BranchMeshGeneratorElement : PipelineElement {
		#region Vars
		/// <summary>
		/// Gets the type of the connection.
		/// </summary>
		/// <value>The type of the connection.</value>
		public override ConnectionType connectionType {
			get { return ConnectionType.Transform; }
		}
		/// <summary>
		/// Gets the type of the element.
		/// </summary>
		/// <value>The type of the element.</value>
		public override ElementType elementType {
			get { return ElementType.MeshGenerator; }
		}
		/// <summary>
		/// Gets the type of the class.
		/// </summary>
		/// <value>The type of the class.</value>
		public override ClassType classType {
			get { return ClassType.BranchMeshGenerator; }
		}
		/// <summary>
		/// Value used to position elements in the pipeline. The greater the more towards the end of the pipeline.
		/// </summary>
		/// <value>The position weight.</value>
		public override int positionWeight {
			get {
				return PipelineElement.meshGeneratorWeight;
			}
		}
		/// <summary>
		/// The minimum polygon sides.
		/// </summary>
		public int minPolygonSides = 3;
		/// <summary>
		/// The max polygon sides.
		/// </summary>
		public int maxPolygonSides = 8;
		/// <summary>
		/// The segment angle.
		/// </summary>
		public float segmentAngle = 0f;
		/// <summary>
		/// The generated mesh uses hard normals.
		/// </summary>
		public bool useHardNormals = false;
		/// <summary>
		/// The minimum branch curve resolution to generate a branch mesh (LOD1).
		/// </summary>
		public float minBranchCurveResolution = 0.25f;
		/// <summary>
		/// The maximum branch curve resolution to generate a branch mesh (LOD0).
		/// </summary>
		public float maxBranchCurveResolution = 0.75f;
		/// <summary>
		/// Level of LOD information to show.
		/// </summary>
		[System.NonSerialized]
		public int showLODInfoLevel = -1;
		/// <summary>
		/// The minimum girth.
		/// </summary>
		[System.NonSerialized]
		public float minGirth;
		/// <summary>
		/// The max girth.
		/// </summary>
		[System.NonSerialized]
		public float maxGirth;
		/// <summary>
		/// The vertices count for the first pass LOD.
		/// </summary>
		[System.NonSerialized]
		public int verticesCountFirstPass = 0;
		/// <summary>
		/// The triangles count for the first pass LOD.
		/// </summary>
		[System.NonSerialized]
		public int trianglesCountFirstPass = 0;
		/// <summary>
		/// The vertices count for the second pass LOD.
		/// </summary>
		[System.NonSerialized]
		public int verticesCountSecondPass = 0;
		/// <summary>
		/// The triangles count for the second pass LOD.
		/// </summary>
		[System.NonSerialized]
		public int trianglesCountSecondPass = 0;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Broccoli.Pipe.BranchMeshGeneratorElement"/> class.
		/// </summary>
		public BranchMeshGeneratorElement () {}
		#endregion

		#region Cloning
		/// <summary>
		/// Clone this instance.
		/// </summary>
		override public PipelineElement Clone() {
			BranchMeshGeneratorElement clone = ScriptableObject.CreateInstance<BranchMeshGeneratorElement> ();
			SetCloneProperties (clone);
			clone.minPolygonSides = minPolygonSides;
			clone.maxPolygonSides = maxPolygonSides;
			clone.minGirth = minGirth;
			clone.maxGirth = maxGirth;
			clone.segmentAngle = segmentAngle;
			clone.useHardNormals = useHardNormals;
			return clone;
		}
		#endregion
	}
}