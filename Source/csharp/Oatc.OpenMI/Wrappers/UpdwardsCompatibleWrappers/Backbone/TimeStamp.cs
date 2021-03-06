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

using System;
using Oatc.UpwardsComp.Standard;

namespace Oatc.UpwardsComp.Backbone
{

  /// <summary>
  /// The TimeStamp class defines a time instant.
  /// <para>This is a trivial implementation of OpenMI.Standard.TimeStamp, refer there for further details.</para>
  /// </summary>
  [Serializable]
  public class TimeStamp : ITimeStamp, global::OpenMI.Standard2.TimeSpace.ITime, IComparable, System.IEquatable<global::OpenMI.Standard2.TimeSpace.ITime>
  {
    private double _time;

    /// <summary>
    /// Constructor
    /// </summary>
    public TimeStamp()
    {
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="source">The time stamp to copy</param>
    public TimeStamp(ITimeStamp source)
    {
      ModifiedJulianDay = source.ModifiedJulianDay;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ModifiedJulianDay">The modified julian day for the time stamp</param>
    public TimeStamp(double ModifiedJulianDay)
    {
      _time = ModifiedJulianDay;
    }

    /// <summary>
    /// Getter and setter for the modified julian day
    /// </summary>
    public double ModifiedJulianDay
    {
      get { return _time; }
      set { _time = value; }
    }

    public bool Equals(global::OpenMI.Standard2.TimeSpace.ITime other)
    {
        return (TimeHelper.Equals(this, other));
    }

    public override bool Equals(Object obj)
    {
        if (obj is global::OpenMI.Standard2.TimeSpace.ITime)
            return (Equals((global::OpenMI.Standard2.TimeSpace.ITime) obj));
        return (false);
    }

    public int CompareTo(object obj)
    {
        if (obj is global::OpenMI.Standard2.TimeSpace.ITime)
        {
            return (TimeHelper.CompareTo(this, (global::OpenMI.Standard2.TimeSpace.ITime)obj));
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the hash code
    /// </summary>
    /// <returns>The hash code</returns>
    public override int GetHashCode()
    {
      return _time.GetHashCode();
    }



      /// <summary>
    /// Converts the time stamp to a string
    /// </summary>
    /// <returns>String converted time stamp</returns>
    public override String ToString()
    {
      return _time.ToString();
    }

    #region Implementation of ITime

    public double StampAsModifiedJulianDay
    {
      get { return (_time); }
    }

    public double DurationInDays
    {
      get { return (0.0); }
    }

    #endregion
  }
}

