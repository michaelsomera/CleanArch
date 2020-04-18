using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMembershipTypeService _membershipTypeService;

        public CustomersController(ICustomerService customerService, IMembershipTypeService membershipTypeService)
        {
            _customerService = customerService;
            _membershipTypeService = membershipTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult ManageCustomer(int id)
        {
            var customer = _customerService.GetById(id);

            if(customer == null)
            {
                customer = new Customer();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _membershipTypeService.Get().ToList()
            };
            return PartialView("Partials/_ManageCustomerPartial", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageCustomer(Customer customer)
        {
            object msg;
            var isEdit = customer.Id != 0;
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new CustomerFormViewModel
                    {
                        Customer = customer,
                        MembershipTypes = _membershipTypeService.Get().ToList()
                    };

                    return PartialView("Partials/_ManageCustomerPartial", viewModel);
                }
                if (isEdit)
                {
                    var customerInDb = _customerService.GetById(customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.BirthDate = customer.BirthDate;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
                }
                else
                {
                    _customerService.Insert(customer);
                }

                _customerService.Save();
                msg = new
                {
                    IsSuccess = true,
                    Message = "Customer record successfully " + (isEdit ? "updated" : "created")
                };
                return Json(msg);
            }
            catch (Exception ex)
            {
                msg = new
                {
                    IsSuccess = false,
                    Message = ex
                };
                return Json(msg);
            }
        }
    }
}