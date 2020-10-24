/// <reference path="angular.min.js" />
var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {
    $http.get("http://localhost:51190/api/EmployeeModelsApi")
        .then(function (response) {
            alert(response.data);
            $scope.EmployeeData = response.data;
        })

    $scope.Save = function () {
        var id = $scope.EmpId;
        $http({
            method: "PUT",
            url: "http://localhost:51190/api/EmployeeModelsApi/"+id,
            data: {
                DeptId: $scope.DeptId,
                EmpName: $scope.EmpName,
                EmpSalary: $scope.EmpSalary,
                EmpId:id
            }
        }).then(function mySuccess(response) {
            alert('Updated Successfully');
        }), function myError(response) {
            alert('Not Inserted');
        }
    }

    $scope.Edit = function (x) {
        var a = x;
        $scope.EmpId=x.EmpId;
        $scope.EmpName=x.EmpName;
        $scope.EmpSalary = x.EmpSalary;
    }
})