﻿/* State v5 finite state machine library
 * http://www.steelbreeze.net/state.cs
 * Copyright (c) 2014-5 Steelbreeze Limited
 * Licensed under MIT and GPL v3 licences
 */
using System;
using System.Diagnostics;

namespace Steelbreeze.Behavior.StateMachines.Tests.History {
	public class Shallow {
		public static void Test () {
			var model = new StateMachine<StateMachineInstance> ("model");

			var initial = model.CreatePseudoState ("initial", PseudoStateKind.Initial);
			var shallow = model.CreateState ("shallow");
			var deep = model.CreateState ("deep");
			var final = model.CreateFinalState ("final");

			var s1 = shallow.CreateState ("s1");
			var s2 = shallow.CreateState ("s2");

			initial.To (shallow);
			shallow.CreatePseudoState ("shallow", PseudoStateKind.ShallowHistory).To (s1);
			s1.To (s2).When<String> (c => c == "move");
			shallow.To (deep).When<String> (c => c == "go deep");
			deep.To (shallow).When<String> (c => c == "go shallow");
			s2.To (final).When<String> (c => c == "end");

			var instance = new StateMachineInstance ("history");

			model.Initialise (instance);

			Trace.Assert (model.Evaluate ("move", instance));
			Trace.Assert (model.Evaluate ("go deep", instance));
			Trace.Assert (model.Evaluate ("go shallow", instance));
			Trace.Assert (!model.Evaluate ("go shallow", instance));
			Trace.Assert (model.Evaluate ("end", instance));
			Trace.Assert (model.IsComplete (instance));
		}
	}
}