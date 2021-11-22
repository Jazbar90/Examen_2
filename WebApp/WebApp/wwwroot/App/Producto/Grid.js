"use strict";
var ProductoGrid;
(function (ProductoGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar El Registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.ProductoEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se Elimino Correctamente", icon: "success" }).then(function () { return window.location.reload(); });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    ProductoGrid.OnClickEliminar = OnClickEliminar;
})(ProductoGrid || (ProductoGrid = {}));
$("#GridView").DataTable();
//# sourceMappingURL=Grid.js.map