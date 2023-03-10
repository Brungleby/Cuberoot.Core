
/** NodeSearchWindow.cs
*
*	Created by LIAM WOFFORD of CUBEROOT SOFTWARE, LLC.
*
*	Free to use or modify, with or without creditation,
*	under the Creative Commons 0 License.
*/

#region Includes

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor;
using UnityEditor.Experimental.GraphView;

#endregion

namespace Cuberoot.Editor
{
	/// <summary>
	/// __TODO_ANNOTATE__
	///</summary>

	public sealed class NodeSearchWindow : ScriptableObject, ISearchWindowProvider
	{
		#region Data

		#region

		private CustomNodeGraphView _graph;

		#endregion

		#endregion
		#region Methods

		#region

		public void InitializeFor(CustomNodeGraphView graph)
		{
			_graph = graph;
		}

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) =>
			_graph.CreateSearchTree(context);

		public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			Type type = (Type)searchTreeEntry.userData;

			_graph.CreateNewNodeAtCursor(type);
			return true;
		}

		#endregion

		#endregion
	}
}
