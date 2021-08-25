using BL.Managers.Interfaces;
using BL.Models;
using DAL.Models;
using Employee_Registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Registration.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeManager _employeeManager;
        private readonly ICompanyManager _companyManager;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IEmployeeManager employeeManager,
            ICompanyManager companyManager)
        {
            _logger = logger;
            _employeeManager = employeeManager;
            _companyManager = companyManager;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            try
            {
                var employeeViewModel = new EmployeeViewModel();

                var employees = await _employeeManager.GetAllEmployeesAsync(token);
                var employeeViewModels = employeeViewModel.ToEmployeeViewModels(employees);

                return View(employeeViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id, CancellationToken token)
        {
            try
            {
                var companies = await _companyManager.GetAllCompaniesAsync(token);
                var selectedListCompany = GetCompaniesSelectedList(companies, token);
                var selectedListPosition = new SelectList( Position.Positions);

                if (id.HasValue)
                {
                    var employeeViewModels = new EmployeeViewModel();

                    var employee = await _employeeManager.GetEmployeeByIdAsync(id.Value, token);
                    var employeeViewModel = employeeViewModels.ToEmployeeViewModel(employee);

                    SelectadListCompanies(selectedListCompany, employee);
                    SelectadListEmployees(selectedListPosition, employee);

                    return View("edit", employeeViewModel);
                }
                else
                {
                    ViewBag.Position = selectedListPosition;
                    ViewBag.Company = selectedListCompany;

                    return View("edit");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Edit));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee, CancellationToken token)
        {
            try
            {
                if (employee.Id == 0)
                {
                    await _employeeManager.AddEmployeeAsync(employee.ToEmployee(), token);

                    return Redirect("Index");
                }
                else
                {
                    await _employeeManager.UpdateEmployeeAsync(employee.ToEmployee(), token);

                    return RedirectToAction("Index", "Employee");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Edit));
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id, CancellationToken token)
        {
            try
            {
                if (id.HasValue)
                {
                    await _employeeManager.DeleteEmployeeAsync(id.Value, token);

                    return RedirectToAction("Index", "Employee");
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));
            }

            return NotFound();
        }

        private SelectList GetCompaniesSelectedList(IEnumerable<Company> companies, CancellationToken token)
        {
            var companyViewModel = new CompanyViewModel();
            var items = companyViewModel.ToCompanyViewModels(companies);

            return new SelectList(items, "Id", "Name");
        }

        private void SelectadListCompanies(SelectList selectedListCompany, Employee employee)
        {

            foreach (var item in selectedListCompany)
            {
                if (item.Value == employee.CompanyId.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.Company = selectedListCompany;
        }

        private void SelectadListEmployees(SelectList selectedListPosition, Employee employee)
        {
            foreach (var item in selectedListPosition)
            {
                if (item.Value == employee.Position)
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.Position = selectedListPosition;
        }
    }
}
