<%@ Page Title="Sub Category List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.SubCat.Default" %>

<asp:Content ID="js" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#linkAddSubCat').click(function () {
                $('#lblTitle').text('Add New Sub Category');
                $('#updateSubCategory').hide();
                $('#addSubCategory').show();
                $('#subCatName').val('');
                $('#txtSubCatDescriptiom').val('');
                $('#catName').prop('selectedIndex', 0);
            });
            getAllSubCat();
            var categoryList = $('#catName');

            $.ajax({
                url: 'SubCatService.asmx/GetCategories',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    categoryList.append($('<option/>', { value: -1, text: 'Select Category' }));
                    $(data).each(function (index, item) {
                        categoryList.append($('<option/>', { value: item.CategoryID, text: item.CatName }));
                    });
                }
            });

            $('#addSubCategory').click(function () {
                var subCategory = {};
                subCategory.SubCatName = $('#subCatName').val();
                subCategory.CatID = $('#catName option:selected').val();
                subCategory.SubCatDescription = $('#txtSubCatDescriptiom').val();

                $('#addSubCat').modal('hide');

                $.ajax({
                    url: 'SubCatService.asmx/InsertSubCat',
                    method: 'post',
                    data: '{subCat: ' + JSON.stringify(subCategory) + '}',
                    contentType: "application/json;charset=utf-8",
                    success: function () {
                        getAllSubCat();
                        alert('Sub Category added successfully.');
                    },
                    error: function (err) {
                        alert("Something went wrong.");
                    }
                });
            });

            $('#updateSubCategory').click(function () {
                var subCategory = {};
                subCategory.SubCatID = $('#subCatId').val();
                subCategory.SubCatName = $('#subCatName').val();
                subCategory.CatID = $('#catName option:selected').val();
                subCategory.SubCatDescription = $('#txtSubCatDescriptiom').val();

                $('#addSubCat').modal('hide');

                $.ajax({
                    url: 'SubCatService.asmx/UpdateSubCat',
                    method: 'post',
                    data: '{subCat: ' + JSON.stringify(subCategory) + '}',
                    contentType: "application/json;charset=utf-8",
                    success: function () {
                        getAllSubCat();
                        alert('Sub Category updated successfully.');
                    },
                    error: function (err) {
                        alert("Something went wrong.");
                    }
                });
            });

            $(document).on("click", "#btnDelete", function () {
                var id = $(this).attr("data-id");
                var dialogResult = confirm("Do you want to delete this?");
                if (dialogResult == true) {
                    $.ajax({
                        url: 'SubCatService.asmx/DeleteSubCat',
                        data: '{subCatId: ' + id + '}',
                        method: 'post',
                        contentType: "application/json;charset=utf-8",
                        success: function () {
                            getAllSubCat();
                            alert('Sub Category deleted successfully.');
                        },
                        error: function (err) {
                            alert("Something went wrong.");
                        }
                    });
                }
            });

            $(document).on("click", "#btnEdit", function () {
                $('#lblTitle').text('Update Sub Category');
                $('#addSubCategory').hide();
                $('#updateSubCategory').show();
                var mysubcatid = $(this).attr("data-subcatid");
                $.ajax({
                    url: 'SubCatService.asmx/GetSubCatById',
                    data: { subCatId: mysubcatid },
                    dataType: 'json',
                    method: 'post',
                    success: function (data) {
                        $('#subCatId').val(data.SubCatID);
                        $('#subCatName').val(data.SubCatName);
                        $('#txtSubCatDescriptiom').val(data.SubCatDescription);
                        $("select[name=catName] option[value=" + data.CatID + "]").attr("selected",true);
                    },
                    error: function (err) {
                        alert("Something went wrong.");
                    }
                });
            });

            function getAllSubCat() {
                $.ajax({
                    url: 'SubCatService.asmx/GetAllSubCat',
                    dataType: "json",
                    method: 'post',
                    success: function (data) {
                        var subCatTable = $('#tblSubCat tbody');
                        subCatTable.empty();
                        $(data).each(function (index, subCat) {
                            subCatTable.append('<tr><td>' + subCat.SubCatName + '</td><td>'
                                + subCat.SubCatDescription + '</td><td>' +
                                subCat.CatName +
                                "</td><td><button id='btnEdit' type='button' class='btn btn-success btn-sm' data-subcatid=" + subCat.SubCatID + " data-toggle='modal' data-target='#addSubCat'> <span class='glyphicon glyphicon-pencil' ></span > Edit </button><button id='btnDelete' type='button' class='btn btn-danger btn-sm' data-id=" + subCat.SubCatID + "> <span class='glyphicon glyphicon-trash'></span>Delete</button><button type='button' class='btn btn-info btn-sm'><span class='glyphicon glyphicon-eye-open'></span>Details</button></td></tr>");
                        });
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            }
        });
    </script>
</asp:Content>

<asp:Content ID="UserName" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="subCatList" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="form-inline">
                <div class="input-group">
                    <input id="searchInput" type="text" class="form-control" placeholder="Search for..." runat="server">
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-default" Text="Go!" OnClick="BtnSearch_Click" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <a href="#" data-toggle="modal" data-target="#addSubCat" id="linkAddSubCat">Add New Sub Category</a>
    <label id="message" runat="server"></label>
    <table id="tblSubCat" class="table table-bordered">
        <thead>
            <tr>
                <th>Sub Category Name</th>
                <th>Sub Category Description</th>
                <th>Category Name</th>
                <th class="text-center">Action</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="PopupContent" ContentPlaceHolderID="extraContent" runat="server">
    <div class="modal fade" id="addSubCat" tabindex="-1" role="dialog" aria-labelledby="addSubCat">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="lblTitle"></h4>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="subCatId"/>
                    <div class="form-group">
                        <label for="subCatName" class="control-label">Sub Category Name:</label>
                        <input type="text" class="form-control" id="subCatName" />
                    </div>
                    <div class="form-group">
                        <label for="catName" class="control-label">Category Name:</label>
                        <select id="catName" class="form-control" name="catName"></select>
                    </div>
                    <div class="form-group">
                        <label for="txtSubCatDescriptiom" class="control-label">Sub Category Description:</label>
                        <textarea class="form-control" id="txtSubCatDescriptiom"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary" id="addSubCategory">Add Sub Category</button>
                    <button type="button" class="btn btn-primary" id="updateSubCategory">Update Sub Category</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
