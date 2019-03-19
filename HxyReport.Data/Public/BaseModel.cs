using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HxyReport.Data
{
	public partial class BaseModel : IDisposable
	{
		#region variables
		private Hashtable _Items;
		#endregion

		#region properties
		public object this[string name]
		{
			get
			{
				if (_Items == null)
					return null;

				return _Items[name];
			}
			set
			{
				if (_Items == null)
					_Items = new Hashtable();
				_Items[name] = value;
			}
		}
		#endregion

		#region public methods
		public void Dispose()
		{
		}
		#endregion
	}
}
