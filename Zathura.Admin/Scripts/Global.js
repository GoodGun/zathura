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
                bootbox.alert(response.Message,function() {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function() {
                    
                });
            }
        }
    });
}

function DeleteCategory() {
    
    var categoryId = $("#catDeleteBtn").attr("data-id");
    $.ajax({
        url: '/category/delete/' + categoryId,
        type: "POST",
        datatype: 'json',
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