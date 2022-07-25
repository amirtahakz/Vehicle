$('#vehicle-request-not-confirmeds-tbl-driver').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Driver/VehicleRequest/GetVehicleRequestNotConfirmeds",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#vehicle-request-not-confirmeds-tbl-driver > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>
                              <td> ${valueOfElement.EmployeeId} </td>
                              <td> ${valueOfElement.VehicleId} </td>
                              <td> ${valueOfElement.Origin} </td>
                              <td> ${valueOfElement.Destination} </td>
                              <td> ${valueOfElement.Description} </td>
                              <td>
                                <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#updataUserModal" id="confirm-vehicle-request-driver-btn">تایید</button>
                              </td> 
                              <td>
                                <input type="hidden" id="vehicle-request-not-confirmed-id" value="${valueOfElement.Id}"/>
                              </td>
                           </tr>
                               `);
            });
        }
    });
});

$(document).on("click", '#confirm-vehicle-request-driver-btn', function () {
    var VehicleRequestId = document.getElementById("vehicle-request-not-confirmed-id").value;
    var DriverId = document.getElementById("driver-id-layout").value;
    var data0 = {
        VehicleRequestId: VehicleRequestId,
        DriverId: DriverId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Driver/VehicleRequest/ConfirmVehicleRequest",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('success')
        }
    });
});




$('#vehicle-request-confirmeds-by-driver-tbl-driver').ready(function () {
    var DriverId = document.getElementById("driver-id-layout").value;
    var data0 = {
        DriverId: DriverId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Driver/VehicleRequestConfirmed/GetVehicleRequestConfirmedsBySecretaryId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                console.log(valueOfElement)
                $('#vehicle-request-confirmeds-by-driver-tbl-driver > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>
                              <td> ${valueOfElement.VehicleRequestId} </td>
                           </tr>
                               `);
            });
        }
    });
});