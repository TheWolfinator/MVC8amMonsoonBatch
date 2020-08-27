﻿using MVC8amMonsoonBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8amMonsoonBatch.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public string Welcome() {
            return "Welcome to New World of MVC";
        }


        public string GetId(int ? id)
        {
            return "My Id is " + id;
        }

        public string GetName(string Name)
        {
            return "My Name is " + Name;
        }

        public ActionResult  Index()
        {
            return View("~/Views/Default/MyFirstMethod.cshtml");
        }

        public ActionResult GetData() {

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Suraj";
            obj.EmpSalary = 27000;

            ViewBag.Empinfo = obj;

            return View();
        }

        public ActionResult GetMulTipleEmpData()
        {
            List<EmployeeModel> listobj = new List<EmployeeModel>();
            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Suraj";
            obj.EmpSalary = 27000;


            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Abhisek";
            obj1.EmpSalary = 5699;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Rambabu";
            obj2.EmpSalary = 6540;

            listobj.Add(obj);
            listobj.Add(obj1);
            listobj.Add(obj2);

            
            ViewBag.Empinfo = listobj;

            return View();
        }

        public ViewResult GetDataAnotherway() {

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Suraj";
            obj.EmpSalary = 27000;

             

            return View(obj);
        }

        public ActionResult GetMulTipleEmpDatawithViewModel()
        {
            List<EmployeeModel> listobj = new List<EmployeeModel>();
            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Suraj";
            obj.EmpSalary = 27000;


            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Abhisek";
            obj1.EmpSalary = 5699;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Rambabu";
            obj2.EmpSalary = 6540;

            listobj.Add(obj);
            listobj.Add(obj1);
            listobj.Add(obj2);

            return View(listobj );
        }
        public ActionResult CustomizeModel() {

            EmployeeModel empobj = new EmployeeModel();
            empobj.EmpId = 1;
            empobj.EmpName = "Anna";
            empobj.EmpSalary = 27000;

            DepartmentModel deptobj = new  DepartmentModel();
            deptobj.DeptId = 1211;
            deptobj.DeptName = "Develpoment";

            EmpDeptDetail empdepobj = new EmpDeptDetail();
            empdepobj.emp = empobj;
            empdepobj.dep = deptobj;

            return View(empdepobj);
        }

        public ActionResult CustomizeModelExample2()
        {
            List<EmployeeModel> listobj = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Suraj";
            obj.EmpSalary = 27000;


            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Abhisek";
            obj1.EmpSalary = 5699;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Rambabu";
            obj2.EmpSalary = 6540;

            listobj.Add(obj);
            listobj.Add(obj1);
            listobj.Add(obj2);

            DepartmentModel deptobj = new DepartmentModel();
            deptobj.DeptId = 1211;
            deptobj.DeptName = "Develpoment";

            EmpDeptDetail empdepobj = new EmpDeptDetail();
            empdepobj.listemp = listobj;
            empdepobj.dep = deptobj;


            return View(empdepobj);
        }

        public ViewResult GetView() {

            EmployeeModel empobj = new EmployeeModel();
            empobj.EmpId = 1;
            empobj.EmpName = "Anna";
            empobj.EmpSalary = 27000;

            DepartmentModel deptobj = new DepartmentModel();
            deptobj.DeptId = 1211;
            deptobj.DeptName = "Develpoment";

            EmpDeptDetail empdepobj = new EmpDeptDetail();
            empdepobj.emp = empobj;
            empdepobj.dep = deptobj;

            return View("CustomizeModel", empdepobj);
        }

        public RedirectResult RedirectToUrl() {
            return Redirect("http://www.yahoo.com");
        }
        public RedirectResult Redirect2ToUrl()
        {
            return Redirect("~/staff/GetView");
        }
    }
}