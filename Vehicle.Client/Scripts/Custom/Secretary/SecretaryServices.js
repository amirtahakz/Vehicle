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

$('#vehicle-request-not-confirmeds-tbl-secretary').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Secretary/VehicleRequest/GetVehicleRequestNotConfirmeds",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#vehicle-request-not-confirmeds-tbl-secretary > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>
                              <td> ${valueOfElement.EmployeeId} </td>
                              <td> ${valueOfElement.VehicleId} </td>
                              <td> ${valueOfElement.Origin} </td>
                              <td> ${valueOfElement.Destination} </td>
                              <td> ${valueOfElement.Description} </td>
                              <td>
                                <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#updataUserModal" id="confirm-vehicle-request-btn">تایید</button>
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

$(document).on("click", '#confirm-vehicle-request-btn', function () {
    var VehicleRequestId = document.getElementById("vehicle-request-not-confirmed-id").value;
    var SecretaryId = document.getElementById("secretary-id-layout").value;
    var data0 = {
        VehicleRequestId: VehicleRequestId,
        SecretaryId: SecretaryId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Secretary/VehicleRequest/ConfirmVehicleRequest",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('success')
        }
    });
});




$('#vehicle-request-confirmeds-by-secretary-tbl-secretary').ready(function () {
    var SecretaryId = document.getElementById("secretary-id-layout").value;
    var data0 = {
        SecretaryId: SecretaryId,
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Secretary/VehicleRequestConfirmed/GetVehicleRequestConfirmedsBySecretaryId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                console.log(valueOfElement)
                $('#vehicle-request-confirmeds-by-secretary-tbl-secretary > tbody:last-child').append(`
                           <tr>
                              <th scope="row"> ${indexInArray} </th>
                              <td> ${valueOfElement.VehicleRequestId} </td>
                           </tr>
                               `);
            });
        }
    });
});