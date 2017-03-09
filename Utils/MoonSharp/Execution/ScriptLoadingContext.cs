﻿using BareKit.Lua.Interpreter.Debugging;
using BareKit.Lua.Interpreter.Tree;

namespace BareKit.Lua.Interpreter.Execution
{
	class ScriptLoadingContext
	{
		public Script Script { get; private set; }
		public BuildTimeScope Scope { get; set; }
		public SourceCode Source { get; set; }
		public bool Anonymous { get; set; }
		public bool IsDynamicExpression { get; set; }
		public Lexer Lexer { get; set; }

		public ScriptLoadingContext(Script s)
		{
			Script = s;
		}

	}
}
