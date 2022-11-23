using System;
using EmployeeApp.Models;
using EmployeeApp.ModelsVM;

namespace EmployeeApp.Interfaces;

	public interface IEmployeeRepository
	{
		bool AddEmployee(EmployeeDetailVM edvm);
		//bool CreatePDFReport(EmployeeDetailVM edvm);
	}


