(function ($) {
    // used as a namespace...
    $.dataGrid = function () {
        // no-op
    }

    $.fn.dataGrid = {
        Paging: false,
        PageIndex: 1,
        PageSize: 10,
        SortField: null,
        SortOrder: null,
        RecordCount: null,
        PageCount: null,
        LowerBound: null,
        UpperBound: null
    }

    $.fn.dataGrid = function (callback) {
        if (callback === undefined) {
            callback = function () { };
        }

        //trigger
        $.dataGrid.RebindTrigger = function (contentId) {            
            //Bind Class 

            if ($.fn.dataGrid != null) {               
                var spanSort = $(contentId).find("#" + $.fn.dataGrid.SortField).next("span");
                $(spanSort).addClass($.fn.dataGrid.Class);
                $(spanSort).text($.fn.dataGrid.Text);
                //
                $("#record-from").html($.fn.dataGrid.LowerBound);
                $("#record-to").html($.fn.dataGrid.UpperBound);
                $("#record-count").html($.fn.dataGrid.RecordCount);
                $("#page-count").html($.fn.dataGrid.PageCount);
                $("#page-index").html($.fn.dataGrid.PageIndex);
                $("#page-size").find("label").html($.fn.dataGrid.PageSize);
            }
        };

        $.dataGrid.PagingTrigger = function () {

            //Bind First arrow
            $("#first").click(function (e) {
                e.preventDefault();
                if ($.fn.dataGrid.PageIndex > 1) {
                    $.fn.dataGrid.PageIndex = 1;
                    callback($.fn.dataGrid);
                }
            });

            //Bind prev arrow
            $("#prev").click(function (e) {
                e.preventDefault();
                if ($.fn.dataGrid.PageIndex > 1) {
                    $.fn.dataGrid.PageIndex = +$.fn.dataGrid.PageIndex - 1;
                    callback($.fn.dataGrid);
                }
            });

            //Bind next arrow
            $("#next").click(function (e) {
                e.preventDefault();
                if (+$.fn.dataGrid.PageIndex < +$.fn.dataGrid.PageCount) {
                    $.fn.dataGrid.PageIndex = +$.fn.dataGrid.PageIndex + 1;
                    callback($.fn.dataGrid);
                }
            });

            //Bind last arrow
            $("#last").click(function (e) {
                e.preventDefault();
                if (+$.fn.dataGrid.PageIndex < +$.fn.dataGrid.PageCount) {
                    $.fn.dataGrid.PageIndex = $.fn.dataGrid.PageCount;
                    callback($.fn.dataGrid);
                }
            });

            //Bind page drop down arrow
            $("#page-size").dropDownList(function () {                
                var pageSize = $("#page-size").find("label").html();
                if (+$.fn.dataGrid.PageSize !== +pageSize) {
                    $.fn.dataGrid.PageSize = pageSize;
                    callback($.fn.dataGrid);
                }
            });

            //disable next and last
            if ($.fn.dataGrid.PageIndex === $.fn.dataGrid.PageCount || "" + $.fn.dataGrid.PageIndex + "" === $.fn.dataGrid.PageCount) {                
                $("#next").attr("disabled", "disabled").addClass("disabledPagingNav");
                $("#last").attr("disabled", "disabled").addClass("disabledPagingNav");
                //$("#page-size").attr("disabled", "disabled").addClass("disabled");
            } else {
                $("#next").removeAttr("disabled", "disabled").removeClass("disabledPagingNav");
                $("#last").removeAttr("disabled", "disabled").removeClass("disabledPagingNav");
                //$("#page-size").removeAttr("disabled", "disabled").removeClass("disabled");
            }

            //disable first and prev
            if ($.fn.dataGrid.PageIndex === 1) {                
                $("#first").attr("disabled", "disabled").addClass("disabledPagingNav");
                $("#prev").attr("disabled", "disabled").addClass("disabledPagingNav");                
                
            } else {
                $("#first").removeAttr("disabled", "disabled").removeClass("disabledPagingNav");
                $("#prev").removeAttr("disabled", "disabled").removeClass("disabledPagingNav");;
            }
        }

        return this.each(function () {
            var gridSpan = $(this);
            gridSpan.find("thead > tr > th > a").click(function (e) {
                e.preventDefault();
                var spanSort = $(this).next("span");
                $.fn.dataGrid.SortField = $(this).attr("Id");
                if ($(spanSort).hasClass("asc")) {
                    $.fn.dataGrid.SortOrder = "desc";
                    $.fn.dataGrid.Class = "desc";
                    $.fn.dataGrid.Text = "N";
                    $(spanSort).removeClass("asc");
                }
                else if ($(spanSort).hasClass("desc")) {
                    $.fn.dataGrid.SortOrder = "asc";
                    $.fn.dataGrid.Class = "asc";
                    $.fn.dataGrid.Text = "O";
                    $(spanSort).removeClass("desc");
                }
                else {
                    $.fn.dataGrid.SortOrder = "asc";
                    $.fn.dataGrid.Class = "asc";
                    $.fn.dataGrid.Text = "O";
                    $.fn.dataGrid.Text = "O";
                }
                callback($.fn.dataGrid);
            });

            //Enable paging
            if ($.fn.dataGrid.Paging) {
                $(".paging").show();
                $.dataGrid.PagingTrigger($.fn.dataGrid);
            } else {
                $(".paging").hide();
            }
        });
    }
})(jQuery);
