﻿/* State v5 finite state machine library
 * http://www.steelbreeze.net/state.cs
 * Copyright (c) 2014-5 Steelbreeze Limited
 * Licensed under MIT and GPL v3 licences
 */
using System;
using System.Collections.Generic;

namespace Steelbreeze.Behavior.StateMachines {
	/// <summary>
	/// A simple sample of an object to extend as a base for a state machine context object.
	/// </summary>
	/// <typeparam name="TContext">The type of the derived context class.</typeparam>
	/// <remarks>
	/// By passing the type of the derived class into this base, it allows the callbacks generated by the state machine to pass the fully typed derived class.
	/// Note that properties and methods have been explicitly implemented to hide the members from use other than via the IContext interface.
	/// Should you need persistence, or other such behaviour relating to the context class, implement another class implementing IContext.
	/// </remarks>
	public abstract class DictionaryContextBase<TContext> : IContext<TContext> where TContext : IContext<TContext> {
		// use a dictionary to store the last known state of a Region
		private readonly Dictionary<Region<TContext>, Vertex<TContext>> last = new Dictionary<Region<TContext>, Vertex<TContext>>();

		/// <summary>
		/// Indicates that the state machine context has been terminated.
		/// </summary>
		/// <remarks>A state machine is only deemed terminated if a transitions target is a Terminate PseudoState.</remarks>
		public Boolean IsTerminated { get; set; }

		// sets and gets the current state of a specified Region
		Vertex<TContext> IContext<TContext>.this[ Region<TContext> region ] {
			set {
				last[ region ] = value;
			}

			get {
				var value = default( Vertex<TContext> );

				last.TryGetValue( region, out value );

				return value;
			}
		}
	}
}