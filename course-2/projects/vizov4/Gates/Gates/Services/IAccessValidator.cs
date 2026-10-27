using System;
using Gates.Models;
namespace Gates.Services
{
	public interface IAccessValidator
	{
		ValidResult Validate(string code);
	}
}

