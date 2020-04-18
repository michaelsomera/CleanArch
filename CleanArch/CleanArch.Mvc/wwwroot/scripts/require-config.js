var rconfig;

rconfig = {
    baseUrl: "/vendor",
    waitSeconds: 100,
    paths: {
        "bootstrap": "../lib/bootstrap/dist/js/bootstrap.bundle.min",
        "typeahead": "typeahead/js/typeahead.bundle.min",
        "bloodhound": "typeahead/js/bloodhound.min",
        "toastr": "toastr/js/toastr.min",
        "bootbox": "bootbox.min",
        "datepicker": "bootstrap-datepicker/js/bootstrap-datepicker.min",
        "jquery": "../lib/jquery/dist/jquery.min",
        "jqueryval": "../lib/jquery-validation/dist/jquery.validate.min",
        "jqueryvalunobtr": "../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min",
        "jqueryunobtr": 'jquery.unobtrusive-ajax.min',
        "datatables": "datatables/js/jquery.dataTables.min",
        "datatables.net": "datatables/js/dataTables.bootstrap4.min"
    },
    shim:{
        "jqueryval": ["jquery"],
        "jqueryvalunobtr": ["jquery", "jqueryval"],
        "bootstrap": ["jquery"],
        "typeahead": ["jquery"],
        "bloodhound": ["jquery"],
        "datepicker": ["jquery"],
        "bootbox": ["jquery"],
        "toastr": ["jquery"]
    }
}

require.config(rconfig);