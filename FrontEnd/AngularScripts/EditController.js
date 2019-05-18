
Controller.controller('EditController', ['$scope', '$http',  function ($scope, $http) {

 
  $scope.save = function () {
    var url = '/api/Contacts/PutContact/2';
    var data1 = { Id: $scope.Id, FirstName: $scope.fname, LastName: $scope.lname, Address: $scope.addr, City: $scope.city, ZipCode: $scope.zip, PhoneNum: $scope.phone };

    $http({
      method: 'PUT',
      url: url,
      data: data1


    }).then(function (response) {
      alert("Contact edited");

    }, function (error) {
      alert("error");

    });
  };
 
 
 






  





}]);
