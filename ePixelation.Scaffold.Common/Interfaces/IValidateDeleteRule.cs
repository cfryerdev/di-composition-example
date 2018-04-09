using ePixelation.Scaffold.Common.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ePixelation.Scaffold.Common.Interfaces
{
	public interface IValidateDeleteRule<in TModel> where TModel : BaseEntityModel
	{
		List<Exception> Validate(IDbConnection connection, TModel model);
	}
}
