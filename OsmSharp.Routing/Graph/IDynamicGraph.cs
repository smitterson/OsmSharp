﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2013 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

namespace OsmSharp.Routing.Graph
{
    /// <summary>
    /// Abstracts a graph implementation.
    /// </summary>
    public interface IDynamicGraph<TEdgeData> : IDynamicGraphWriteOnly<TEdgeData>
        where TEdgeData : IDynamicGraphEdgeData
    {
        /// <summary>
        /// Deletes all arcs starting at the given vertex.
        /// </summary>
        /// <param name="vertex"></param>
        void DeleteArc(uint vertex);

        /// <summary>
        /// Delete all arcs arc between two vertices.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void DeleteArc(uint from, uint to);

        /// <summary>
        /// Trims the graph to store a max number of vertices.
        /// </summary>
        /// <param name="max"></param>
        void Trim(uint max);
    }
}