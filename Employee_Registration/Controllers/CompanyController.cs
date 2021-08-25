using BL.Managers.Interfaces;
using Employee_Registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Registration.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyManager _companyManager;
        private readonly IEmployeeManager _employeeManager;

        public CompanyController(
            ILogger<CompanyController> logger,
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
                var companyViewModel = new CompanyViewModel();

                var companies = await _companyManager.GetAllCompaniesAsync(token);
                var companyViewModels = companyViewModel.ToCompanyViewModels(companies);

                return View(companyViewModels);
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
                if (id.HasValue)
                {
                    var companyViewModels = new CompanyViewModel();

                    var company = await _companyManager.GetCompanyByIdAsync(id.Value, token);
                    var companyViewModel = companyViewModels.ToCompanyViewModel(company);

                    return View("edit", companyViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Edit));
            }

            return View("edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel company, CancellationToken token)
        {
            try
            {
                if (company.Id == 0)
                {
                    await _companyManager.AddCompanyAsync(company.ToCompany(), token);

                    return RedirectToAction("Index");
                }
                else
                {
                    await _companyManager.UpdateCompanyAsync(company.ToCompany(), token);

                    return RedirectToAction("Index");
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
                    await _companyManager.DeleteCompanyAsync(id.Value, token);

                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));
            }

            return NotFound();
        }
    }
}
