﻿// OsmSharp - OpenStreetMap tools & library.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OsmSharp.Math.Geo;

namespace OsmSharp.Geo.Geometries
{
    /// <summary>
    /// Represents a lineair ring, a polygon without holes.
    /// </summary>
    public class LineairRing : LineString
    {
        /// <summary>
        /// Creates a new lineair ring.
        /// </summary>
        public LineairRing()
        {

        }

        /// <summary>
        /// Creates a new lineair ring.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        public LineairRing(IEnumerable<GeoCoordinate> coordinates)
            : base(coordinates)
        {

        }

        /// <summary>
        /// Creates a new lineair ring.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        public LineairRing(params GeoCoordinate[] coordinates)
            : base(coordinates)
        {

        }

        /// <summary>
        /// Returns true if the given ring is contained in this ring.
        /// </summary>
        /// <param name="lineairRing"></param>
        /// <returns></returns>
        public bool Contains(LineairRing lineairRing)
        {
            // TODO: implement a contains method.
            return false;
        }
    }
}