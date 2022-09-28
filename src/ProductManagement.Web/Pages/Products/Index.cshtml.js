$(function () {
    var l = abp.localization.getResource("ProductManagement");
    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.dataTables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.dataTables.createAjax(
                productManagement.products.product.getList),
            columnDefs: [
                /* TODO: Column Definitions */
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('CategoryName'),
                    data: "categoryName",
                    orderable: false
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('StockState'),
                    data: "stockState",
                    render: function (data) {
                        return l('Enum:StockState' + data);
                    }
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    dataFormat: 'date'
                },
            ]
        }));
});