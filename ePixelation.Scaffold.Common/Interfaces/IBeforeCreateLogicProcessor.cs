using ePixelation.Scaffold.Common.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ePixelation.Scaffold.Common.Interfaces
{
	public interface IBeforeCreateLogicProcessor<in TModel> where TModel : BaseEntityModel
	{
		void Process(IDbConnection context, TModel newModel);
	}
}
