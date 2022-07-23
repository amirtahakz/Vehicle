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