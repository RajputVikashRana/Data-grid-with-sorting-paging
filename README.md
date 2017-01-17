# Data-grid-with-sorting-paging using jquery
Paging and sorting using jquery

User can use datagrid js file for paging and sorting using jquery. Put js file in code, add html with grid and just pass paging
option (property) to run paging and sorting.
 
 Step to add paging and sorting
 
 1. Add grid top div with grid id and class name is also grid.
 2. Create store procedure or linq query for paging.
 3. Add properties for PageIndex, pagingSize etc (see the file PagingOptions)
 4. To pass or bind js property Like
 
 // paging parameter
 
 var options = new PagingOptions
 
            {
            
                PageIndex = pageIndex,
                
                PageSize = pageSize,
                
                SortField = sortField,
                
                SortOrder = sortOrder,
                
            };
            
            
ViewBag.RecordCount = options.RecordCount;
ViewBag.PageCount = options.PageCount;
ViewBag.LowerBound = options.LowerBound;
ViewBag.UpperBound = options.UpperBound;

5. Add Html tfoot in grid footer section for paging. (see the html file)
6. Call bindgrid method to bind paging and sorting 
      true  => paging will display
      false => hide paging 



Datagrid js file is reusable component. 
            
