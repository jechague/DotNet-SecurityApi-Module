﻿using NUnit.Framework;
using SecurityAPICommons.Commons;
using SecurityAPICommons.Utils;
using System;
using System.IO;
using System.Reflection;

namespace SecurityAPITest.SecurityAPICommons.commons
{
    public class SecurityAPITestObject
    {
		public string TestContextParameter(string key) {
			return TestContext.Parameters[key];
		}

		static string GetStartupDirectory()
		{
			string dir = Assembly.GetCallingAssembly().GetName().CodeBase;
			Uri uri = new Uri(dir);
			return Path.GetDirectoryName(uri.LocalPath);
		}

		protected static string BASE_PATH = GetStartupDirectory() + "\\";
		public void True(bool result, SecurityAPIObject obj)
		{
			Assert.IsTrue(result);
			Assert.IsFalse(obj.HasError());
		}

		public void False(bool result, SecurityAPIObject obj)
		{
		
			Assert.IsFalse(result);
			Assert.IsTrue(obj.HasError());
		}

		public void Equals(string expected, string obtained, SecurityAPIObject obj)
		{
			Assert.IsTrue(SecurityUtils.compareStrings(expected, obtained) && !obj.HasError());
		}
	}
}