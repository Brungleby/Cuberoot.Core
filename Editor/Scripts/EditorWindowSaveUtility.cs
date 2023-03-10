
/** EditorWindowSaveUtility.cs
*
*	Created by LIAM WOFFORD of CUBEROOT SOFTWARE, LLC.
*
*	Free to use or modify, with or without creditation,
*	under the Creative Commons 0 License.
*/

#region Includes

using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.Experimental.GraphView;

#endregion

namespace Cuberoot.Editor
{
	/// <summary>
	/// Assists with saving and loading of Node Graphs.
	///</summary>

	public sealed class EditorWindowSaveUtility : object
	{
		#region Data

		#region

		private CustomNodeGraphView _graph;
		private CustomNodeGraphData _dataCache;

		private List<Edge> Edges => _graph.edges.ToList();
		private List<CustomNode> Nodes => _graph.nodes.ToList().Cast<CustomNode>().ToList();

		#endregion

		#endregion
		#region Methods

		#region

		public static EditorWindowSaveUtility GetInstance(CustomNodeGraphView target)
		{
			return new EditorWindowSaveUtility
			{
				_graph = target,
			};
		}

		public void SaveTargetToFile(string filePath)
		{
			// /**	Asserts no data if there are NOT any NON-predefined nodes.
			// */
			// if (!Nodes.Where(i => !i.IsPredefined).Any())
			// {
			// 	try { Utils.PromptConfirmation($"\"{filePath}\"\n\nThis graph is empty. Proceed to save the file anyway?"); }
			// 	catch { return; }
			// }

			var __data = ScriptableObject.CreateInstance<CustomNodeGraphData>();

			foreach (var iNode in Nodes)
			{
				__data.Nodes.Add(new NodeData
				{
					Guid = iNode.Guid,
					Subtype = iNode.GetType(),
					Title = iNode.title,
					Rect = iNode.GetPosition(),
				});
			}

			Utils.CreateAssetAtFilePath(__data, filePath, false);
		}

		public void LoadFileToTarget(string filePath)
		{
			_dataCache = AssetDatabase.LoadAssetAtPath<CustomNodeGraphData>(filePath);

			// try { Utils.AssertObject(_dataCache, $"No data was found at local path \"{filePath}\"."); }
			// catch { return; }

			_graph.ClearAllNodes();

			#region Create Nodes

			foreach (var iNodeData in _dataCache.Nodes)
			{
				var __node = _graph.CreateNewNode(iNodeData);

				// var __ports = 
			}

			#endregion

			_dataCache = null;
		}

		#endregion

		#endregion
	}
}
