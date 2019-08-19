var mainContent;
var titleContent;

$(function () {
    mainContent = $("#MainContent"); /// render partial views.  
    titleContent = $("title"); // render titles.  
});

var routingApp = $.sammy("#MainContent", function () {
    this.get("#/Product/Index", function (context) {
        titleContent.html("Product Page");
        $.get("/Product/Index", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Product/Add", function (context) {
        titleContent.html("Add Product");
        //$("#BigLoader").modal('show'); // If you want to show loader  
        $.get("/Product/Add", function (data) {
            //$("#BigLoader").modal('hide');  
            context.$element().html(data);
        });
    });

    this.get("#/Product/Edit", function (context) {
        titleContent.html("Edit Product");
        $.get("/Product/Edit", {
            ProductID: context.params.id // pass Product id  
        }, function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/About", function (context) {
        titleContent.html("About");
        $.get("/Home/About", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/Contact", function (context) {
        titleContent.html("Contact");
        $.get("/Home/Contact", function (data) {
            context.$element().html(data);
        });
    });
});

$(function () {
    routingApp.run("#/Product/Index"); // default routing page.  
});

function IfLinkNotExist(type, path) {
    if (!(type != null && path != null))
        return false;

    var isExist = true;

    if (type.toLowerCase() == "get") {
        if (routingApp.routes.get != undefined) {
            $.map(routingApp.routes.get, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    } else if (type.toLowerCase() == "post") {
        if (routingApp.routes.post != undefined) {
            $.map(routingApp.routes.post, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    }
    return isExist;
}
