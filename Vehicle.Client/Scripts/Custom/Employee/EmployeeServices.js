$('#vehicle-requests-tbl-employee').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Employee/VehicleRequest/GetVehicleRequests",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#vehicle-requests-tbl-employee > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.EmployeeId} </td>
                      <td> ${valueOfElement.VehicleId} </td>
                      <td> ${valueOfElement.Origin} </td>
                      <td> ${valueOfElement.Destination} </td>
                      <td> ${valueOfElement.Description} </td>
                   </tr>
                       `);
            });
        }
    });
});

$(document).on("click", '#add-vehicle-request-btn', function () {
    var EmployeeId = document.getElementById("employee-id-layout").value;
    var VehicleId = $('#vehicles-select-list').find(":selected").val();

    var Origin = document.getElementById("origin").value;
    var Destination = document.getElementById("destination").value;
    var Description = document.getElementById("description").value;
    var data0 = {
        EmployeeId: EmployeeId,
        VehicleId: VehicleId,
        Origin: Origin,
        Destination: Destination,
        Description: Description,
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Employee/VehicleRequest/AddVehicleRequest",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('succes')
        }
    });
});

$('#vehicles-select-list').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Employee/Vehicle/GetVehicles",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#vehicles-select-list').append(`
                   <option value="${valueOfElement.Id}">${valueOfElement.Name}</option>
                       `);
            });
        }
    });
});



$('#vehicle-request-confirmeds-tbl-employee').ready(function () {
    var EmployeeId = document.getElementById("employee-id-layout").value;
    var data0 = {
        EmployeeId: EmployeeId,
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Employee/VehicleRequest/GetVehicleRequestConfirmedsByEmplyeeId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#vehicle-request-confirmeds-tbl-employee > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.VehicleId} </td>
                      <td> ${valueOfElement.Origin} </td>
                      <td> ${valueOfElement.Destination} </td>
                      <td> ${valueOfElement.Description} </td>
                   </tr>
                       `);
            });
        }
    });
});


