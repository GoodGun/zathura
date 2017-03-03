function AddCategory() {
    var category = new Object();
    category.Name = $("#categoryName").val();
    category.Url = $("#categoryUrl").val();
    category.Status = $("#status").val() ? $("#status").val() : 0;
    category.ParentCategoryId = $("#ParentCategoryId").val();

    $.ajax({
        url: "/category/add",
        data: category,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}

/* Delete Category Function Start */
$(document).on("click", "#catDeleteBtn", function () {
    var categoryId = $(this).attr("data-id");
    var deleteRow = $(this).closest("tr");

    bootbox.confirm("Are you sure want to delete?", function (result) {
            if (result) {
                $.ajax({
                    url: '/category/delete/' + categoryId,
                    type: "POST",
                    datatype: 'json',
                    success: function (response) {
                        if (response.Success) {
                            $.notify(response.Message, "success");
                            deleteRow.fadeOut(300,
                                function() {
                                    deleteRow.remove();
                                });
                        }
                        else {
                            $.notify(response.Message, "error");
                        }
                    }
                });
            }
        });
});
/* Delete Category Function End */


function UpdateCategory() {
    var category = new Object();
    category.Name = $("#categoryName").val();
    category.Url = $("#categoryUrl").val();
    category.Status = $("#status").val() ? $("#status").val() : 0;
    category.ParentCategoryId = $("#ParentCategoryId").val();
    category.ID = $("#ID").val();

    $.ajax({
        url: "/category/update",
        data: category,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}