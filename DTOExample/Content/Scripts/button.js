document.addEventListener("DOMContentLoaded", function () {
    var myButton = document.getElementById("myButton");
    myButton.addEventListener("click", function () {
        var userConfirmed = confirm("Are you sure?");
        if (userConfirmed) {
            window.location.href = "/Student/DepartmentView";
        } else {
            window.location.href = "/Student/Index";
        }
    });
});
