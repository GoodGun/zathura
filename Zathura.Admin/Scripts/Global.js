function AddCategory() {
    Category = new Object();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.IsActive = $("#categoryIsActive").is(":checked");

    //alert(Category.Name + Category.Url + Category.IsActive);
    $.ajax({
        url: "category/add",
        data: Category,
        type: "POST",
        success: function (response) {
            if (response.success) {
                alert(1);
            }
            else {
                alert(2);
            }
        }
    });
}