const api = "https://localhost:44334/api/Tours";
const app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
  $scope.search = "";
  $scope.GetList = function () {
    $http.get(api + `?search=${$scope.search}`).then((res) => {
      $scope.tours = res.data;
    });
  };
  $scope.GetList();
  $scope.save = function()
  {
    if ($scope.id)
    {
      $scope.edit();
    }
    else
    {
      $scope.add();
    }
  }
  $scope.add = function()
  {
    $http.post(api, $scope.tour).then(res =>{ 
      $scope.GetList();
    })
  }
  $scope.edit = function()
  {
    $http.put(api + "/" + $scope.id, $scope.tour).then(res =>{ 
      $scope.GetList();
    })
  }
  $scope.delete = function(id)
  {
    $http.delete(api + "/" + id).then(res =>{ 
      $scope.GetList();
    })
  }
  $scope.showEdit = function(t)
  {
    $scope.id = t.id;
    $scope.tour = {...t};
    delete $scope.tour.booking;
  }
  $scope.showAddNew = function()
  {
    $scope.id = undefined;
    $scope.tour = {};
  }
  $scope.searchSubmit = function()
  {
    $scope.GetList();
  }
});
