var itemDetailsId = [];
var itemNames = [];
var itemQtyp = [];
var itemPrice = [];

function inArray(myArray, myValue) {
    var inArray = false;
    myArray.map(function (key) {
        if (key === myValue) {
            inArray = true;
        }
    });
    return inArray;
};

function addItem() {
    var ddval = document.getElementById('body_selectSize');
    var itemDetailId = ddval.options[ddval.selectedIndex].value;

    var ddOpt = document.getElementById('body_selectItem');
    var itemName = ddOpt.options[ddOpt.selectedIndex].text;

    if (!inArray(itemDetailsId, itemDetailId)) {
        itemDetailsId.push(itemDetailId);
        itemNames.push(itemName);
        itemQtyp.push(parseInt(document.getElementById('body_txtQuantity').value));
        itemPrice.push(parseFloat(document.getElementById('body_txtItemPrice').value).toFixed(2));
    } else {
        var itemIndex = itemDetailsId.indexOf(itemDetailId);
        itemQtyp[itemIndex] = itemQtyp[itemIndex] + parseInt(document.getElementById('body_txtQuantity').value);
    }
    displayCart();
}

function displayCart() {
    cartdata = "<table class='table table-hover'><tr><th>Product Name</th><th>Quantity</th><th>Price</th><th>Total</th><th>Action</th></tr>";

    total = 0;

    for (var i = 0; i < itemNames.length; i++) {
        total += itemQtyp[i] * itemPrice[i];
        cartdata += "<tr><td>" + itemNames[i] + "</td><td>" + itemQtyp[i] + "</td><td>" + itemPrice[i] + "</td><td>" + itemQtyp[i] * itemPrice[i] + "</td><td><button onclick='delElement(" + i + ")' class='btn btn-danger'>Delete</button></td></tr>";
    }

    cartdata += "<tr class='info'><td colspan='6' class='text-right'>" +'Total Amount: '+ total + "</td></tr></table>";
    document.getElementById('cart').innerHTML = cartdata;
    document.getElementById('ItemDetailsId').value = itemDetailsId.join(',');
    document.getElementById('Quantity').value = itemQtyp.join(',');
    document.getElementById('Price').value = itemPrice.join(',');
}

function delElement(a) {
    itemDetailsId.splice(a, 1);
    itemNames.splice(a, 1);
    itemQtyp.splice(a, 1);
    itemPrice.splice(a, 1);
    displayCart();
}