

window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", {timeout: 10000});

    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeout: 10000 });

    }
}
window.ShowSweet=(type, message) => {
    if (type === "success") {
        Swal.fire(
            'Good job!',
            'Success Notification',
            'success'
        )
        
       
    }
    if (type === "confirm") {
        Swal.fire(
            'Check In!',
            'Succesful',
            'success'
        )


    }
    if (type === "error") {
        Swal.fire({
            icon: 'error',
            title: 'Name already exist',
            text: 'Oops!',
            /*footer: '<a href="">Why do I have this issue?</a>'*/
        });
    }
}
function showDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}
function startCarousels() {
    $('.carousel').carousel({ interval: 4000 });
}