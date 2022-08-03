$('#confirmations-tbl-employee').ready(function () {
    var EmployeeId = document.getElementById("employee-id-layout").value;
    var data0 = {
        EmployeeId: EmployeeId
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Employee/Confirmation/GetConfirmations",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#confirmations-tbl-employee > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.VehicleRequest.Origin} </td>
                      <td> ${valueOfElement.VehicleRequest.Destination} </td>
                      <td> ${valueOfElement.VehicleRequest.Description} </td>
                      <td> ${valueOfElement.VehicleRequest.Vehicle.Name} </td>
                      <td> ${valueOfElement.FinalIsConfirmed} </td>
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




