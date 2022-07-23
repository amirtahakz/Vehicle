$('#users-tbl-manager').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Manager/User/GetUsers",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#users-tbl-manager > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.Email} </td> 
                      <td> ${valueOfElement.PhoneNumber} </td>
                     <td>
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#updataUserModal" id="update-user-roles-btn">ویرایش نقش های کاربر</button>
                     </td>
                     <td>
                       <input type="hidden" id="user-id-2" value="${valueOfElement.Id}"/>
                     </td>
                   </tr>
                       `);
            });
        }
    });
});


$(document).on("click", '#update-user-roles-btn', function () {
    var userId = document.getElementById("user-id-2").value;
    var data0 = {
        Id : userId
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Manager/User/GetUserRolesById",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#user-roles-tbl-manager > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td id="role-id"> ${valueOfElement.RoleId} </td> 
                     <td>
                        <button type ="button" class="btn btn-danger" id="delete-user-role"> حذف</button>
                     </td>
                   </tr>
                       `);
            });
        }
    });
});

$(document).on("click", '#delete-user-role', function () {
    var userId = document.getElementById("user-id-2").value;
    var roleId = document.getElementById("role-id").innerHTML;
    var data0 = {
        UserId: userId,
        RoleId: roleId,
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Manager/User/DeleteUserRole",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data : JSON.stringify(data0),
        success: function (response) {
            alert('succes')
        }
    });
});


$('#roles-select-list').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Manager/Role/GetRoles",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#roles-select-list').append(`
                   <option value="${valueOfElement.Id}">${valueOfElement.Name}</option>
                       `);
            });
        }
    });
});

$(document).on("click", '#add-user-role-btn', function () {
    var userId = document.getElementById("user-id-2").value;
    var roleName = $('#roles-select-list').find(":selected").text();
    var data0 = {
        UserId: userId,
        RoleName: roleName,
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Manager/User/AddUserRole",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('succes')
        }
    });
});

$('#users-not-confirmed-tbl-manager2').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Manager/User/GetUsersNotConfirmed",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#users-not-confirmed-tbl-manager2 > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.Email} </td> 
                      <td> ${valueOfElement.PhoneNumber} </td>
                     <td>
                        <button class="btn btn-success confirm-user-btn"> تایید</button>
                     </td>
                     <td>
                       <input type="hidden" id="user_id" value="${valueOfElement.Id}"/>
                     </td>
                   </tr>
                       `);
            });
        }
    });
});

$(document).on("click", '#users-not-confirmed-tbl-manager2 .confirm-user-btn', function () {
    var userId = $('#user_id').val();
    var data0 = {
        Id: userId.toString()
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Manager/User/ConfirmUser",
        data: JSON.stringify(data0),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert('succes')
        }
    });
});


$('#roles-tbl-manager').ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/Manager/Role/GetRoles",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {
                $('#roles-tbl-manager > tbody:last-child').append(`
                   <tr>
                      <th scope="row"> ${indexInArray} </th>
                      <td> ${valueOfElement.Id} </td> 
                      <td> ${valueOfElement.Name} </td>
                   </tr>
                       `);
            });
        }
    });
});

$(document).on("click", '#add-role-btn', function () {
    var roleName = document.getElementById("add-role-txtbox").value;
    var data0 = {
        Name: roleName,
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:44305/Manager/Role/AddRole",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data0),
        success: function (response) {
            alert('succes')
        }
    });
});




















