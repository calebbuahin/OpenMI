#region Copyright
/*
* Copyright (c) 2005-2010, OpenMI Association
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*     * Neither the name of the OpenMI Association nor the
*       names of its contributors may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY "OpenMI Association" ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL "OpenMI Association" BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion
#region Copyright
///////////////////////////////////////////////////////////
//
// namespace: Oatc.OpenMI.Examples.ModelComponents.SimpleRiver.Wrapper.UnitTest 
// purpose: Unit-testing the package Oatc.OpenMI.Examples.ModelComponents.SimpleRiver.Wrapper
// file: TestRunoffDataLC.cs
//
///////////////////////////////////////////////////////////
//
//    Copyright (C) 2006 OpenMI Association
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//    or look at URL www.gnu.org/licenses/lgpl.html
//
//    Contact info: 
//      URL: www.openmi.org
//	Email: sourcecode@openmi.org
//	Discussion forum available at www.sourceforge.net
//
//      Coordinator: Roger Moore, CEH Wallingford, Wallingford, Oxon, UK
//
///////////////////////////////////////////////////////////
//
//  Original author: Jan B. Gregersen, DHI - Water & Environment, Horsholm, Denmark
//  Created on:      6 April 2005
//  Version:         1.0.0 
//
//  Modification history:
//  
//
///////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections;
using Oatc.OpenMI.Wrappers.EngineWrapper;
using Oatc.OpenMI.Wrappers.EngineWrapper.UnitTest;
using OpenMI.Standard2;
using Oatc.OpenMI.Sdk.Backbone;
using OpenMI.Standard2.TimeSpace;

namespace Oatc.OpenMI.Examples.ModelComponents.SimpleRiver.Wrapper.UnitTest
{
	/// <summary>
	/// Summary description for TestRiverLC.
	/// </summary>
	public class RunoffDataLC : TestEngine
	{
        Describable _instance = new Describable(
            "RunoffDataLC",
            "RunoffDataLC UnitTest");

		public RunoffDataLC()
		{
			Id = "TestRunoffDataLCIDModelID";
			Description = "TestRunoffDataLCIDModelDescription";

			_timeStepLength = 3600*24;
		}

        public override void Initialize()
        {
            base.Initialize();
            double startTime = new Time(new DateTime(2004, 10, 7, 16, 38, 32)).StampAsModifiedJulianDay;
            Time simulationStart = new Time(startTime);
            Time simulationEnd = new Time(startTime + 99999999999999);

            _timeHorizon = new Time(simulationStart, simulationEnd);

            _dataItems = new ArrayList();

            // -- the outflow item --
            DataItem dataItem = new DataItem("Runoff", "Catchments");
            dataItem._values = new double[3];
            dataItem._values[0] = 1;
            dataItem._values[1] = 2;
            dataItem._values[2] = 3;

            _dataItems.Add(dataItem);

            ElementSet catchments = new ElementSet("Catchments", "Catchments", ElementType.Polygon, "");
            Element catchment1 = new Element("Catchment1");
            Element catchment2 = new Element("Catchment2");
            Element catchment3 = new Element("Catchment3");

            catchment1.AddVertex(new Coordinate(0, 7000, 0));
            catchment1.AddVertex(new Coordinate(2000, 5000, 0));
            catchment1.AddVertex(new Coordinate(4000, 5000, 0));
            catchment1.AddVertex(new Coordinate(6000, 9000, 0));
            catchment1.AddVertex(new Coordinate(5000, 10000, 0));
            catchment1.AddVertex(new Coordinate(3000, 11000, 0));
            catchment1.AddVertex(new Coordinate(1000, 11000, 0));
            catchment1.AddVertex(new Coordinate(0, 10000, 0));

            catchment2.AddVertex(new Coordinate(2000, 5000, 0));
            catchment2.AddVertex(new Coordinate(3000, 4000, 0));
            catchment2.AddVertex(new Coordinate(6000, 5000, 0));
            catchment2.AddVertex(new Coordinate(9000, 8000, 0));
            catchment2.AddVertex(new Coordinate(8000, 9000, 0));
            catchment2.AddVertex(new Coordinate(5000, 10000, 0));
            catchment2.AddVertex(new Coordinate(6000, 9000, 0));
            catchment2.AddVertex(new Coordinate(4000, 5000, 0));

            catchment3.AddVertex(new Coordinate(3000, 4000, 0));
            catchment3.AddVertex(new Coordinate(5000, 2000, 0));
            catchment3.AddVertex(new Coordinate(10000, 0000, 0));
            catchment3.AddVertex(new Coordinate(13000, 0000, 0));
            catchment3.AddVertex(new Coordinate(15000, 2000, 0));
            catchment3.AddVertex(new Coordinate(13000, 6000, 0));
            catchment3.AddVertex(new Coordinate(9000, 8000, 0));
            catchment3.AddVertex(new Coordinate(6000, 5000, 0));

            catchments.AddElement(catchment1);
            catchments.AddElement(catchment2);
            catchments.AddElement(catchment3);

            Quantity quantity = new Quantity(new Unit("m3/sec", 1, 0, "m3/sec"), "Runoff", "Runoff");

            EngineSOutputItem runoffItem = new EngineSOutputItem("Catchments", quantity, catchments, this);

            EngineOutputItems.Add(runoffItem);

        }
	
    }
}
