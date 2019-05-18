var Controller = angular.module('AppController', []);




Controller.controller('Controller', ['$scope', '$http',  function ($scope, $http) {
 
 $http.get('/api/Contacts/GetContact').then(function (response) {
    $scope.contacts = response.data;
   


  }
  );


  $scope.add = function (index) {
    var url = '/api/Contacts/PostContact';
    var data1 = { Id:index+1,FirstName: $scope.fname, LastName: $scope.lname, Address: $scope.addr, City: $scope.city, ZipCode: $scope.zip, PhoneNum: $scope.phone };

    $http({
      method: 'POST',
      url: url,
      data: data1,
      contentType: "application/x-www-form-urlencoded"
    }).then(function successCallback(success) {
      alert("Contact Added");
      $route.reload();
    }, function errorCallback(error) {
      alert(error);

    });
  };

  $scope.delete = function (dataModel) {
    var id = dataModel.Id;
    var uri = '/api/Contacts/DeleteContact/'+id;
   

    $http.delete(uri).then(function (response) {
      
      alert('Contact successfuly deleted');
      }, function (rejection) {
        alert(rejection);
      });
  };

  





}])













