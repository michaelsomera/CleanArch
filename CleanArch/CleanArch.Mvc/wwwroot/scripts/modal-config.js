var toast;
require(["jquery", "bootstrap", "toastr"], function (jq, bs, tr) {
    toast = tr;
    $(document).ready(function () {
    }).on("click", ".ctn-btn", function () {
        $("#ctnBody").html("");
        $(".ctn-title").html($(this).attr('title'));
        $(".ctn-modal").modal({
            backdrop: 'static',
            keyboard: false
        });
    });
});
function onSuccess(data) {
    if (data.isSuccess) {
        toast.success(data.message);
        $(".ctn-modal").modal("hide");
        $('#data-table').DataTable().ajax.reload();
    }
}
