$('#confirmations-not-confirmed-tbl-driver').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Driver/Confirmation/GetConfirmationsNotConfirmedByDriver",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#confirmations-not-confirmed-tbl-driver > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>
                              <th scope="row"> ${indexInArray} </th>
                              <td> ${valueOfElement.VehicleRequest.Origin} </td>
                              <td> ${valueOfElement.VehicleRequest.Destination} </td>
                              <td> ${valueOfElement.VehicleRequest.Description} </td>
                              <td> ${valueOfElement.VehicleRequest.Vehicle.Name} </td>
                              <td>
                                <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#updataUserModal" id="confirm-confirmation-btn">تایید</button>
                              </td>
                              <td>
                                <input type="hidden" id="confirmation-id" value="${valueOfElement.Id}"/>
                              </td>
                           </tr>
                               `);
            });
        }
    });
});

$(document).on("click", '#confirm-confirmation-btn', function () {
    var ConfirmationId = document.getElementById("confirmation-id").value;
    var DriverId = document.getElementById("driver-id-layout").value;
    var data0 = {
        ConfirmationId: ConfirmationId,
        DriverId: DriverId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Driver/Confirmation/ConfirmConfirmation",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('success')
        }
    });
});




$('#confirmation-confirmed-by-driver-tbl-driver').ready(function () {
    var DriverId = document.getElementById("driver-id-layout").value;
    var data0 = {
        DriverId: DriverId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Driver/ConfirmationsUsersWhoConfirmed/GetConfirmationsConfirmedByDriver",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                console.log(valueOfElement)
                $('#confirmation-confirmed-by-driver-tbl-driver > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>                       
                              <td> ${valueOfElement.VehicleRequest.Origin} </td>
                              <td> ${valueOfElement.VehicleRequest.Destination} </td>
                              <td> ${valueOfElement.VehicleRequest.Description} </td>
                              <td> ${valueOfElement.VehicleRequest.Vehicle.Name} </td>
                           </tr>
                               `);
            });
        }
    });
});