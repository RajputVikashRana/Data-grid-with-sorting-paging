(function ($) {
     //Bind Grid parameter pass from code behind
    BindGrid: function () {    
        $.fn.dataGrid.Paging = true;
        $.fn.dataGrid.PageIndex = 1;
        $.fn.dataGrid.PageSize = 10	;
        $.fn.dataGrid.SortField = null;
        $.fn.dataGrid.SortOrder = null;
        $.fn.dataGrid.RecordCount = 100; //pass from code
        $.fn.dataGrid.PageCount = 1;	 //pass from code
        $.fn.dataGrid.LowerBound = 1;	 //pass from code
        $.fn.dataGrid.UpperBound = 100;	 //pass from code

        $(".datagrid"").dataGrid(function (result) {
            var params = {};            
        });

        //Bind Class
        // $.dataGrid.RebindTrigger($("#grid"));
    }
})(jQuery);
