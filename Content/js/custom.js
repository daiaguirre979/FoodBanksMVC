//====================================
//Food Banks
//====================================
$(document).ready(function () {
    SetupFoodBankButtons();
    //SetupFoodBankValidation();
});

function NotifyFoodBankError() {
    $('#div_NewFoodBankErrorAlert').show('fast');
}

function SetupFoodBankButtons() {

    $('.FoodBank-Edit').click(function (e) {
        var id = $(this).attr('data-id');
        editingRow = "#row_" + id;

        $.ajax({
            url: '/FoodBanks/GetFoodBankForEdit/',
            data: { id: id },
            error: function (xhr, ajaxOptions, thrownError) {
                NotifyFoodBankError();
                editingRow = "";
            },
            success: function (data) {
                $("#FoodBankEditModalBody").html(data);
                $('#FoodBankEditModal').modal('show');
                SetupFoodBankValidation();
            }
        });
    });
    $('.FoodBank-Delete').click(function (e) {
        var id = $(this).attr('data-id');
        var title = $(this).attr('data-title');
        editingRow = "#row_" + id;
        
        $('#id').val(id);
        $('#FoodBankDeleteModalTitle').html(title);
        $('#FoodBankDeleteModal').modal('show');
    });

}

function PageFoodBanks( offSet, limit) {
    $.ajax({
        url: '/FoodBanks/PageFoodBanks/',
        data: { offSet: offSet, limit: limit },
        error: function (xhr, ajaxOptions, thrownError) {
            NotifyFoodBankError();
        },
        success: function (data) {
            $("#div_FoodBanks").html(data);
            SetupFoodBankButtons();
        }
    });
}

function NewFoodBankOnSuccess() {
    $('#div_NewFoodBankErrorAlert').hide();
    $('#FoodBankModal').modal('hide');
    SetupFoodBankButtons();
}

function NewFoodBankOnFailure() {
    NotifyFoodBankError();
}

function NewFoodBankOnComplete() {
    $('#btnCreateNewFoodBank').html('Create');
    $('#btnCancelNewFoodBank').show('fast');
}

function NewFoodBankOnBegin() {
    $('#btnCreateNewFoodBank').html('Creating...');
    $('#btnCancelNewFoodBank').hide('fast');
    return true;
}

function EditFoodBankOnSuccess(data) {
    $('#div_NewFoodBankErrorAlert').hide();
    $('#FoodBankEditModal').modal('hide');
    
    $(editingRow).html(data).animate({
        backgroundColor: "#D3D3D3",
        //color: "#fff",
    }, 1000).delay(1000).animate({
        backgroundColor: "#fff",
        //color: "#000",
    }, 1000)
        ;//replace current row with new data.

    editingRow = "";
    SetupFoodBankButtons();
}

function EditFoodBankOnFailure() {
    NotifyFoodBankError();
}

function EditFoodBankOnComplete() {
    $('#btnSaveNewFoodBank').html('Save');
    $('#btnCancelSaveFoodBank').show('fast');
}

function EditFoodBankOnBegin() {
    $('#btnSaveNewFoodBank').html('Saving...');
    $('#btnCancelSaveFoodBank').hide('fast');
    return true;
}

function DeleteFoodBankOnSuccess(data) {
    $('#div_NewFoodBankErrorAlert').hide();
    $('#FoodBankDeleteModal').modal('hide');

    if(data == "True")
    {
        $(editingRow).delay(1000).slideUp('slow');//remove deleted row from view.
    }
    
    editingRow = "";
    SetupFoodBankButtons();
}

function DeleteFoodBankOnFailure() {
    NotifyFoodBankError();
}

function DeleteFoodBankOnComplete() {
    $('#btnDeleteFoodBank').html('Yes');
    $('#btnCancelDeleteFoodBank').show('fast');
}

function DeleteFoodBankOnBegin() {
    $('#btnDeleteFoodBank').html('Deleting...');
    $('#btnCancelDeleteFoodBank').hide('fast');
    return true;
}

//====================================
//Volunteers
//====================================
$(document).ready(function () {
    SetupVolunteerButtons();
});

function SetupVolunteerButtons()
{
    $(".datepicker").datepicker({
        dateFormat: 'mm/dd/yy'
    });

    $('.Volunteer-Edit').click(function (e) {
        var id = $(this).attr('data-id');
        editingRow = "#row_" + id;

        $.ajax({
            url: '/Volunteers/GetVolunteerForEdit/',
            data: { id: id },
            error: function (xhr, ajaxOptions, thrownError) {
                NotifyVolunteerError();
                editingRow = "";
            },
            success: function (data) {
                $("#VolunteerEditModalBody").html(data);
                $('#VolunteerEditModal').modal('show');
                SetupVolunteerButtons();
            }
        });
    });
    $('.Volunteer-Delete').click(function (e) {
        var id = $(this).attr('data-id');
        var title = $(this).attr('data-title');
        editingRow = "#row_" + id;

        $('#id').val(id);
        $('#VolunteerDeleteModalTitle').html(title);
        $('#VolunteerDeleteModal').modal('show');
    });

    //$('#idTourDateDetails').datepicker({
    //    dateFormat: 'dd-mm-yy',
    //    minDate: '+5d',
    //    changeMonth: true,
    //    changeYear: true,
    //    altField: "#idTourDateDetailsHidden",
    //    altFormat: "yy-mm-dd"
    //});

}
 
function PageVolunteers(offSet, limit) {
    $.ajax({
        url: '/Volunteers/PageVolunteers/',
        data: { offSet: offSet, limit: limit },
        error: function (xhr, ajaxOptions, thrownError) {
            NotifyVolunteerError();
        },
        success: function (data) {
            $("#div_Volunteers").html(data);
            SetupVolunteerButtons();
        }
    });
}

function NotifyVolunteerError() {
    $('#div_CreateVolunteerErrorAlert').show('fast');
}

function NewVolunteerOnSuccess() {
    $('#div_NewVolunteerErrorAlert').hide();
    $('#VolunteerModal').modal('hide');
    SetupFoodBankButtons();
}

function NewVolunteerOnFailure() {
    NotifyVolunteerError();
}

function NewVolunteerOnComplete() {
    $('#btnCreateNewVolunteer').html('Create');
    $('#btnCancelNewVolunteer').show('fast');
}

function NewVolunteerOnBegin() {
    $('#btnCreateNewVolunteer').html('Creating...');
    $('#btnCancelNewVolunteer').hide('fast');
    return true;
}

function EditVolunteerOnSuccess(data) {
    $('#div_NewVolunteerErrorAlert').hide();
    $('#VolunteerEditModal').modal('hide');

    $(editingRow).html(data).animate({
        backgroundColor: "#D3D3D3",
        //color: "#fff",
    }, 1000).delay(1000).animate({
        backgroundColor: "#fff",
        //color: "#000",
    }, 1000)
    ;//replace current row with new data.

    editingRow = "";
    SetupVolunteerButtons();
}

function EditVolunteerOnFailure() {
    NotifyVolunteerError();
}

function EditVolunteerOnComplete() {
    $('#btnSaveNewVolunteer').html('Save');
    $('#btnCancelSaveVolunteer').show('fast');
}

function EditVolunteerOnBegin() {
    $('#btnSaveNewVolunteer').html('Saving...');
    $('#btnCancelSaveVolunteer').hide('fast');
    return true;
}

function DeleteVolunteerOnSuccess(data) {
    $('#div_NewVolunteerErrorAlert').hide();
    $('#VolunteerDeleteModal').modal('hide');

    if (data == "True") {
        $(editingRow).delay(1000).slideUp('slow');//remove deleted row from view.
    }

    editingRow = "";
    SetupVolunteerButtons();
}

function DeleteVolunteerOnFailure() {
    NotifyVolunteerError();
}

function DeleteVolunteerOnComplete() {
    $('#btnDeleteVolunteer').html('Yes');
    $('#btnCancelDeleteVolunteer').show('fast');
}

function DeleteVolunteerOnBegin() {
    $('#btnDeleteVolunteer').html('Deleting...');
    $('#btnCancelDeleteVolunteer').hide('fast');
    return true;
}

//====================================
//Donations
//====================================
$(document).ready(function () {
    SetupDonationButtons();
});

function SetupDonationButtons() {
   
    $('.Donation-Edit').click(function (e) {
        var id = $(this).attr('data-id');
        editingRow = "#row_" + id;

        $.ajax({
            url: '/Donations/GetDonationForEdit/',
            data: { id: id },
            error: function (xhr, ajaxOptions, thrownError) {
                NotifyDonationError();
                editingRow = "";
            },
            success: function (data) {
                $("#DonationEditModalBody").html(data);
                $('#DonationEditModal').modal('show');
                SetupDonationButtons();
            }
        });
    });
    $('.Donation-Delete').click(function (e) {
        var id = $(this).attr('data-id');
        var title = $(this).attr('data-title');
        editingRow = "#row_" + id;

        $('#id').val(id);
        $('#DonationDeleteModalTitle').html(title);
        $('#DonationDeleteModal').modal('show');
    });

    SetupDonationValidation();
}

function SetupDonationValidation() {
    
    $("#frmNewDonation").validate({
        submitHandler: function (form) {
            //form.submit();
            alert("This is a valid form!");
        },
        //invalidHandler: function (even, validator) {
        //    var regAErrorTotal = validator.numberOfInvalids();
        //    $("#ErrorSummaryErrorTotalRegA").html(regAErrorTotal);
        //},
        highlight: function (element, errorClass) {
            $(element).css("border", "1px solid red");
        },
        unhighlight: function (element, errorClass) {
            $(element).css("border", "");
        },
        //errorPlacement: function (error, element) {
        //    return true;
        //},
        showErrors: function (errorMap, errorList) {
            if (errorList.length > 0) {
                var summary = "";
                $.each(errorList, function () { summary += "<li>" + this.message + "</li>"; });
                $("#div_ErrorSummaryNewDonation").show('fast');
                $("#div_ErrorSummaryNewDonation").html(summary);
            }
            this.defaultShowErrors();
        },
        ignore: "",
        errorElement: "em",
        errorClass: "invalid",
        ignoreTitle: true,
        rules: {
            Donation_Item: {
                required: true,
            },
            Donation_Quantity: {
                required: true,
                range: [1, 10]
            },
            Donation_Quality: {
                required: "Required.",
                range: [1, 10]
            }
        },
        messages: {
            Donation_Item: {
                required: "Required."
            },
            Donation_Quantity: {
                required: "Required.",
                range: 'Minimum value is 1, maximum value is 10.',
            },
            Donation_Quality: {
                required: "Required.",
                range: 'Minimum value is 1, maximum value is 10.',
            }
        }
    });
}

function PageDonations(offSet, limit) {
    $.ajax({
        url: '/Donations/PageDonations/',
        data: { offSet: offSet, limit: limit },
        error: function (xhr, ajaxOptions, thrownError) {
            NotifyDonationError();
        },
        success: function (data) {
            $("#div_Donations").html(data);
            SetupDonationButtons();
        }
    });
}

function NotifyDonationError() {
    $('#div_CreateDonationErrorAlert').show('fast');
}

function NewDonationOnSuccess() {
    $('#div_NewDonationErrorAlert').hide();
    $('#DonationModal').modal('hide');
    SetupDonationButtons();
}

function NewDonationOnFailure() {
    NotifyDonationError();
}

function NewDonationOnComplete() {
    $('#btnCreateNewDonation').html('Create');
    $('#btnCancelNewDonation').show('fast');
}

function NewDonationOnBegin() {
    $('#btnCreateNewDonation').html('Creating...');
    $('#btnCancelNewDonation').hide('fast');
    return true;
}

function EditDonationOnSuccess(data) {
    $('#div_NewDonationErrorAlert').hide();
    $('#DonationEditModal').modal('hide');

    $(editingRow).html(data).animate({
        backgroundColor: "#D3D3D3",
        //color: "#fff",
    }, 1000).delay(1000).animate({
        backgroundColor: "#fff",
        //color: "#000",
    }, 1000)
    ;//replace current row with new data.

    editingRow = "";
    SetupDonationButtons();
}

function EditDonationOnFailure() {
    NotifyDonationError();
}

function EditDonationOnComplete() {
    $('#btnSaveNewDonation').html('Save');
    $('#btnCancelSaveDonation').show('fast');
}

function EditDonationOnBegin() {
    $('#btnSaveNewDonation').html('Saving...');
    $('#btnCancelSaveDonation').hide('fast');
    return true;
}

function DeleteDonationOnSuccess(data) {
    $('#div_NewDonationErrorAlert').hide();
    $('#DonationDeleteModal').modal('hide');

    if (data == "True") {
        $(editingRow).delay(1000).slideUp('slow');//remove deleted row from view.
    }

    editingRow = "";
    SetupDonationButtons();
}

function DeleteDonationOnFailure() {
    NotifyDonationError();
}

function DeleteDonationOnComplete() {
    $('#btnDeleteDonation').html('Yes');
    $('#btnCancelDeleteDonation').show('fast');
}

function DeleteDonationOnBegin() {
    $('#btnDeleteDonation').html('Deleting...');
    $('#btnCancelDeleteDonation').hide('fast');
    return true;
}

var editingRow = "";