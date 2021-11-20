// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function makeAjaxRequest(requestType, domainName, contollerName, actionName, dataType, callback) {
    return $.ajax({
        type: requestType,
        url: domainName + "\\" + "api" + "\\" + contollerName + "\\" + actionName,
        dataType: dataType,
        success: callback
    });
}

$(document).ready(function () {
    $('#addCompetitionModal').on('shown.bs.modal', function () {
        makeAjaxRequest('get', 'https://localhost:44318', 'Competition', 'GetAllCompetitionTypes', 'json', competitionReturnFunction)
    })

    function competitionReturnFunction(returnValue) {
        $('#competitionTypeSelect')
            .empty()
            .append($('<option>', { value: returnValue[0].Id })
                .text(returnValue[0].Name));
    }

    makeAjaxRequest('get', 'https://localhost:44318', 'UserGroup', 'GetUserGroupRoles', 'json', userGroupRolesReturnFunction)

    function userGroupRolesReturnFunction(returnValue) {
        if (!returnValue.includes("AddCompetition"))
            $('#addCompetitionButton').hide();
        if (!returnValue.includes("DeleteCompetition"))
            $('#deleteCompetitionButton').hide();
    }
});