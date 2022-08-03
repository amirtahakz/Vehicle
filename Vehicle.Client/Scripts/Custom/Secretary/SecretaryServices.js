$('#vehicle-tbl-secretary').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Secretary/Vehicle/GetVehicles",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#vehicle-tbl-secretary > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.Name} </td>
                      <td> ${valueOfElement.CarTag} </td>
                      <td> ${valueOfElement.Color} </td>
                   </tr>
                       `);
            });
        }
    });
});


$(document).on("click", '#add-vehicle-btn', function () {
    var CarName = document.getElementById("car-name").value;
    var CarTag = document.getElementById("car-tag").value;
    var CarColor = document.getElementById("car-color").value;
    var data0 = {
        Name: CarName,
        CarTag: CarTag,
        Color: CarColor,
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Secretary/Vehicle/AddVehicle",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('succes')
        }
    });
});

$('#confirmations-not-confirmed-tbl-secretary').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Secretary/Confirmation/GetConfirmationsNotConfirmedBySecretary",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#confirmations-not-confirmed-tbl-secretary > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>
                              <td> ${valueOfElement.VehicleRequest.Origin} </td>
                              <td> ${valueOfElement.VehicleRequest.Destination} </td>
                              <td> ${valueOfElement.VehicleRequest.Description} </td>
                              <td> ${valueOfElement.VehicleRequest.Vehicle.Name} </td>
                              <td>
                                <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#updataUserModal" id="confirm-first-step-confirmation-btn">تایید</button>
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

$(document).on("click", '#confirm-first-step-confirmation-btn', function () {
    var ConfirmationId = document.getElementById("confirmation-id").value;
    var SecretaryId = document.getElementById("secretary-id-layout").value;
    var data0 = {
        ConfirmationId: ConfirmationId,
        SecretaryId: SecretaryId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Secretary/Confirmation/ConfirmConfirmation",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('success')
        }
    });
});




$('#confirmation-confirmed-by-secretary-tbl-secretary').ready(function () {
    var SecretaryId = document.getElementById("secretary-id-layout").value;
    var data0 = {
        SecretaryId: SecretaryId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Secretary/ConfirmationsUsersWhoConfirmed/GetConfirmationsConfirmedBySecretary",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                console.log(valueOfElement)
                $('#confirmation-confirmed-by-secretary-tbl-secretary > tbody:last-child').append(`
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