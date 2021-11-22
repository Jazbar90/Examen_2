﻿namespace ProductoGrid {


    export function OnClickEliminar(id) {

        ComfirmAlert("Desea Eliminar El Registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(result => {
                if (result.isConfirmed) {
                    Loading.fire("Borrando");
                    App.AxiosProvider.ProductoEliminar(id).then(data => {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se Elimino Correctamente", icon: "success" }).then(() => window.location.reload());
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }

                    });
                }
            })
    }
}
    $("#GridView").DataTable();