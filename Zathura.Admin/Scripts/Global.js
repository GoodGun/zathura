function AddCategory() {
    Category = new Object();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.Status = $("#categoryIsActive").is(":checked");
    Category.ParentCategoryId = $("#ParentCategoryId").val();

    //alert(Category.Name + Category.Url + Category.IsActive);
    $.ajax({
        url: "/category/add",
        data: Category,
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
    Category = new Object();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.Status = $("#status").is(":checked");
    Category.ParentCategoryId = $("#ParentCategoryId").val();
    Category.ID = $("#CategoryId").val();

    $.ajax({
        url: "/category/update",
        data: Category,
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